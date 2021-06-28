using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using NReferencePool;

namespace NCoroutine
{
    public class CoroutineGroup : IReference
    {
        private readonly List<Func<IEnumerator>> coroutines;
        private readonly List<CoroutineHandle> handles;

        public CoroutineGroup()
        {
            handles = new List<CoroutineHandle>(4);
            coroutines = new List<Func<IEnumerator>>(4);
        }

        public void Clear()
        {
            coroutines.Clear();
            handles.Clear();
        }

        public CoroutineGroup Run()
        {
            handles.Clear();
            foreach (Func<IEnumerator> coroutine in coroutines) handles.Add(Coroutine.Run(coroutine()));
            return this;
        }

        public void Stop()
        {
            foreach (CoroutineHandle coroutineHandle in handles) Coroutine.Stop(coroutineHandle);
            handles.Clear();
        }

        public static CoroutineGroup Create(IEnumerable<Func<IEnumerator>> coroutines)
        {
            CoroutineGroup coroutineGroup = ReferencePool.Acquire<CoroutineGroup>();
            coroutineGroup.coroutines.AddRange(coroutines);
            return coroutineGroup;
        }

        public IEnumerator WaitAny(bool autoStopOther = true)
        {
            bool isCompleted = false;
            while (isCompleted == false)
            {
                yield return null;
                for (int i = 0; i < handles.Count; i++)
                    if (handles[i].driver == null || handles[i].driver.isComplete)
                    {
                        isCompleted = true;
                        break;
                    }
            }

            if (autoStopOther) Stop();
        }

        public IEnumerator WaitAll()
        {
            int completedNumber = 0;
            while (completedNumber != handles.Count)
            {
                yield return null;
                completedNumber = 0;
                for (int i = 0; i < handles.Count; i++)
                    if (handles[i].driver == null || handles[i].driver.isComplete)
                        completedNumber++;
            }
        }
    }
}