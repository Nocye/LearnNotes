using System.Collections;
using System.Collections.Generic;
using NReferencePool;
using UnityEngine;

namespace NCoroutine
{
    public static class Coroutine
    {
        //这里最优的存储应该是参考dotweene内部的数组方式,需要一种查询为O1
        private static readonly List<CoroutineDriver> adds;
        private static readonly List<CoroutineDriver> handles;
        private static readonly List<CoroutineDriver> removes;


        private static readonly CoroutineDevice device;
        private static readonly HashSet<CoroutineHandle> waitRemove;

        static Coroutine()
        {
            handles = new List<CoroutineDriver>(20);
            removes = new List<CoroutineDriver>(20);
            adds = new List<CoroutineDriver>(10);
            waitRemove = new HashSet<CoroutineHandle>();
            GameObject obj = new GameObject {hideFlags = HideFlags.HideAndDontSave};
            Object.DontDestroyOnLoad(obj);
            device = obj.AddComponent<CoroutineDevice>();
            device.coroutineUpdate += Update;
        }


        public static CoroutineHandle Run(IEnumerator cor)
        {
            CoroutineHandle handle = new CoroutineHandle();
            CoroutineDriver driver = CoroutineDriver.CreateDriver(cor, handle);
            handle.SetDriver(driver, Time.time);
            adds.Add(driver);
            return handle;
        }

        public static void Stop(CoroutineHandle handle)
        {
            if (handle?.driver == null ) return;
            removes.Add(handle.driver);
            handle.driver = null;
        }

        private static void RemoveCoroutine()
        {
            foreach (CoroutineDriver driver in removes)
            {
                handles.Remove(driver);
                ReferencePool.Release(driver);
            }
            removes.Clear();
        }

        private static void AddCoroutine()
        {
            handles.AddRange(adds);
            adds.Clear();
        }

        private static void Update(float deltaTime)
        {
            RemoveCoroutine();
            AddCoroutine();
            foreach (CoroutineDriver driver in handles)
            {
                if (driver.Update(deltaTime)) continue;
                DriverComplete(driver);
                removes.Add(driver);
            }
        }

        private static void DriverComplete(CoroutineDriver driver)
        {
            driver.handle.driver = null;
            driver.handle = null;
            driver.isComplete = true;
            driver.awaiter?.Complete();
        }
    }


    internal sealed class WaitInternalDriver : IWaitable
    {
        private CoroutineDriver driver;

        public bool IsComplete => driver.isComplete;

        void IWaitable.Update(float deltaTime)
        {
        }

        void IReference.Clear()
        {
            driver = null;
        }

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

        public bool IsComplete => baseWait.IsCompleted;

        void IWaitable.Update(float deltaTime)
        {
            baseWait?.Update(deltaTime);
        }

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
        public bool IsComplete => operation.isDone;

        void IWaitable.Update(float deltaTime)
        {
        }

        void IReference.Clear()
        {
            operation = null;
        }

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

        public bool IsComplete => elapsedTime >= time.duration;

        void IWaitable.Update(float deltaTime)
        {
            if (!IsComplete) elapsedTime += deltaTime;
        }

        void IReference.Clear()
        {
            elapsedTime = 0;
            time = null;
        }

        internal static WaitTimer Create(WaitForTime waitForTime)
        {
            WaitTimer waitTimer = ReferencePool.Acquire<WaitTimer>();
            waitTimer.time = waitForTime;
            return waitTimer;
        }
    }
}