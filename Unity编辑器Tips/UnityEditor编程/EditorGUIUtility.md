> ```c#
> EditorGUIUtility.PingObject(sourceObject);
> ```
>
> 在场景中高亮一个对象，就像在Inspector中点击它一样。
>
> PingObject 会使层次结构高亮显示被 ping 的对象。被ping的对象不一定要被选中。例如GameObject.Find可以用来定位要ping的对象。

> ```c#
> EditorGUIUtility.labelWidth
> ```
>
> 保留给Editor GUI控件标签的宽度（以像素为单位）。
>
> 编辑器GUI控件为标签分配了一定的宽度。 可以通过将labelWidth设置为其他值来更改此宽度。 将其设置为0会将标签宽度重置为默认值。 默认值可能会有所不同，例如，取决于Inspector窗口的宽度。 

> ```c#
> EditorGUIUtility.singleLineHeight
> ```
>
> 获取用于单个Editor控件（例如单行EditorGUI.TextField或EditorGUI.Popup）的高度。
>
> 创建自己的多行控件（例如，具有多个字段的自定义类的控件）时，可以使用[EditorGUILayout.GetControlRect](EditorGUILayout.GetControlRect.html)并传入一个高度值，该高度值是[EditorGUIUtility.singleLineHeight的倍数](EditorGUIUtility-singleLineHeight.html)。在对特定像素值进行硬编码时，建议这样做。另请参见：[EditorGUILayout.GetControlRect](EditorGUILayout.GetControlRect.html)。

 