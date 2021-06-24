using System.Collections;
using System.Collections.Generic;
using NReferencePool;
using UnityEngine;

namespace NCoroutine
{
    public static class Coroutine
    {
        //这里最优的存储应该是参考dotweene内部的数组方式
        private static readonly List<CoroutineHandle> adds;
        private static readonly List<CoroutineHandle> handles;
        private static readonly List<CoroutineHandle> removeIndexes;
        private static List<CoroutineDriver> removes;

        private static readonly CoroutineDevice device;
        private static readonly HashSet<CoroutineHandle> waitRemove;

        static Coroutine()
        {
            handles = new List<CoroutineHandle>(20);
            removeIndexes = new List<CoroutineHandle>(20);
            adds = new List<CoroutineHandle>(10);
            waitRemove = new HashSet<CoroutineHandle>();
            GameObject obj = new GameObject {hideFlags = HideFlags.HideAndDontSave};
            Object.DontDestroyOnLoad(obj);
            device = obj.AddComponent<CoroutineDevice>();
            device.coroutineUpdate += Update;
        }

        public static CoroutineHandle Run(IEnumerator cor)
        {
            CoroutineDriver driver = new CoroutineDriver(cor);
            var handle = ReferencePool.Acquire<CoroutineHandle>();
            handle.SetDriver(driver, Time.time);
            adds.Add(handle);
            return handle;
        }

        public static void Stop(CoroutineHandle handle)
        {
            if (handle != null)
            {
                if (!removes.Contains(handle.driver)) removes.Add(handle.driver);
            }
        }

        private static void Update(float deltaTime)
        {
            for (int i = 0; i < removeIndexes.Count; i++)
            {
                //removeIndexes[i].driver = null;
                handles.Remove(removeIndexes[i]);
                ReferencePool.Release(removeIndexes[i]);
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


    internal class WaitInternalDriver : IWaitable
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

        internal void SetDriver(CoroutineDriver driver)
        {
            this.driver = driver;
        }
    }

    internal class WaitCustom : IWaitable
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

        internal void SetCustom(BaseWait baseWait)
        {
            this.baseWait = baseWait;
        }
    }

    internal class WaitOperation : IWaitable
    {
        private bool isDone;
        private AsyncOperation operation;
        public bool IsComplete => isDone;

        void IWaitable.Update(float deltaTime)
        {
        }

        void IReference.Clear()
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

        internal void SetTime(WaitForTime time)
        {
            this.time = time;
        }
    }
}