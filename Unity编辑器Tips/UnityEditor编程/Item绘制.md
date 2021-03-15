```c#
EditorApplication.hierarchyWindowItemOnGUI
```

在Hierarchy窗口中的每个物体绘制的方法，这个方法是个委托，传入物体的InstanceID和当前item的矩形范围。

InstanceID可以通过EditorUtility.InstanceIDToObject() 来获得id对应的Object。

```c#
EditorApplication.projectWindowItemOnGUI
```

与上一个方法用法相同，不同的是这个方法传入的是资源的GUID。

