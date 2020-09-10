# [EditorSceneManager](https://docs.unity3d.com/cn/2019.4/ScriptReference/SceneManagement.EditorSceneManager.html)

#### EditorSceneManager.OpenScene

```c#
public static SceneManagement.Scene OpenScene (string scenePath, SceneManagement.OpenSceneMode mode= OpenSceneMode.Single);
```

## 参数

| scenePath | 场景的路径。此路径应是项目文件夹的相对路径；例如，"Assets/MyScenes/MyScene.unity"。 |
| --------- | ------------------------------------------------------------ |
| mode      | 允许您选择如何打开指定场景以及是否将 Hierarchy 窗口中的现有场景保持打开状态。有关选项的更多信息，请参阅 [OpenSceneMode](https://docs.unity3d.com/cn/2019.4/ScriptReference/SceneManagement.OpenSceneMode.html)。 |

# [SceneManager](https://docs.unity3d.com/cn/2019.4/ScriptReference/SceneManagement.SceneManager.html).GetActiveScene

```c#
public static SceneManagement.Scene GetActiveScene ();
```



## 返回

**Scene** 活动场景。

## 描述

获取当前活动的场景。

当前活动场景是指将用作新游戏对象（由脚本实例化）的目标的场景。 请注意，活动场景对渲染的场景没有影响。 另请参阅：[Scene](https://docs.unity3d.com/cn/2019.4/ScriptReference/SceneManagement.Scene.html)。

注意:如果在编辑下获取到场景后,再通过上面的方法打开场景后,会导致保存的场景为null 要注意;