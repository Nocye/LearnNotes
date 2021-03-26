在AddressableAssetsData中的Default Local Group设置中的AssetProvider可以看到当前对于资源的处理使用的脚本的名称

默认为BundledAssetProvider(显示为Assets from Bundles Provider)，以及AssetBundleProvider，都是继承了IResourceProvider这个接口，这个接口的所有子类都是对不同的资源加载方式进行封装。

关于Addressables的Relase方法，就可以在AssetBundleProvider中看见，实际上就是调用了对应AssetBundle的Unload函数，需要注意的是默认传入的值为true，所以会切断所有当前使用这个资源的引用。

关于使用Addressables的情况下，需要和Resources.Unload()，Resources.UnloadUnusedAssets()配合使用。

一般来说Addressables都是封装的一层AB，但是无法有AB这么细致的颗粒度，那么假如我有某个预制体中携带了某种Asset，现在我想单独卸载这个Asset而不卸载这个预制体，通过Addressables.Relase()是无法卸载的，这时这个Asset视为一个普通的Unity资源，配合Resources.Unload来切断他的所有引用，再通过Resources.UnloadUnusedAssets来卸载。因为AB和Resources的卸载具体实现都在C++层，无法具体的看到实现，姑且猜测一下，AB加载完后和Resources会比较类似，都有一套引用计数的管理，或者说本质上就是同一个东西，这样Resources才可以卸载AB包。

###  Addressable的Task

用task语法，写起来很爽，不免好奇，难道官方已经完美支持了Task加载资源？

```c#
//线程同步事件
System.Threading.EventWaitHandle m_waitHandle;
internal System.Threading.WaitHandle WaitHandle
{
    get
    {
        if (m_waitHandle == null)
            m_waitHandle = new System.Threading.EventWaitHandle(false, System.Threading.EventResetMode.ManualReset);
        //在这里加锁，因为task在别的线程，所以锁住的不会是主线程
        m_waitHandle.Reset();
        return m_waitHandle;
    }
}

var handle = WaitHandle;
return System.Threading.Tasks.Task.Factory.StartNew((Func<object, TObject>)(o =>
{
    var asyncOperation = o as AsyncOperationBase<TObject>;
    if (asyncOperation == null)
        return default(TObject);
    在这里锁死这个task，也就假装task是在异步运行中
    handle.WaitOne();
    return (TObject)asyncOperation.Result;
}), this);
//资源加载完毕后的回调，在这个回调中解除task线程的锁
internal void InvokeCompletionEvent()
{
    if (m_CompletedActionT != null)
    {
        m_CompletedActionT.Invoke(new AsyncOperationHandle<TObject>(this));
        m_CompletedActionT.Clear();
    }
    //解锁操作
    if (m_waitHandle != null)
        m_waitHandle.Set();
    m_InDeferredCallbackQueue = false;
}
```

这几段代码就比较明显了，Addressable底层还是通过AssetBundle的API来加载，但是官方给你包装成可以使用异步Task语法来编程，实际上是假的异步，所谓的等待Task并没有任何意义。