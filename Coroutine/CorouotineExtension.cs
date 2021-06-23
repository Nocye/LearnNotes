namespace NCoroutine
{
    public static class CorouotineExtension
    {
        public static CoroutineAwaiter GetAwaiter(this CoroutineHandle handle)
        {
            var awaiter = new CoroutineAwaiter();
            if (handle.driver != null && !handle.driver.isComplete)
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