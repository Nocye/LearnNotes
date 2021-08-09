![](https://raw.githubusercontent.com/Nocye/ImageBed/master/20200720114911.jpg)

[await表达式是如何处理的？](https://github.com/dotnet/csharplang/blob/main/spec/expressions.md#await-expressions) 

如果想要自定义等待类型,需要实现 **Awaitable** 可等待类型,即

```c#
public bool IsCompleted { get; }
public void OnCompleted(Action continuation);//CIL传入的委托,记录异步方法等待结束后的操作,可以理解为一个方法指针,指向异步方法的await之后的语句块
public T GetResult();//可以为void,代表一个没有返回值的异步操作
```

自定义异步操作完成时的调用方法,完成时需要把 IsCompleted的值置为true ,同时调用OnCompleted传入的action 

**c#部分Task的原理是在新的线程等待阻塞的同步方法,让主线程不会阻塞**

c#做了一些处理使得await上下文的代码始终跑在同一线程上,原理部分需要之后学习,C#的异步语法和unity的协程是不同的东西,用法也不一样,task不建议你取消,task设计的本意是让阻塞方法不阻塞主线程,停止一个阻塞方法并无意义,unity中除I/O密集的地方外都建议使用自带的协程

使用**TaskCompletionSource**可以创建一个非常简单的task，在其他地方调用SetResult，就可以主动完成这个Task



##### 异步的返回值

当一个返回Task<T>的异步方法中，等待了其他异步操作，且这些异步操作的返回值与T并非同一类型。

```c#
public async Task<int> Result()
{
    await Task.Run<int>(() => { return 10; });
    await Task.Run<string>(() => { return "123456"; });

    return 10;
}
```

初始异步时有一个误解，认为遇见await时，就会返回这个await等待的task，实际并非如此，这个方法在第一个task和第二个task等待返回时依然是返回一个Task<int>，但是这个Task的状态是未完成的 ，暂时无法获得返回值。也就是说这些方法中的task是最外部Task<int>的子task。

