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



# [GUILayout](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.html).SelectionGrid

public static int **SelectionGrid** (int **selected**, string[] **texts**, int **xCount**, params GUILayoutOption[] **options**);

public static int **SelectionGrid** (int **selected**, Texture[] **images**, int **xCount**, params GUILayoutOption[] **options**);

public static int **SelectionGrid** (int **selected**, GUIContent[] **content**, int **xCount**, params GUILayoutOption[] **options**);

public static int **SelectionGrid** (int **selected**, string[] **texts**, int **xCount**, [GUIStyle](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUIStyle.html) **style**, params GUILayoutOption[] **options**);

public static int **SelectionGrid** (int **selected**, Texture[] **images**, int **xCount**, [GUIStyle](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUIStyle.html) **style**, params GUILayoutOption[] **options**);

public static int **SelectionGrid** (int **selected**, GUIContent[] **contents**, int **xCount**, [GUIStyle](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUIStyle.html) **style**, params GUILayoutOption[] **options**);

## 参数

| selected | 所选按钮的索引。                                             |
| -------- | ------------------------------------------------------------ |
| texts    | 要在按钮上显示的字符串的数组。                               |
| images   | 按钮上的纹理的数组。                                         |
| contents | 按钮的文本、图像和工具提示的数组。                           |
| xCount   | 在水平方向上放置的元素个数。除非样式定义了要使用的 fixedWidth，否则将缩放元素以适合显示。控件高度将由元素数量决定。 |
| style    | 要使用的样式。如果省略，则使用当前 [GUISkin](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUISkin.html) 的 `button` 样式。 |
| options  | （可选）一个布局选项列表，用于指定额外的布局属性。此处传递的任何值都将覆盖 `style` 定义的设置。 另请参阅：[GUILayout.Width](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.Width.html)、[GUILayout.Height](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.Height.html)、[GUILayout.MinWidth](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.MinWidth.html)、[GUILayout.MaxWidth](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.MaxWidth.html)、[GUILayout.MinHeight](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.MinHeight.html)、 [GUILayout.MaxHeight](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.MaxHeight.html)、[GUILayout.ExpandWidth](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.ExpandWidth.html)、[GUILayout.ExpandHeight](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.ExpandHeight.html)。 |

返回

**int** 所选按钮的索引。

描述

创建一个选择网格。

![img](https://docs.unity3d.com/cn/2019.4/StaticFiles/ScriptRefImages/GUILayoutSelectionGrid.png)\ *游戏视图中的选择网格。*



# [GUILayout](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.html).BeginArea

public static void **BeginArea** ([Rect](https://docs.unity3d.com/cn/2019.4/ScriptReference/Rect.html) **screenRect**);

public static void **BeginArea** ([Rect](https://docs.unity3d.com/cn/2019.4/ScriptReference/Rect.html) **screenRect**, string **text**);

public static void **BeginArea** ([Rect](https://docs.unity3d.com/cn/2019.4/ScriptReference/Rect.html) **screenRect**, [Texture](https://docs.unity3d.com/cn/2019.4/ScriptReference/Texture.html) **image**);

public static void **BeginArea** ([Rect](https://docs.unity3d.com/cn/2019.4/ScriptReference/Rect.html) **screenRect**, [GUIContent](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUIContent.html) **content**);

public static void **BeginArea** ([Rect](https://docs.unity3d.com/cn/2019.4/ScriptReference/Rect.html) **screenRect**, [GUIStyle](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUIStyle.html) **style**);

public static void **BeginArea** ([Rect](https://docs.unity3d.com/cn/2019.4/ScriptReference/Rect.html) **screenRect**, string **text**, [GUIStyle](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUIStyle.html) **style**);

public static void **BeginArea** ([Rect](https://docs.unity3d.com/cn/2019.4/ScriptReference/Rect.html) **screenRect**, [Texture](https://docs.unity3d.com/cn/2019.4/ScriptReference/Texture.html) **image**, [GUIStyle](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUIStyle.html) **style**);

public static void **BeginArea** ([Rect](https://docs.unity3d.com/cn/2019.4/ScriptReference/Rect.html) **screenRect**, [GUIContent](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUIContent.html) **content**, [GUIStyle](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUIStyle.html) **style**);

## 参数

| text    | （可选）要在该区域中显示的文本。                             |
| ------- | ------------------------------------------------------------ |
| image   | （可选）要在该区域中显示的纹理。                             |
| content | （可选）在该区域顶部显示的文本、图像和工具提示。             |
| style   | 要使用的样式。如果省略，则使用空 [GUIStyle](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUIStyle.html) ([GUIStyle.none](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUIStyle-none.html))，提供透明背景。 |

## 描述

在一个固定的屏幕区域中开始 GUI 控件的 GUILayout 块。

默认情况下，使用 GUILayout 创建的任何 GUI 控件都放置在屏幕的左上角。 若要在任意区域放置一系列自动布局的控件，请使用 GUILayout.BeginArea 为自动布局系统定义要使用的新区域。

简单来说就是防止这个区域中的控件超出这个区域的范围，超出部分不绘制。

另请参阅：[EndArea](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUILayout.EndArea.html)

![img](https://docs.unity3d.com/cn/2019.4/StaticFiles/ScriptRefImages/GUILayoutArea.png)\ *说明示例区域。*

```
using UnityEngine;public class ExampleScript : MonoBehaviour
{
    void OnGUI()
    {
        // Starts an area to draw elements
        GUILayout.BeginArea(new Rect(10, 10, 100, 100));
        GUILayout.Button("Click me");
        GUILayout.Button("Or me");
        GUILayout.EndArea();
    }
}
```

在混合 GUILayout 代码时，该函数非常有用。它必须与 EndArea 调用配对使用。BeginArea/EndArea 不能嵌套。