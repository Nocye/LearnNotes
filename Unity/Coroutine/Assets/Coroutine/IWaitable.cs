namespace NCoroutine
{
    internal interface IWaitable : NReferencePool.IReference
    {
        bool IsComplete { get; }
        void Update(float deltaTime);
    }
}