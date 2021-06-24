namespace NCoroutine
{
    public abstract class BaseWait
    {
       public abstract bool IsCompleted { get; }
       public abstract bool Update(float deltaTime);
    }
}