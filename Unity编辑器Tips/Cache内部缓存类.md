[文档](https://docs.unity3d.com/cn/current/ScriptReference/Caching.html)

这个类主要是用来管理使用UnityWebRequestAssetBundle下载的AB包缓存，比如addressable就用到了这个类来缓存

例子：修改从远端下载的AB包缓存到项目目录

```c#
string path = Path.Combine(Directory.GetCurrentDirectory(), "Cache");
Cache cache = Caching.AddCache(path);
Caching.currentCacheForWriting = cache;
```

缓存文件夹中都是一些未知数据，解密这些数据的性能尚不清楚，官方推荐是能通过AssetBundle.LoadFromFile就不要通过网络