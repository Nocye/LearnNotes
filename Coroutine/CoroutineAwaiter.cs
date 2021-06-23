using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NCoroutine
{
    [StructLayout(LayoutKind.Auto)]
    public class CoroutineAwaiter : ICriticalNotifyCompletion
    {
        public void GetResult()
        {
           
        }

        public bool IsCompleted => isComplete;
        private Action onComplete;
        private bool isComplete;

        internal void Set()
        {
            isComplete = true;
            onComplete?.Invoke();
        }

        public void OnCompleted(Action continuation)
        {
            onComplete = continuation;
        }

        public void UnsafeOnCompleted(Action continuation)
        {
            onComplete = continuation;
        }
    }
}