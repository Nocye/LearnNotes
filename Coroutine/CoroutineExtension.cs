using System;

namespace NCoroutine
{
    public static class CoroutineExtension
    {
        public static CoroutineAwaiter GetAwaiter(this CoroutineHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentException("handle is null");
            }

            CoroutineAwaiter awaiter = new CoroutineAwaiter();
            if (handle.driver is {isComplete: false})
            {
                handle.driver.awaiter = awaiter;
            }
            else if (handle.driver == null || handle.driver.isComplete)
            {
                awaiter.Complete();
            }

            return awaiter;
        }
    }
}