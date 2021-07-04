using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NReferencePool;
using UnityEngine;

namespace Timer
{
    public partial class Timer
    {
        private MinimumHeap<TaskInfo> heap = new MinimumHeap<TaskInfo>();


        public void AddDelayTask(Action task, float delay)
        {
            var taskInfo = TaskInfo.Create(delay + Time.time, task);
            heap.Enqueue(taskInfo);
        }

      
        public void Update()
        {
            TaskInfo temp = heap.Peek();
            //可能存在同一时间完成多个任务的情况
            while (temp != null && temp.Time <= Time.time)
            {
                temp.Task?.Invoke();
                heap.Dequeue();
                temp = heap.Peek();
            }
        }
    }
}