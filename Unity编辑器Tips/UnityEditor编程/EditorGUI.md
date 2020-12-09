## 非自动布局的编辑器GUI类,基本需要通过Rect定位

### EditorGUI.PrefixLabel

> | totalPosition | 标签和控件在屏幕上总共要使用的矩形。                   |
> | ------------- | ------------------------------------------------------ |
> | **id**        | **控件的唯一ID。如果没有指定，则使用下一个控件的ID。** |
>| **label**     | **显示在控件前面的标签。**                             |
> | **style**     | **标签的样式。**                                       |
> 
> 创建一个在控件之前显示的标签,返回的是标签的Rect

### EditorGUI.IntSlider

> | **position**   | 滑块在屏幕上使用的矩形。                 |
> | -------------- | ---------------------------------------- |
> | **label**      | **滑块前的可选标签。**                   |
>| **value**      | **滑块显示的值。这决定了可拖动的位置。** |
> | **leftValue**  | **滑块左端的值,最小值**                  |
> | **rightValue** | **滑块右端的值,最大值**                  |
> 
> 创建一个滑动条,返回滑动条获取的值,有SerializedProperty的重载

### new EditorGUI.PropertyScope(position, label, property)

> 创建一个属性封装器，可用于使常规 GUI 控件与 [SerializedProperty](https://docs.unity3d.com/cn/2018.2/ScriptReference/SerializedProperty.html) 配合使用。
> 
> 大多数 [EditorGUI](https://docs.unity3d.com/cn/2018.2/ScriptReference/EditorGUI.html) 和 [EditorGUILayout](https://docs.unity3d.com/cn/2018.2/ScriptReference/EditorGUILayout.html) GUI 控件已具有与 SerializedProperty 配合使用的重载。 但是，对于不处理 SerializedProperty 的 GUI 控件，您可以按以下所示示例将它们封装到 BeginProperty 和 EndProperty 中。 您也可以将其用于自己的自定义 GUI 控件。
>
> 如果在进行多对象编辑时遇到不同的属性值，BeginProperty 和 EndProperty 会自动处理默认标签、加粗预制件重载的字体、还原为预制件右键单击菜单，并在多对象编辑中涉及不同属性值的情况下，将 ·[showMixedValue](https://docs.unity3d.com/cn/2018.2/ScriptReference/EditorGUI-showMixedValue.html) 设为 true。

> ```c#
> EditorGUI.BeginChangeCheck();
> ```
>
> 监听之后的输入控件,比如EditorGUI.TextField()
>
> ```c#
> EditorGUI.EndChangeCheck()
> ```
>
> 与上面的方法成对出现.返回一个bool,只有当这对检查区域中有控件的值改变时才会返回true,可以对输入的值进行一些限定或者其他操作,但是比较繁琐.

> ```c#
> EditorGUI.PropertyField
> ```
>
> | **position**        | 屏幕上用于属性字段的矩形。                                   |
> | ------------------- | ------------------------------------------------------------ |
> | **property**        | **要为其创建控件的SerializedProperty。**                     |
> | **label**           | **要使用的可选标签。如果未指定，则使用属性本身的标签。使用GUIContent.none则不显示标签。** |
> | **includeChildren** | **是否包含子类,默认为false,只画出自身,否则画出所有子类(用处存疑)**, |
>
> 使用它在编辑器中为[SerializedProperty](SerializedProperty.html)创建一个控件。

> ```c#
> public static Object ObjectField(Rect position, GUIContent label, Object obj, Type objType, bool allowSceneObjects);
> ```
>
> ![img](https://raw.githubusercontent.com/Nocye/ImageBed/master/20200825174041.png)
>
> | **position**          | 绘制控件的矩形         |
> | --------------------- | ---------------------- |
> | **label**             | **字段前的可选标签**。 |
> | **obj**               | **字段显示的对象**     |
> | **objType**           | **可分配对象的类型**。 |
> | **allowSceneObjects** | **允许分配场景对象**。 |
>
> 绘制一个编辑器控件,可以通过拖动或者打开对象选择器来分配对象,通过拖拽或者使用对象选择器来分配给字段
>
> ```c#
> public static void ObjectField(Rect position, SerializedProperty property, Type objType, GUIContent label);
> ```
>
> 使用序列化属性的重载,用法同上.

> ```c#
> public static string TextField(Rect position, GUIContent label, string text, GUIStyle style = EditorStyles.textField);
> ```
>
> | **position** | 屏幕上用于文本字段的矩形               |
> | ------------ | -------------------------------------- |
> | **label**    | **可选的标签，显示在文本字段的前面。** |
> | **text**     | **要编辑的文字。**                     |
> | **style**    | **可选的GUI样式。**                    |
>
> 创建一个可输入字符串的控件,返回输入的字符串

> ```c#
> public EditorGUI.DisabledScope (bool disabled);
> ```
>
> ## 参数
>
> | disabled | 布尔值，用于指定是否应禁用组中的控件。 |
> | -------- | -------------------------------------- |
> |          |                                        |
>
> ## 描述
>
> 创建一个新的 DisabledScope 并开始相应的组。

> # DisabledScope
>
> struct in UnityEditor
>
> ## 描述
>
> 创建一组可禁用的控件。
>
> 如果 Disabled 设置为 true，则将禁用组内的控件。 如果为 false，则不会更改 Enabled/Disabled 状态。
>
> 该组不能用于启用最初以其他方式禁用的控件。 这些组可以嵌套，如果子组本身已禁用或父组已禁用， 则子组中的控件将被禁用。
>
> 配合using使用
>
> ```c#
> using(new EditorGUI.DisabledScope(bool)){
> 
> }
> 
> ```
>
> 