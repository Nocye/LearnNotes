using System.Collections;
using System.Collections.Generic;
using NReferencePool;
using UnityEngine;

namespace NCoroutine
{
    internal sealed class CoroutineDriver : IReference
    {
        private readonly Stack<IEnumerator> waitEnumerators;
        internal IEnumerator enumerator;

        internal CoroutineHandle handle;

        internal bool isComplete;

        public CoroutineDriver()
        {
            waitEnumerators = new Stack<IEnumerator>(4);
        }

        public void Clear()
        {
            handle = null;
            if (enumerator is IWaitable waitable) ReferencePool.Release(waitable);

            enumerator = null;
            
            while (waitEnumerators.Count > 0)
            {
                IEnumerator stackWaitable = waitEnumerators.Pop();
                if (stackWaitable is IWaitable wait) ReferencePool.Release(wait);
            }

            waitEnumerators.Clear();
        }

        internal void Completed()
        {
            handle.driver = null;
            isComplete = true;
        }

        public static CoroutineDriver Create(IEnumerator enumerator, CoroutineHandle handle)
        {
            CoroutineDriver driver = ReferencePool.Acquire<CoroutineDriver>();
            driver.enumerator = enumerator;
            driver.handle = handle;
            driver.isComplete = false;
            return driver;
        }


        internal bool Update(float deltaTime)
        {
            if (enumerator.MoveNext())
            {
                switch (enumerator.Current)
                {
                    case null:
                        break;
                    case WaitForTime waitForTime:
                        waitEnumerators.Push(enumerator);
                        enumerator = WaitTimer.Create(waitForTime);
                        break;
                    case AsyncOperation operation:
                        waitEnumerators.Push(enumerator);
                        enumerator = WaitOperation.Create(operation);
                        break;
                    case CoroutineHandle coroutineHandle:
                        waitEnumerators.Push(enumerator);
                        enumerator = WaitInternalDriver.Create(coroutineHandle.driver);
                        break;
                    case BaseWait customWait:
                        waitEnumerators.Push(enumerator);
                        enumerator = WaitCustom.Create(customWait);
                        break;
                    case IEnumerator nestedEnumerator:
                        waitEnumerators.Push(enumerator);
                        enumerator = nestedEnumerator;
                        break;
                }

                return true;
            }

            if (enumerator is IWaitable waitable) ReferencePool.Release(waitable);

            if (waitEnumerators.Count <= 0) return false;
            enumerator = waitEnumerators.Pop();
            return true;
        }
    }
}