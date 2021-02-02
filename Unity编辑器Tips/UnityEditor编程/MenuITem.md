创建自定义GameObject：

```c#
	//请在构造时显式指定priority，否则可能会出现不显示的问题
	[MenuItem("GameObject/MyCategory/Custom Game Object", false, 10)]
    static void CreateCustomGameObject(MenuCommand menuCommand)
    {
        // 创建自定义GameObject.
        GameObject go = new GameObject("Custom Game Object");
        // 如果这是一个在一个物体上右击，确保新建的物体作为子物体，否则什么也不做。
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // 在撤销系统中注册
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }
```

在对应的上下文中操作：

```c#
 	// 在Rigidbody的右键菜单中添加一个名为 "Double Mass "的菜单项。
    // 这类菜单前缀必须为 CONTEXT/{控件名}/
    [MenuItem("CONTEXT/Rigidbody/Double Mass")]
    static void DoubleMass(MenuCommand command)
    {
    	// 强转获得当前点击的组件
        Rigidbody body = (Rigidbody)command.context;
        body.mass = body.mass * 2;
        Debug.Log("Doubled Rigidbody's Mass to " + body.mass + " from Context Menu.");
    }
```

菜单项验证方法：

```c#
	// 添加一个菜单项，这个菜单项有一个同名验证方法。
    [MenuItem("MyMenu/Log Selected Transform Name")]
    static void LogSelectedTransformName()
    {
        Debug.Log("Selected Transform is on " + Selection.activeTransform.gameObject.name + ".");
    }   
    
    // 验证方法，返回值一定为bool值，名称一定和上面的方法相同，构造时显式指定为验证方法（isValidateFunction = true）
    // 当这个验证方法返回true时，上面的方法才可用，否则显示为不可点击状态。
    [MenuItem("MyMenu/Log Selected Transform Name", true)]
    static bool ValidateLogSelectedTransformName()
    {
        // 如果没有选择任何TransForm，返回false。
        return Selection.activeTransform != null;
    }
```