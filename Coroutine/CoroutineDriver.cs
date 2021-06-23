using System.Collections;
using System.Collections.Generic;
using NReferencePool;

namespace NCoroutine
{
    internal class CoroutineDriver
    {
        private readonly LinkedList<IEnumerator> linkedList;
        internal CoroutineAwaiter awaiter;

        internal IWaitable currentWait;
        internal bool isComplete;

        public CoroutineDriver(IEnumerator enumerator)
        {
            linkedList = new LinkedList<IEnumerator>();
            linkedList.AddFirst(enumerator);
        }

        internal IEnumerator enumerator
        {
            get
            {
                if (linkedList.Count > 0) return linkedList.First.Value;

                return null;
            }
        }

        internal void Complete()
        {
            awaiter?.Set();
        }


        internal bool Update(float deltaTime)
        {
            if (currentWait != null && !currentWait.IsComplete)
            {
                currentWait.Update(deltaTime);
                return true;
            }

            ReferencePool.Release(currentWait);
            currentWait = null;

            if (enumerator != null && enumerator.MoveNext())
            {
                switch (enumerator.Current)
                {
                    case WaitForTime wait:
                        WaitTimer tempTimer = ReferencePool.Acquire<WaitTimer>();
                        tempTimer.SetTime(wait);
                        currentWait = tempTimer;
                        break;
                    case UnityEngine.AsyncOperation operation:
                        WaitOperation tempOperation = ReferencePool.Acquire<WaitOperation>();
                        tempOperation.SetOperation(operation);
                        currentWait = tempOperation;
                        break;
                    case CoroutineHandle handle:
                        WaitDriver tempDriver = ReferencePool.Acquire<WaitDriver>();
                        tempDriver.SetDriver(handle.driver);
                        currentWait = tempDriver;
                        break;
                    case IEnumerator nestedEnumerator:
                        linkedList.AddFirst(nestedEnumerator);
                        break;
                    case int _:
                    case float _:
                    case null:
                        break;
                }

                return true;
            }

            if (linkedList.Count > 0)
            {
                linkedList.RemoveFirst();
                return true;
            }

            return false;
        }
    }
}