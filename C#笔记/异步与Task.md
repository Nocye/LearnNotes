![](https://raw.githubusercontent.com/Nocye/ImageBed/master/20200720114911.jpg)

如果想要自定义等待类型,需要实现 **TaskAwaiter** 的鸭子属性,即

```c#
public bool IsCompleted { get; }
public void OnCompleted(Action continuation);//CIL传入的委托,记录异步方法等待结束后的操作,可以理解为一个方法指针,指向异步方法的await之后的语句块
public T GetResult();//可以为void,代表一个没有返回值的异步操作
```

自定义异步操作完成时的调用方法,完成时需要把 IsCompleted的值置为true ,同时调用OnCompleted传入的action 

**c#部分Task的原理是在新的线程等待阻塞的同步方法,让主线程不会阻塞**

实际上await并非会切换线程
