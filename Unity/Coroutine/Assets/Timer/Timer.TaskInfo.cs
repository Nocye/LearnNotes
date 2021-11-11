using System;
using System.Collections.Generic;
using NReferencePool;
using UnityEngine;

namespace Timer
{
    public partial class Timer
    {
        internal class TaskInfoCompare : IComparer<TaskInfo>
        {
            public int Compare(TaskInfo x, TaskInfo y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (ReferenceEquals(null, y)) return 1;
                if (ReferenceEquals(null, x)) return -1;
                return x.Time.CompareTo(y.Time);
            }
        }

        internal class TaskInfo : IReference  
        {
            public float Time;
            public Action Task;
            public bool isStop;

            public TaskInfo()
            {
            }

            public static TaskInfo Create(float time, Action task)
            {
                var taskInfo = ReferencePool.Acquire<TaskInfo>();
                taskInfo.Time = time;
                taskInfo.Task = task;
                return taskInfo;
            }


            public void Clear()
            {
                this.Time = 0;
                this.Task = null;
                this.isStop = false;
            }
        }
    }
}