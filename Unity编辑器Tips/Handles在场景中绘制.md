# [Handles](https://docs.unity3d.com/cn/2019.4/ScriptReference/Handles.html)

## 描述

场景视图中的自定义 3D GUI 控件和绘制操作。

手柄是 Unity 用于操作场景视图中的项的 3D 控件。内置的 Handle GUI 有很多，如通过变换组件定位、缩放和旋转对象的熟悉的工具。不过，您也可以自行定义 Handle GUI，以与自定义组件编辑器结合使用。此类 GUI 对于编辑以程序方式生成的场景内容、“不可见”项和相关对象的组（如路径点和位置标记）非常实用。

您还可以使用覆盖在场景视图上的 2D 按钮和其他控件来补充场景中的 3D 手柄 GUI。这是通过将标准 Unity GUI 调用封装在 [Editor.OnSceneGUI](https://docs.unity3d.com/cn/2019.4/ScriptReference/Editor.OnSceneGUI.html) 函数中的 [Handles.BeginGUI](https://docs.unity3d.com/cn/2019.4/ScriptReference/Handles.BeginGUI.html) 和 [Handles.EndGUI](https://docs.unity3d.com/cn/2019.4/ScriptReference/Handles.EndGUI.html) 对中完成的。可以使用 [HandleUtility.GUIPointToWorldRay](https://docs.unity3d.com/cn/2019.4/ScriptReference/HandleUtility.GUIPointToWorldRay.html) 和 [HandleUtility.WorldToGUIPoint](https://docs.unity3d.com/cn/2019.4/ScriptReference/HandleUtility.WorldToGUIPoint.html) 在 2D GUI 与 3D 世界坐标之间转换坐标。

一个比较常用的做法是绘制物体显示的名字和信息,

在挂载物体的脚本上OnDrawGizmos方法中调用Handles.Label

