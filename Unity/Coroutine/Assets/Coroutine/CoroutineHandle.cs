using System;
using NReferencePool;

namespace NCoroutine
{
    public sealed class CoroutineHandle 
    {
        internal CoroutineDriver driver;
        internal CoroutineAwaiter awaiter;
    }
}