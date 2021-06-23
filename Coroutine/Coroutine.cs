using System.Collections;
using System.Collections.Generic;
using NReferencePool;
using UnityEngine;

namespace NCoroutine
{
    public static class Coroutine
    {
        private static readonly List<CoroutineHandle> adds;
        private static readonly List<CoroutineHandle> handles;
        private static readonly List<CoroutineHandle> removeIndexes;
        private static List<CoroutineDriver> removes;
        private static CoroutineDevice device;
       // private static readonly Dictionary<CoroutineHandle, float> handless;
        private static readonly HashSet<CoroutineHandle> waitRemove;

        static Coroutine()
        {
            handles = new List<CoroutineHandle>(20);
            removeIndexes = new List<CoroutineHandle>(20);
            adds = new List<CoroutineHandle>(10);
            waitRemove = new HashSet<CoroutineHandle>();
            GameObject obj = new GameObject() {hideFlags = HideFlags.HideAndDontSave};
            Object.DontDestroyOnLoad(obj);
            device = obj.AddComponent<CoroutineDevice>();
            device.coroutineUpdate += Update;
        }

        public static CoroutineHandle Run(IEnumerator cor)
        {
            CoroutineDriver driver = new CoroutineDriver(cor);
            var temp=new CoroutineHandle() {driver = driver,startTime = Time.unscaledTime};
            adds.Add(temp);
            return temp;
        }

        public static void Stop(CoroutineHandle handle)
        {
            if (handle != null)
            {
                if (!removes.Contains(handle.driver))
                {
                    removes.Add(handle.driver);
                }

                handle.driver = null;
            }
        }

        public static void Update(float deltaTime)
        {
            for (var i = 0; i < removeIndexes.Count; i++)
            {
                removeIndexes[i].driver = null;
                handles.Remove(removeIndexes[i]);
            }
            removeIndexes.Clear();
            handles.AddRange(adds);
            adds.Clear();
            for (int i = 0; i < handles.Count; i++)
            {
                CoroutineHandle temp = handles[i];
                if (temp.driver.Update(deltaTime)) continue;
                temp.driver.Complete();
                removeIndexes.Add(temp);
            }
        }
    }


    internal interface IWaitable : IReference
    {
        bool IsComplete { get; }
        void Update(float deltaTime);
    }

    internal class WaitDriver : IWaitable
    {
        internal CoroutineDriver Driver;

        public bool IsComplete => Driver.isComplete;

        void IWaitable.Update(float deltaTime)
        {
        }

        public void Clear()
        {
            Driver = null;
        }

        internal void SetDriver(CoroutineDriver driver)
        {
            Driver = driver;
        }
    }

    internal class WaitOperation : IWaitable
    {
        private bool isDone;
        internal AsyncOperation operation;
        public bool IsComplete => isDone;

        void IWaitable.Update(float deltaTime)
        {
        }

        public void Clear()
        {
            operation = null;
            isDone = false;
        }

        public void SetOperation(AsyncOperation operation)
        {
            this.operation = operation;
            operation.completed += OperationDone;
        }

        private void OperationDone(AsyncOperation operation)
        {
            isDone = operation.isDone;
        }
    }

    internal class WaitTimer : IWaitable
    {
        internal float duration;
        internal float elapsedTime;
        internal WaitForTime time;

        public bool IsComplete => elapsedTime >= time.duration;

        void IWaitable.Update(float deltaTime)
        {
            if (!IsComplete) elapsedTime += deltaTime;
        }

        public void Clear()
        {
            elapsedTime = 0;
            time = null;
            duration = 0;
        }

        internal void SetTime(WaitForTime time)
        {
            this.time = time;
        }
    }
}