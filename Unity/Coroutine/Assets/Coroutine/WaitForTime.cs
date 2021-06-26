namespace NCoroutine
{
    public sealed class WaitForTime
    {
        internal float duration;
        internal bool ignoreTimeScale;

        public WaitForTime(float duration, bool ignoreTimeScale = true)
        {
            this.duration = duration;
            this.ignoreTimeScale = ignoreTimeScale;
        }
    }
}