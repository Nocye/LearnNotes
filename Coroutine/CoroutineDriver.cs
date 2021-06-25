using System.Collections;
using System.Collections.Generic;
using NReferencePool;

namespace NCoroutine
{
    internal sealed class CoroutineDriver : IReference
    {
        private LinkedList<IEnumerator> linkedList;
        internal CoroutineAwaiter awaiter;
        internal CoroutineHandle handle;
        internal IWaitable currentWait;
        internal bool isComplete;
        public CoroutineDriver()
        {
            linkedList = new LinkedList<IEnumerator>();
        }

        public static CoroutineDriver CreateDriver(IEnumerator enumerator,CoroutineHandle handle)
        {
            CoroutineDriver driver = ReferencePool.Acquire<CoroutineDriver>();
            driver.linkedList.AddFirst(enumerator);
            driver.handle = handle;
            driver.isComplete = false;
            return driver;
        }

        internal IEnumerator enumerator
        {
            get
            {
                if (linkedList.Count > 0) return linkedList.First.Value;

                return null;
            }
        }

        public void Clear()
        {
            linkedList.Clear();
            awaiter = null;
            handle = null;
            currentWait = null;
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
                    case WaitForTime waitForTime:
                        currentWait = WaitTimer.Create(waitForTime);
                        break;
                    case BaseWait customWait:
                        currentWait = WaitCustom.Create(customWait);
                        break;
                    case UnityEngine.AsyncOperation operation:
                        currentWait = WaitOperation.Create(operation);
                        break;
                    case CoroutineHandle coroutineHandle:
                        currentWait = WaitInternalDriver.Create(coroutineHandle.driver);
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