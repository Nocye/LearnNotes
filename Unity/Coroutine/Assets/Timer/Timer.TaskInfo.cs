using System;
using NReferencePool;
using UnityEngine;

namespace Timer
{
    public partial class Timer
    {
        private class TaskInfo : IComparable<TaskInfo>, IEquatable<TaskInfo>, IReference
        {
            public float Time;
            public Action Task;

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


            public bool Equals(TaskInfo other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Time.Equals(other.Time) && Equals(Task, other.Task);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((TaskInfo) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (Time.GetHashCode() * 397) ^ (Task != null ? Task.GetHashCode() : 0);
                }
            }

            public void Clear()
            {
                this.Time = 0;
                this.Task = null;
            }

            public int CompareTo(TaskInfo other)
            {
                if (ReferenceEquals(this, other)) return 0;
                if (ReferenceEquals(null, other)) return 1;
                return Time.CompareTo(other.Time);
            }
        }
    }
}