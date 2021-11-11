通过LoadAsset重复加载一个资源，Unity底层并不会重复加载，会缓存你已经加载的资源，所以不用担心Load多次会造成内存增加问题。

使用新版SBP管线打出的包，在有address的情况下只能通过Address作为key来load，且必须保证大小写一致。

在测试字体依赖时，发现Unity是根据AB包中的依赖信息在底层寻找抵赖的包是否已加载，而不是根据资源去寻找。

关于异步和同步加载的问题  参考了一篇UWA问答 [AssetBundle异步加载被中断的问题](https://answer.uwa4d.com/question/5af3db530e95a527a7a81d31) 和Unity文档

># [AssetBundleCreateRequest](https://docs.unity3d.com/ScriptReference/AssetBundleCreateRequest.html).assetBundle
>
>Leave feedback
>
>public [AssetBundle](https://docs.unity3d.com/ScriptReference/AssetBundle.html) **assetBundle**;
>
>### Description
>
>Asset object being loaded (Read Only).
>
>Note that accessing asset before [isDone](https://docs.unity3d.com/ScriptReference/AsyncOperation-isDone.html) is true will stall the loading process.
>
>如果你在isDone之前访问了这个属性，那么加载就会转为同步，Lock到加载完成

根据有源码的大佬回复，unity底层会锁住这个调用线程，直到AB包加载完成，达成同步加载的效果。
