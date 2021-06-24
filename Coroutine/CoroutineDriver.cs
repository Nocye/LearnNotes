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
            isComplete = true;
            awaiter?.Set();
        }


        internal bool Update(float deltaTime)
        {
            if (currentWait is {IsComplete: false})
            {
                currentWait.Update(deltaTime);
                return true;
            }

          
            if (currentWait != null)
            {
                ReferencePool.Release(currentWait);
                currentWait = null;
            }

            if (enumerator != null && enumerator.MoveNext())
            {
                switch (enumerator.Current)
                {
                    case WaitForTime wait:
                        WaitTimer tempTimer = ReferencePool.Acquire<WaitTimer>();
                        tempTimer.SetTime(wait);
                        currentWait = tempTimer;
                        break;
                    case BaseWait customWait:
                        WaitCustom tempCustom = ReferencePool.Acquire<WaitCustom>();
                        tempCustom.SetCustom(customWait);
                        currentWait = tempCustom;
                        break;
                    case UnityEngine.AsyncOperation operation:
                        WaitOperation tempOperation = ReferencePool.Acquire<WaitOperation>();
                        tempOperation.SetOperation(operation);
                        currentWait = tempOperation;
                        break;
                    case CoroutineHandle handle:
                        WaitInternalDriver tempInternalDriver = ReferencePool.Acquire<WaitInternalDriver>();
                        tempInternalDriver.SetDriver(handle.driver);
                        currentWait = tempInternalDriver;
                        break;
                    case IEnumerator nestedEnumerator:
                        linkedList.AddFirst(nestedEnumerator);
                        break;
                    default:
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