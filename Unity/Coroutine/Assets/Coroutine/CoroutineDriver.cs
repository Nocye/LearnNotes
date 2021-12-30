using System.Collections;
using System.Collections.Generic;
using NReferencePool;
using UnityEngine;
using UnityEngine.Analytics;

namespace NCoroutine
{
    internal sealed class CoroutineDriver : IReference
    {
        //Unity在等待一个迭代器嵌套迭代器的时候,会把第一个嵌套迭代器在同一帧也开始执行,猜测 unity在添加携程时立即执行一次 (movenext ,switch current) 碰到迭代器就再次创建新协程,
        //这样的做法是每个迭代器一个协程,我的做法是把迭代器都放在一个协程类中
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
            //这里用循环的原因是,需要处理迭代器嵌套迭代器的情况,当协程中的一个迭代器执行完毕后,当前帧立即进入下一个迭代器,
            //而不是在下一帧,否则当嵌套多的情况下会浪费时间.做到和unity官方的一致


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
                    //处理嵌套
                    break;
            }

            while (!enumerator.MoveNext())
            {
                if (enumerator is IWaitable waitable) ReferencePool.Release(waitable);

                if (waitEnumerators.Count <= 0) return false;
                enumerator = waitEnumerators.Pop();
            }
            return true;

            // if (!enumerator.MoveNext())
            // {
            //     if (enumerator is IWaitable waitable) ReferencePool.Release(waitable);
            //
            //     if (waitEnumerators.Count <= 0) return false;
            //     enumerator = waitEnumerators.Pop();
            //     return enumerator.MoveNext();
            // }



            // }       int number = 0;
            // while (number < 10000)
            // {
            //     number++;
            //
            //     if (enumerator.MoveNext())
            //     {
            //         switch (enumerator.Current)
            //         {
            //             case null:
            //                 break;
            //             case WaitForTime waitForTime:
            //                 waitEnumerators.Push(enumerator);
            //                 enumerator = WaitTimer.Create(waitForTime);
            //                 break;
            //             case AsyncOperation operation:
            //                 waitEnumerators.Push(enumerator);
            //                 enumerator = WaitOperation.Create(operation);
            //                 break;
            //             case CoroutineHandle coroutineHandle:
            //                 waitEnumerators.Push(enumerator);
            //                 enumerator = WaitInternalDriver.Create(coroutineHandle.driver);
            //                 break;
            //             case BaseWait customWait:
            //                 waitEnumerators.Push(enumerator);
            //                 enumerator = WaitCustom.Create(customWait);
            //                 break;
            //             case IEnumerator nestedEnumerator:
            //                 waitEnumerators.Push(enumerator);
            //                 enumerator = nestedEnumerator;
            //                 //处理嵌套
            //                 continue;
            //         }
            //
            //         return true;
            //     }
            //
            //     if (enumerator is IWaitable waitable) ReferencePool.Release(waitable);
            //
            //     if (waitEnumerators.Count <= 0) return false;
            //     enumerator = waitEnumerators.Pop();
            // }


            // if (enumerator.MoveNext())
            // {
            //     switch (enumerator.Current)
            //     {
            //         case null:
            //             break;
            //         case WaitForTime waitForTime:
            //             waitEnumerators.Push(enumerator);
            //             enumerator = WaitTimer.Create(waitForTime);
            //             break;
            //         case AsyncOperation operation:
            //             waitEnumerators.Push(enumerator);
            //             enumerator = WaitOperation.Create(operation);
            //             break;
            //         case CoroutineHandle coroutineHandle:
            //             waitEnumerators.Push(enumerator);
            //             enumerator = WaitInternalDriver.Create(coroutineHandle.driver);
            //             break;
            //         case BaseWait customWait:
            //             waitEnumerators.Push(enumerator);
            //             enumerator = WaitCustom.Create(customWait);
            //             break;
            //         case IEnumerator nestedEnumerator:
            //             waitEnumerators.Push(enumerator);
            //             enumerator = nestedEnumerator;
            //             break;
            //     }
            //
            //     return true;
            // }
            //
            // if (enumerator is IWaitable waitable) ReferencePool.Release(waitable);
            //
            // if (waitEnumerators.Count <= 0) return false;
            // enumerator = waitEnumerators.Pop();
            // return true;
        }
    }
}