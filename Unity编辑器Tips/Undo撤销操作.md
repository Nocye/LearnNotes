# [Undo](https://docs.unity3d.com/cn/2019.4/ScriptReference/Undo.html)

## 描述

让您可以针对要执行更改的特定对象注册撤销操作。

比如对编辑器扩展的一些操作可以使用这个类来进行,方便撤回

撤销系统可以在撤销堆栈中存储增量更改。

系统会根据事件自动将多个撤销操作组合在一起，例如，根据鼠标按下事件拆分撤销组。分组后的撤销操作将作为单个撤销操作出现和使用。要手动控制分组方法，请使用 [Undo.IncrementCurrentGroup](https://docs.unity3d.com/cn/2019.4/ScriptReference/Undo.IncrementCurrentGroup.html)。

默认情况下，系统将按照不同类型操作的硬编码顺序，从属于该组的各项操作中选择 UI 中显示的名称。要手动设置名称，请使用 [Undo.SetCurrentGroupName](https://docs.unity3d.com/cn/2019.4/ScriptReference/Undo.SetCurrentGroupName.html)。

撤销操作会存储每个属性或每个对象的状态。这样，如论场景的大小如何，它们都可以正确缩放。

最重要的几项操作如下所述：

修改单个属性：\ `Undo.RecordObject (myGameObject.transform, "Zero Transform Position");`\ `myGameObject.transform.position = Vector3.zero;`

添加组件：\ `Undo.AddComponent<RigidBody>(myGameObject);`

创建新的游戏对象：\ `var go = new GameObject();`\ `Undo.RegisterCreatedObjectUndo (go, "Created go");`

销毁游戏对象或组件：\ `Undo.DestroyObjectImmediate (myGameObject);`

更改变换组件的父子化：\ `Undo.SetTransformParent (myGameObject.transform, newTransformParent, "Set new parent");`