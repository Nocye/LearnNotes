![](https://raw.githubusercontent.com/Nocye/ImageBed/master/20200720114911.jpg)

如果想要自定义等待类型,需要实现 **TaskAwaiter** 的鸭子属性,即

```c#
public bool IsCompleted { get; }
public void OnCompleted(Action continuation);//CIL传入的委托,记录异步方法等待结束后的操作,可以理解为一个方法指针,指向异步方法的await之后的语句块
public T GetResult();//可以为void,代表一个没有返回值的异步操作
```

自定义异步操作完成时的调用方法,完成时需要把 IsCompleted的值置为true ,同时调用OnCompleted传入的action 

**c#部分Task的原理是在新的线程等待阻塞的同步方法,让主线程不会阻塞**

c#做了一些处理使得await上下文的代码始终跑在同一线程上,原理部分需要之后学习,C#的异步语法和unity的协程是不同的东西,用法也不一样,task不建议你取消,task设计的本意是让阻塞方法不阻塞主线程,停止一个阻塞方法并无意义,unity中除I/O密集的地方外都建议使用自带的协程
