```c#
public class DataS
{
    private EventWaitHandle m_waitHandle;
    internal EventWaitHandle WaitHandle
    {
        get
        {
            if (m_waitHandle == null)
                m_waitHandle =
                    new EventWaitHandle(false, EventResetMode.ManualReset);
            m_waitHandle.Reset();
            return m_waitHandle;
        }
    }
}
public static void Main(string[] args)
{
    var data = new DataS();
    var handle = data.WaitHandle;
    Task.Factory.StartNew(o =>
    {
        var asyncOperation = o as DataS;
        if (asyncOperation == null)
            return default;
        handle.WaitOne();
        Console.WriteLine("我解锁了线程");
        return asyncOperation;
    }, data);
    Console.ReadLine();
    handle.Set();
    Console.ReadLine();
}
```

一个简单的使用此类的线程同步例子。