using System;
using NReferencePool;
using UnityEngine;

namespace Timer
{
    public partial class Timer
    {
        private readonly MinimumHeap<TaskInfo> heap = new MinimumHeap<TaskInfo>(new TaskInfoCompare());


        public TimerHandle StartTask(Action task, float delay)
        {
            TaskInfo taskInfo = TaskInfo.Create(delay + Time.time, task);
            heap.Enqueue(taskInfo);
            TimerHandle th = new TimerHandle();
            th.info = taskInfo;
            return th;
        }

        public void StopTask(TimerHandle handle)
        {
            if (handle == null || handle.info == null) throw new ArgumentNullException("handle");

            handle.info.isStop = true;
        }

        public void Update()
        {
            TaskInfo temp = heap.Peek();
            //可能存在同一时间完成多个任务的情况
            while (temp != null && temp.Time <= Time.time)
            {
                if (!temp.isStop) temp.Task?.Invoke();

                heap.Dequeue();
                ReferencePool.Release(temp);
                temp = heap.Peek();
            }
        }
    }
}