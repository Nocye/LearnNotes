# [EditorApplication](https://docs.unity3d.com/cn/2019.4/ScriptReference/EditorApplication.html)编辑器应用程序类

主要是通过代码对unity编辑器本身进行操作

## Events

| [hierarchyChanged](https://docs.unity3d.com/cn/2019.4/ScriptReference/EditorApplication-hierarchyChanged.html) | 当层级视图中的对象或对象组发生更改时引发的事件。 |
| ------------------------------------------------------------ | ------------------------------------------------ |
| [pauseStateChanged](https://docs.unity3d.com/cn/2019.4/ScriptReference/EditorApplication-pauseStateChanged.html) | 每当编辑器的暂停状态发生更改时引发的事件。       |
| [playModeStateChanged](https://docs.unity3d.com/cn/2019.4/ScriptReference/EditorApplication-playModeStateChanged.html) | 每当编辑器的播放模式状态发生更改时引发的事件。   |
| [projectChanged](https://docs.unity3d.com/cn/2019.4/ScriptReference/EditorApplication-projectChanged.html) | 每当项目的状态发生更改时引发的事件。             |
| [quitting](https://docs.unity3d.com/cn/2019.4/ScriptReference/EditorApplication-quitting.html) | 当编辑器应用程序退出时，Unity 会引发此事件。     |
| [wantsToQuit](https://docs.unity3d.com/cn/2019.4/ScriptReference/EditorApplication-wantsToQuit.html) | 当编辑器应用程序想要退出时，Unity 会引发此事件。 |

| [projectWindowItemOnGUI](https://docs.unity3d.com/cn/2019.4/ScriptReference/EditorApplication-projectWindowItemOnGUI.html) | Project 窗口中每个可见列表项的 OnGUI 事件的委托。 |
| ------------------------------------------------------------ | ------------------------------------------------- |
| [searchChanged](https://docs.unity3d.com/cn/2019.4/ScriptReference/EditorApplication-searchChanged.html) | 每当窗口的搜索框的内容发生更改时引发的回调。      |
| [timeSinceStartup](https://docs.unity3d.com/cn/2019.4/ScriptReference/EditorApplication-timeSinceStartup.html) | 自编辑器启动以来经过的时间。（只读）              |
| [update](https://docs.unity3d.com/cn/2019.4/ScriptReference/EditorApplication-update.html) | 通用更新的委托。                                  |

```c#
public static void LockReloadAssemblies ();
```

防止在不方便时加载程序集。

例如，在拖动操作期间，您可能需要防止程序集重新加载，以免在拖动过程中丢失状态。 每个 LockReloadAssemblies 必须与 UnlockReloadAssemblies 匹配，否则脚本永远不会卸载。 Unity 会自动阻止在鼠标按下时重新加载。(譬如在自动生成代码时,写入文件阶段并不希望加载程序集,可以调用这个函数)

```c#
public static void UnlockReloadAssemblies ();
```

必须在 LockReloadAssemblies 之后调用，以重新启用程序集的加载过程。(和上面成对出现)