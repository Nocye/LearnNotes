namespace NCoroutine
{
    public static class CorouotineExtension
    {
        public static CoroutineAwaiter GetAwaiter(this CoroutineHandle handle)
        {
            CoroutineAwaiter awaiter = new CoroutineAwaiter();
            if (handle.driver is {isComplete: false})
            {
                handle.driver.awaiter = awaiter;
            }
            else if (handle.driver == null || handle.driver.isComplete)
            {
                awaiter.Set();
            }

            return awaiter;
        }
    }
}