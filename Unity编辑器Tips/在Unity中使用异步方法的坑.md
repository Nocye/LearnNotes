因为unity使用的是mono环境 和原生c#略有不同 在使用 **Task.WaitAny(params Task[] tasks)** 这类阻塞方法时,会导致unity线程直接卡死,从而无法去完成等待中的Task对象.

在unity中如果需要使用类似方法,应该使用 **Task.WhenAny(params Task[] tasks)**  异步等待需要执行的Task

```c#
await Task.WhenAny(params Task[] tasks)
```

这个方法可以写成

```c#
async Task Say(){
	await Task.Delay(2000);
	Debug.Log("等待完毕")
}
await Task.WhenAny(Say());
```

这样会造成一种误解,认为方法新开了一个线程去执行参数方法,实际上WhenAny方法只是获取了Say方法返回的Task对象,在新线程上等待这个Task的执行完毕;

c#异步的基本原理为遇到await修饰符时,另开一个线程运行await等待的语句,同时标记当前运行的语句位置,然后返回方法调用处,执行其他语句,当await语句执行完毕时,再回到之前标记的位置,继续执行语句

和协程的原理类似,只是等待是在其他线程的执行的,等待结束后再切回主线程执行剩余语句.

**注意unity不支持在其他线程访问unity相关的API** 