```c#
Dictionary<string, List<ObjectIdentifier>> FileToObjects;
```

key是资源资源包的内部名称，value是资源包中的资源。

```c#
Dictionary<GUID, List<string>> AssetToFiles
```

key为资源所有打包资源的guid，value是这个资源依赖的AB包列表(包括自身所在的AB包)

```c#
Dictionary<string, string> FileToBundle
```

AB包的内部名称到实际名称的映射，key是内部名，value是实际名

