# [GUILayout](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.html)

描述

GUILayout 类是 Unity GUI 的另类实现，并且具有自动布局功能。

# [GUILayout](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.html).Space

public static void **Space** (float **pixels**);

### 描述

在当前布局组中插入空白元素。

空白元素的方向取决于发出命令时当前所在的布局组。如果在垂直组中，空白元素将是垂直的。 **注意：**这将覆盖 [GUILayout.ExpandWidth](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.ExpandWidth.html) 和 [GUILayout.ExpandHeight](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.ExpandHeight.html)

![img](https://docs.unity3d.com/cn/2019.4/StaticFiles/ScriptRefImages/GUILayoutSpace.png)\ *两个按钮间 20px 的空白元素。*

# [GUILayout](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.html).FlexibleSpace

public static void **FlexibleSpace** ();

描述

插入灵活的空白元素。

灵活的空白元素将占用布局中的任何剩余空间。

**注意：**这将覆盖 [GUILayout.ExpandWidth](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.ExpandWidth.html) 和 [GUILayout.ExpandHeight](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.ExpandHeight.html)

![img](https://docs.unity3d.com/cn/2019.4/StaticFiles/ScriptRefImages/GUILayoutFlexibleSpace.png)\ *GUILayout 区域中灵活的空白元素。*

# [GUILayout](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.html).ExpandWidth

public static [GUILayoutOption](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayoutOption.html) **ExpandWidth** (bool **expand**);

描述

传递给控件以允许或禁止水平扩展的选项。

如果为 true，则封闭的 UI 元素可以扩展以填充可用的水平宽度。

![img](https://docs.unity3d.com/cn/2019.4/StaticFiles/ScriptRefImages/ExpandWidth.png).

# [GUILayout](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.html).ExpandHeight

public static [GUILayoutOption](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayoutOption.html) **ExpandHeight** (bool **expand**);

描述

传递给控件以允许或禁止垂直扩展的选项。