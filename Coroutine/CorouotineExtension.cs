namespace NCoroutine
{
    public static class CorouotineExtension
    {
        public static CoroutineAwaiter GetAwaiter(this CoroutineHandle handle)
        {
            var awaiter = new CoroutineAwaiter();
            handle.driver.awaiter = awaiter;
            return awaiter;
        }
    }
}