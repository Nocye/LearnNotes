using System.Collections;
using System.Collections.Generic;
using NReferencePool;
using UnityEditor;
using UnityEngine;

namespace NCoroutine
{
    public static class Coroutine
    {
        //存储方式有优化空间
        private static readonly List<CoroutineDriver> waitAdds;
        private static readonly List<CoroutineDriver> drivers;
        private static readonly List<CoroutineDriver> waitRemoves;


        private static readonly CoroutineDevice device;

        static Coroutine()
        {
            drivers = new List<CoroutineDriver>(20);
            waitRemoves = new List<CoroutineDriver>();
            waitAdds = new List<CoroutineDriver>(10);
            GameObject obj = new GameObject {hideFlags = HideFlags.HideAndDontSave};
            Object.DontDestroyOnLoad(obj);
            device = obj.AddComponent<CoroutineDevice>();
            device.coroutineUpdate += Update;
        }

        /// <summary>
        /// 运行一个协程,当前帧添加进队列,下一帧开始执行
        /// </summary>
        /// <param name="cor"></param>
        /// <returns></returns>
        public static CoroutineHandle Run(IEnumerator cor)
        {
            CoroutineHandle handle = new CoroutineHandle();
            CoroutineDriver driver = CoroutineDriver.Create(cor, handle);
            handle.driver = driver;
            waitAdds.Add(driver);
            return handle;
        }

        /// <summary>
        /// 停止一个协程
        /// </summary>
        /// <param name="handle"></param>
        public static void Stop(CoroutineHandle handle)
        {
            if (handle?.driver == null) return;
            InternalStop(handle.driver);
        }

        /// <summary>
        /// 停止一个协程,当前帧立刻标记为完成,执行等待器的延续函数,下一帧删除并清理
        /// </summary>
        /// <param name="driver"></param>
        private static void InternalStop(CoroutineDriver driver)
        {
            if (!driver.isComplete)
            {
                driver.Completed();
                waitRemoves.Add(driver);
                driver.handle.awaiter?.Complete();
            }
        }
        /// <summary>
        /// 统一删除并清理内部协程
        /// </summary>
        private static void RemoveCoroutine()
        {
            foreach (CoroutineDriver driver in waitRemoves)
            {
                drivers.Remove(driver);
                ReferencePool.Release(driver);
            }

            waitRemoves.Clear();
        }

        private static void AddCoroutine()
        {
            drivers.AddRange(waitAdds);
            waitAdds.Clear();
        }

        private static void Update(float deltaTime)
        {
            AddCoroutine();
            RemoveCoroutine();
            foreach (CoroutineDriver driver in drivers)
            {
                //轮询,如果协程结束就立即完成,下一帧从列表中移除
                //如果在协程中停止一个协程,这个协程先于被停止的协程运行,就会导致仍在列表内,但是以完成的状态,需要判断一下
                if (!driver.isComplete)
                {
                    if (driver.Update(deltaTime))
                        continue;
                    InternalStop(driver);
                }
            }
        }
    }


    internal sealed class WaitInternalDriver : IWaitable
    {
        private CoroutineDriver driver;

        void IReference.Clear()
        {
            driver = null;
        }

        bool IEnumerator.MoveNext()
        {
            return !driver.isComplete;
        }

        void IEnumerator.Reset()
        {
        }

        object IEnumerator.Current => null;

        internal static WaitInternalDriver Create(CoroutineDriver driver)
        {
            WaitInternalDriver internalDriver = ReferencePool.Acquire<WaitInternalDriver>();
            internalDriver.driver = driver;
            return internalDriver;
        }
    }

    internal sealed class WaitCustom : IWaitable
    {
        private BaseWait baseWait;

        void IReference.Clear()
        {
            baseWait = null;
        }

        bool IEnumerator.MoveNext()
        {
            return baseWait.Update();
        }

        void IEnumerator.Reset()
        {
        }

        object IEnumerator.Current => null;

        internal static WaitCustom Create(BaseWait baseWait)
        {
            WaitCustom waitCustom = ReferencePool.Acquire<WaitCustom>();
            waitCustom.baseWait = baseWait;
            return waitCustom;
        }
    }

    internal sealed class WaitOperation : IWaitable
    {
        private AsyncOperation operation;


        void IReference.Clear()
        {
            operation = null;
        }

        bool IEnumerator.MoveNext()
        {
            return !operation.isDone;
        }

        void IEnumerator.Reset()
        {
        }

        object IEnumerator.Current => null;

        internal static WaitOperation Create(AsyncOperation operation)
        {
            WaitOperation waitOperation = ReferencePool.Acquire<WaitOperation>();
            waitOperation.operation = operation;
            return waitOperation;
        }
    }

    internal sealed class WaitTimer : IWaitable
    {
        private float elapsedTime;
        private WaitForTime time;


        void IReference.Clear()
        {
            elapsedTime = 0;
            time = null;
        }

        bool IEnumerator.MoveNext()
        {
            return (elapsedTime += time.ignoreTimeScale ? Time.deltaTime * Time.timeScale : Time.deltaTime) <
                   time.duration;
        }

        void IEnumerator.Reset()
        {
        }

        object IEnumerator.Current => null;

        internal static WaitTimer Create(WaitForTime waitForTime)
        {
            WaitTimer waitTimer = ReferencePool.Acquire<WaitTimer>();
            waitTimer.time = waitForTime;
            return waitTimer;
        }
    }
}