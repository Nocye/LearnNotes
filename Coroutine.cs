using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DefaultNamespace;
using UnityEngine.Pool;

namespace Algorithm
{
    public class Coroutine
    {
        private List<CoroutineHandle> handles;
        private List<int> removes;
        private List<CoroutineHandle> adds;
        private List<CoroutineHandle> remove2s;

        public Coroutine()
        {
            handles = new List<CoroutineHandle>(20);
            removes = new List<int>(20);
            adds = new List<CoroutineHandle>(10);
        }

        public CoroutineHandle Add(IEnumerator cor)
        {
            CoroutineHandle handle = new CoroutineHandle(cor);
            adds.Add(handle);
            return handle;
        }

        public void Stop(CoroutineHandle handle)
        {
            // remove2s.Add(handle);
            // int max = handles.Count;
            // int current = 0;
            // while (handle.current is WaitChild child)
            // {
            //     remove2s.Add(child.handle);
            //     handle = child.handle;
            //     current++;
            // }
        }

        public void Update(float deltaTime)
        {
            for (var i = 0; i < removes.Count; i++)
            {
                handles.RemoveAt(removes[i]);
            }

            removes.Clear();
            handles.AddRange(adds);
            adds.Clear();
            for (var i = 0; i < handles.Count; i++)
            {
                var temp = handles[i];
                if (!temp.Update(deltaTime))
                {
                    removes.Add(i);
                }
            }
        }
    }

    public class CoroutineHandle : IWaitable
    {
        internal IEnumerator enumerator
        {
            get
            {
                if (linkedList.Count > 0)
                {
                    return linkedList.First.Value;
                }

                return null;
            }
        }

        internal IWaitable current;
        internal bool isComplete;
        private LinkedList<IEnumerator> linkedList;

        public CoroutineHandle(IEnumerator enumerator)
        {
            linkedList = new LinkedList<IEnumerator>();
            linkedList.AddFirst(enumerator);
            //this.enumerator = enumerator;
        }

        public bool IsComplete => isComplete;
        void IWaitable.Update(float deltaTime)
        {
        }

        public void Reset()
        {
        }

        internal bool Update(float deltaTime)
        {
            if (current != null && !current.IsComplete)
            {
                current.Update(deltaTime);
                return true;
            }

            if (current != null && current.IsComplete)
            {
                current.Reset();
                current = null;
            }

            if (enumerator != null && enumerator.MoveNext())
            {
                if (enumerator.Current is IWaitable wait)
                {
                    current = wait;
                }
                else if (enumerator.Current == null || enumerator.Current is int)
                {
                }
                else if (enumerator.Current is UnityEngine.AsyncOperation asyncOperation)
                {
                    current = new WaitOther() {operation = asyncOperation};
                }
                else if (enumerator.Current is IEnumerator cor)
                {
                    // var c = pOINT.coroutine.Add(cor);
                    // current = new WaitChild(c);
                    linkedList.AddFirst(cor);
                }

                return true;
            }
            else
            {
                if (linkedList.Count > 0)
                {
                    linkedList.RemoveFirst();
                    return true;
                }

                isComplete = true;
                return false;
            }
        }
    }

    interface IWaitable
    {
        bool IsComplete { get; }
        void Update(float deltaTime);
        void Reset();
    }

    class WaitChild : IWaitable
    {
        //internal CoroutineHandle handle;
        private IEnumerator enumerator;
        public bool IsComplete => false;

        public WaitChild(IEnumerator cor)
        {
            enumerator = cor;
        }

        public void Update(float deltaTime)
        {
            return;
        }

        public void Reset()
        {
        }
    }

    class WaitOther : IWaitable
    {
        internal UnityEngine.AsyncOperation operation;
        public bool IsComplete => operation.isDone;

        public void Update(float deltaTime)
        {
            return;
        }

        public void Reset()
        {
            operation = null;
        }
    }

    internal class WaitForTime : IWaitable
    {
        internal float duration;
        internal float elapsedTime;

        public WaitForTime(float duration)
        {
            this.duration = duration;
        }

        public bool IsComplete => elapsedTime >= duration;

        public void Update(float deltaTime)
        {
            if (!IsComplete)
            {
                elapsedTime += deltaTime;
            }
        }

        public void Reset()
        {
            elapsedTime = 0;
        }
    }
}