```c#
Dictionary<string, List<ObjectIdentifier>> FileToObjects;
```

key是资源资源包的内部名称，value是资源包中的资源标识符列表。

```c#
Dictionary<GUID, List<string>> AssetToFiles
```

猜测：key为资源所有打包资源的guid，value是这个资源的依赖列表

