namespace NCoroutine
{
    public interface IWaitable : NReferencePool.IReference
    {
        bool IsComplete { get; }
        void Update(float deltaTime);
    }
}