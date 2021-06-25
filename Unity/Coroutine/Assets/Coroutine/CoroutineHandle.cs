using System;
using NReferencePool;

namespace NCoroutine
{
    public sealed class CoroutineHandle 
    {
        internal CoroutineDriver driver;
        internal void SetDriver(CoroutineDriver driver, float startTime)
        {
            this.driver = driver;
        }
    }
}