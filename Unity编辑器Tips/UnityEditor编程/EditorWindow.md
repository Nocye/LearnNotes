所有自定义Unity扩展窗口都要继承这个类,

```c#
public class EditorListTest : EditorWindow
{   
    [MenuItem("Tool/ListWindow")]
    private static void OpenAssetBundleWindow()
    {
        var abWindow = GetWindow<EditorListTest>();        
        abWindow.Show();
    }
}
```

> ```c#
> CreateWindow<T>(string title, params System.Type[] desiredDockNextTo) where T : EditorWindow;
> ```
>
> |         T         | 窗口的类型。必须从 EditorWindow 派生.               |
> | :---------------: | --------------------------------------------------- |
> |       title       | 创建的窗口的标题。如果此值为空，则使用类名作为标题. |
> | desiredDockNextTo | 窗口将尝试停靠到的EditorWindow类型的数组。          |
>
> 创建一个T类型的EditorWindow。
>
> 创建并显示一个新窗口，并返回它的实例。



> ```c#
> GetWindow<T>(string title, bool focus, params System.Type[] desiredDockNextTo) where T : EditorWindow;
> ```
>
> | T                  | 窗口的类型。 必须从EditorWindow派生。                        |
> | ------------------ | ------------------------------------------------------------ |
> | title              | 如果GetWindow创建一个新窗口，它将获得此标题。 如果此值为null，请使用类名称作为标题。 |
> | requiredDockNextTo | 窗口将尝试停靠在其上的EditorWindow类型的数组。               |
> | focus              | 是否赋予窗口焦点（如果已经存在）。 （如果GetWindow创建一个新窗口，它将始终获得焦点）。 |
>
> 返回当前屏幕上的第一个T类型的EditorWindow。如果没有，则创建并显示新窗口，并返回它的实例。创建的窗口将尝试停靠在第一个找到的指定窗口类型旁边。

> ```c#
> private void ShowButton(Rect rect);
> ```
>
> 此方法为Unity消息，可以在EditorWindow的右上角工具栏区域绘制