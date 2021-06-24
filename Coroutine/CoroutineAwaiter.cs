using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NCoroutine
{
    [StructLayout(LayoutKind.Auto)]
    public class CoroutineAwaiter : ICriticalNotifyCompletion
    {
        private bool isComplete;
        private Action onComplete;

        public bool IsCompleted => isComplete;

        public void OnCompleted(Action continuation)
        {
            onComplete = continuation;
        }

        public void UnsafeOnCompleted(Action continuation)
        {
            onComplete = continuation;
        }

        public void GetResult()
        {
        }

        internal void Set()
        {
            isComplete = true;
            onComplete?.Invoke();
        }
    }
}