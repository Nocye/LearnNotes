```c#
PrefabUtility
```

是unity官方提供的对prefab进行操作的类,

```c#
PrefabUtility.GetPrefabInstanceStatus(UnityEngine.Object componentOrGameObject)
```

获取一个物体的prefab实例状态 返回一个枚举类

```c#
public enum PrefabInstanceStatus
  {
    如果该实例不是prefab  返回该项
    NotAPrefab,
    如果该实例是prefab,返回该项
    Connected,
    这个是一个prefab实例,但是未连接到prefab,返回该项,这是一个旧版功能,新版不使用
    Disconnected,
    这个实例与prefab的链接丢失了,Hierarchy中显示红色的状态,显示该项
    MissingAsset,
  }
```

上个方法返回的枚举



```c#
PrefabUtility.ApplyPrefabInstance(GameObject instanceRoot, InteractionMode action);
```

应用一个prefab实例的修改,等价与apply,注意需要传入prefab实例的根物体,否则无效,不报错 action表示一个交互模式,[官方文档](https://docs.unity3d.com/ScriptReference/InteractionMode.html) 一般使用AutomatedAction 实际的用处需要再了解

```c#
PrefabUtility.SaveAsPrefabAssetAndConnect(
      GameObject instanceRoot,
      string assetPath,
      InteractionMode action);
```

保存一个GameObject到文件夹中,注意无法保存已经是asset文件的预制体



```c#
PrefabUtility.GetCorrespondingObjectFromSource<TObject>(TObject componentOrGameObject) where TObject : UnityEngine.Object;
```

使用该函数获取源实例化的Prefab Asset对象。如果Prefab实例已断开连接，也会从Prefab Asset中返回相应的对象，然后可用于重新连接Prefab实例和Prefab Asset。