using System;
using NReferencePool;

namespace NCoroutine
{
    public sealed class CoroutineHandle : IReference, IEquatable<CoroutineHandle>
    {
        internal CoroutineDriver driver;
        internal float startTime;
        public bool Equals(CoroutineHandle other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(driver, other.driver) && startTime.Equals(other.startTime);
        }

        public void Clear()
        {
            driver = null;
            startTime = 0;
        }

        internal void SetDriver(CoroutineDriver driver, float startTime)
        {
            this.driver = driver;
            this.startTime = startTime;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is CoroutineHandle other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((driver != null ? driver.GetHashCode() : 0) * 397) ^ startTime.GetHashCode();
            }
        }
    }
}