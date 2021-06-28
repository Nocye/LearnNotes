using System;
using UnityEngine;

namespace NCoroutine
{
    public sealed class WaitForTime
    {
        internal float duration;
        internal bool ignoreTimeScale;

        public WaitForTime(float duration, bool ignoreTimeScale = true)
        {
            this.duration = Mathf.Max(0,duration);
            this.ignoreTimeScale = ignoreTimeScale;
        }
    }
}