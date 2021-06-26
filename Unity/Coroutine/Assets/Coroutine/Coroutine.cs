using System.Collections;
using System.Collections.Generic;
using NReferencePool;
using UnityEngine;

namespace NCoroutine
{
    public static class Coroutine
    {
        //这里最优的存储应该是参考dotweene内部的数组方式,需要一种查询为O1
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


        public static CoroutineHandle Run(IEnumerator cor)
        {
            CoroutineHandle handle = new CoroutineHandle();
            CoroutineDriver driver = CoroutineDriver.Create(cor, handle);
            handle.SetDriver(driver, Time.time);
            waitAdds.Add(driver);
            return handle;
        }

        public static void Stop(CoroutineHandle handle)
        {
            if (handle?.driver == null) return;
            waitRemoves.Add(handle.driver);
            handle.driver = null;
        }

        private static void RemoveCoroutine()
        {
            //删除时注意,如果使用者在协程中停止自己,会重复添加到Removes列表中,目前暂时用逻辑判断,考虑是否改为HashSet
            foreach (CoroutineDriver driver in waitRemoves)
            {
                drivers.Remove(driver);
                if (!driver.isComplete)
                {
                    driver.Completed();
                }
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
            RemoveCoroutine();
            AddCoroutine();
            foreach (CoroutineDriver driver in drivers)
            {
                if (driver.Update(deltaTime)) continue;
                //driver.Completed();
                waitRemoves.Add(driver);
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