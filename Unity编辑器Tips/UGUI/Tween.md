DoTween关键函数:

**TweenManager.GetTweener** 

创建一个Tween，并添加到active列表中，如果池里有剩余的tween，从池中取，如果大于池则扩容。创建时添加到ActiveTween列表中。

**Tweener.Setup** 

创建Tween调用这个方法，根据DoTween全局设置初始化设置这个Tween。并加载对应的插件Plugin。

DoTween根据传入的参数类型去plugin列表中寻找对应的Tween方法：

 **PluginsManager.GetDefaultPlugin<T1, T2, TPlugOptions>();**

这个方法根据T1和T2的类型去寻找对应的Plugin。具体的Tween方法在plugin中执行

