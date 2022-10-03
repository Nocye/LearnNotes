想要让异步方法的返回值是自己的自定义类型，需要实现 AsyncMethodBuilder 这个Attribute（特性），编写一个Builder类让编译器知道如何编译一个异步状态机。

一个方法内部的多次await 可以被一个Task Like的返回值所描述 

编译方法时会生成一个状态机，这个状态机通过上文的特性来构造一个状态机，状态机内部会包含一个叫Task的awaiter字段，方法返回的就是这个字段，在状态机内部的其他Task执行完毕之后，会调用状态机Task的SetResult ，这时如果外部有Task嵌套，就会进入下一个状态机的MoveNext函数中执行。这也是为什么异步有传染性的原因。

异步流程

1. 进入方法 创建状态机，执行状态机的Start方法。
   1. Start内部执行一次MoveNext，每个await都是一个状态机状态，执行到第一个await时，获取awaiter类型（一般是Task），调用Builder的函数，给当前这个awaiter添加coutine委托（MoveNext）。
2. 返回状态机内部的Task。
3. awaiter执行完毕，回调回状态机，如果没有其他awaiter，执行状态机内部Task的SetResult。
4. 如果是嵌套异步方法，这时SetResult内部会执行上一层状态机的coutine委托，进入上层状态机的MoveNext，内部会调用这层Task的GetResult来获取结果。

Task会啥会有吞异常的情况？ ETTask，UniTask是如何处理的？

异步状态机会把异步方法中的代码块包裹一层try catch执行，当遇见错误时，调用Builder的SetException方法，把捕获的错误传入，所以具体的错误处理，是靠Builder去处理的。

ETTask：直接调用Builder内部的Task SetException方法，内部把保留这个错误，如果这个方法是被await等待，那么上层的状态机内部GetResult时就会抛出这个错误，如果没有被等待这个错误就不会有任何处理，ETTask使用Coroutine函数把不需等待的的方法包裹一下，使用ETVoid构造上层状态机，调用ETVoid Builder的SetException ，内部也很简单 有一个全局委托来处理错误

```c#
public void SetException(Exception e)
{
    ETTask.ExceptionHandler.Invoke(e);
}
```

UniTask：和ETVoid类似 也有一个UniTaskVoid来辅助不需等待的异步方法，在SetException的时候直接打印日志

```c#
 public void SetException(Exception exception)
        {
            // runner is finished, return first.
            if (runner != null)
            {
#if ENABLE_IL2CPP
                // workaround for IL2CPP bug.
                PlayerLoopHelper.AddContinuation(PlayerLoopTiming.LastPostLateUpdate, runner.ReturnAction);
#else
                runner.Return();
#endif
                runner = null;
            }

            UniTaskScheduler.PublishUnobservedTaskException(exception);
        }
```

ETTask 在没有使用Coroutine方法时抛出错误，不会有任何处理。 同步调用异步方法编译器也会有警告，作者说了编译工具会把异步警告视为错误，防止编码遗漏。

UniTask 的容错方法比较骚 如果方法内部不需等待同步执行 没有生成runnerPromise ，状态机返回Task时会在内部调用 UniTask.FromException(ex)  用ExceptionResultSource这个类保存Exception 在上层状态机调用GetResult时抛出，如果同步执行没有上层状态机，那么在GC调用析构函数时抛出。试验了一下 Unity是否打开增量GC 会影响到他的抛出时机，认为只是做了一个容错，依然不推荐这么使用。最好使用ForGet包裹 。在内部等待其他方法执行时会生成一个runnerPromise  最后会执行到 UniTaskCompletionSourceCore.TrySetException()  

```c#
if (continuation != null || 
    //这段代码没看懂，如果continuation为空，那么CompareExchange返回的也一定是空，为啥要用||呢？
    Interlocked.CompareExchange(ref this.continuation, UniTaskCompletionSourceCoreShared.s_sentinel, null) != null)
{
    continuation(continuationState);
    return true;
}
```

UniTask的ForGet方法，给UniTask的OnCompleted添加一个回调 手动调一下GetResult方法