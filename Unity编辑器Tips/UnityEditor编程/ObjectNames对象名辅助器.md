## 用于辅助编辑器下，对Object对象名称方便操作的类



##### **ObjectNames.NicifyVariableName (string name);**

此函数将在大写字母之前插入空格，并删除名称之前的可选 `m_`、`_` 或 `k`（后跟大写字母）。

在Mono脚本中序列化显示一个字段时，应该就是通过这个方法修改的字段名。

```c#
// prints "My Variable"
print(ObjectNames.NicifyVariableName("MyVariable"));
// prints "The Other Variable"
print(ObjectNames.NicifyVariableName("m_TheOtherVariable"));
// prints "Some Constant"
print(ObjectNames.NicifyVariableName("kSomeConstant"));	
```



##### ObjectNames.GetClassName(UnityEngine.Object obj);

获取对象的类型名

游戏物体和预制体为GameObject，脚本为MonoScript，其他资源比如文本为TextAsset，图片为Texture2D，音乐为AudioClip等，都是Unity的默认资源格式，如果是Unity不识别的资源，为DefaultAsset。



##### ObjectNames.GetInspectorTitle(UnityEngine.Object);

获取对象在检视面板上显示的名字，如果是游戏物体，则只返回物体名。如果是脚本，资源等，返回文件名，和括起来的文件类型，具体的文件类型规则同与 **ObjectNames.GetClassName **相同。



##### ObjectNames.GetDragAndDropTitle (Unity Engine.Object);

与 **ObjectNames.GetInspectorTitle** 类似，不同之处在于如果传入的是游戏物体，那么也会返回文件类型。



##### **ObjectNames.SetNameSmart(UnityEngine.Object , string name);**

设置对象名称。

如果对象为资源，则重命名资源和文件名以匹配对象。但如果有重名的资源，则这个方法不会生效。