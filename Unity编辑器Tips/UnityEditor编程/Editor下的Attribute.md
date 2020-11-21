# CanEditMultipleObjects

#### 描述

用于使自定义编辑器支持多对象编辑的属性。

在选择了多个对象后，不具有此属性的编辑器将会显示"Multi-object editing not supported"消息。 请参阅 [Editor](https://docs.unity3d.com/cn/2019.4/ScriptReference/Editor.html) 类文档，以了解如何使编辑器支持多对象编辑。

另请参阅：[Editor](https://docs.unity3d.com/cn/2019.4/ScriptReference/Editor.html) 类。

# CustomEditor

#### 描述

告知编辑器类该编辑器所针对的运行时类型。

当您为组件创建自定义编辑器时，您需要将此属性添加到编辑器类上。

另请参阅：[Editor](https://docs.unity3d.com/cn/2019.4/ScriptReference/Editor.html) 类。

#### 变量

| [isFallback](https://docs.unity3d.com/cn/2019.4/ScriptReference/CustomEditor-isFallback.html) | 如果为 true，则仅在所有非回退编辑器均不匹配时匹配此编辑器。默认为 false。 |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
|                                                              |                                                              |

#### 构造函数

| [CustomEditor](https://docs.unity3d.com/cn/2019.4/ScriptReference/CustomEditor-ctor.html) | 定义自定义编辑器类可以编辑的对象类型。 |
| ------------------------------------------------------------ | -------------------------------------- |
|                                                              |                                        |

# CustomEditorForRenderPipelineAttribute

继承自：[CustomEditor](https://docs.unity3d.com/cn/2019.4/ScriptReference/CustomEditor.html)

#### 描述

告知编辑器类当给定 RenderPipeline 激活时该编辑器所针对的运行时类型。

当您为基于激活的 RenderPipeline 而更改的组件创建自定义编辑器时，您需要将此属性添加到此类上。

另请参阅：[Editor](https://docs.unity3d.com/cn/2019.4/ScriptReference/Editor.html) 类。

#### 构造函数

| [CustomEditorForRenderPipelineAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/CustomEditorForRenderPipelineAttribute-ctor.html) | 定义自定义编辑器类可以编辑的对象类型。 |
| ------------------------------------------------------------ | -------------------------------------- |
|                                                              |                                        |

#### 继承的成员

#### 变量

| [isFallback](https://docs.unity3d.com/cn/2019.4/ScriptReference/CustomEditor-isFallback.html) | 如果为 true，则仅在所有非回退编辑器均不匹配时匹配此编辑器。默认为 false。 |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
|                                                              |                                                              |

# CustomPreviewAttribute

#### 描述

在检视面板中为指定的类型添加额外的预览。

您可以使用此属性将自定义预览添加到可进行检查的任何对象中。

#### 构造函数

| [CustomPreviewAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/CustomPreviewAttribute-ctor.html) | 告知 DefaultPreview 该预览所针对的类。 |
| ------------------------------------------------------------ | -------------------------------------- |
|                                                              |                                        |

# CustomPropertyDrawer

#### 描述

告知自定义 [PropertyDrawer](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyDrawer.html) 或 [DecoratorDrawer](https://docs.unity3d.com/cn/2019.4/ScriptReference/DecoratorDrawer.html) 该绘制器所针对的运行时 [Serializable](https://docs.unity3d.com/cn/2019.4/ScriptReference/Serializable.html) 类或 [PropertyAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyAttribute.html)。

当您构建自定义 [PropertyDrawer](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyDrawer.html) 或 [DecoratorDrawer](https://docs.unity3d.com/cn/2019.4/ScriptReference/DecoratorDrawer.html) 时，您需要将此属性添加到绘制器类上。 如果绘制器针对的是 [Serializable](https://docs.unity3d.com/cn/2019.4/ScriptReference/Serializable.html) 类，那么请将此类的类型传递到 CustomPropertyDrawer 属性（只对 PropertyDrawer 有效；对 DecoratorDrawer 无效）。 如果绘制器针对的是 [PropertyAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyAttribute.html)，那么请将 PropertyAttribute 的类型传递给 CustomPropertyDrawer 属性。

另请参阅：[PropertyDrawer](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyDrawer.html) 类、[DecoratorDrawer](https://docs.unity3d.com/cn/2019.4/ScriptReference/DecoratorDrawer.html) 类。

#### 构造函数

| [CustomPropertyDrawer](https://docs.unity3d.com/cn/2019.4/ScriptReference/CustomPropertyDrawer-ctor.html) | 告知 PropertyDrawer 或 DecoratorDrawer 类该绘制器所针对的运行时类或属性。 |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
|                                                              |                                                              |

# DrawGizmo

#### 描述

DrawGizmo 属性可用于为任意 [Component](https://docs.unity3d.com/cn/2019.4/ScriptReference/Component.html) 提供辅助图标渲染器。

渲染器函数必须是静态的，并且采用两个参数：一个是 绘制辅助图标所面向的对象，另一个是 [GizmoType](https://docs.unity3d.com/cn/2019.4/ScriptReference/GizmoType.html) 参数，表示绘制辅助图标时所处的上下文。

渲染器函数可在任何类中定义，包括编辑器脚本。因此， 您可以将辅助图标绘制代码与组件脚本分离，从而 使其不会包含在构建中。

另请参阅：[GizmoType](https://docs.unity3d.com/cn/2019.4/ScriptReference/GizmoType.html)。

```c#
using UnityEngine;
using UnityEditor;public class MyScript : MonoBehaviour
{
}// The icon has to be stored in Assets/Gizmospublic class MyScriptGizmoDrawer
{
    [DrawGizmo(GizmoType.Selected | GizmoType.Active)]
    static void DrawGizmoForMyScript(MyScript scr, GizmoType gizmoType)
    {
        Vector3 position = scr.transform.position;        if (Vector3.Distance(position, Camera.current.transform.position) > 10f)
            Gizmos.DrawIcon(position, "MyScript Gizmo.tiff");
    }
}
```

#### 构造函数

| [DrawGizmo](https://docs.unity3d.com/cn/2019.4/ScriptReference/DrawGizmo-ctor.html) | 定义应调用辅助图标以进行绘制的情况。 |
| ------------------------------------------------------------ | ------------------------------------ |
|                                                              |                                      |

# InitializeOnEnterPlayModeAttribute

#### 描述

允许在 Unity 进入运行模式时初始化编辑器类方法。

用于在进入运行模式时重置 Editor 类中的静态字段，而不进行域重新加载。

```c#
using UnityEngine;
using UnityEditor;class MyAnotherClass
{
    static int s_MySimpleValue = 0;    [InitializeOnEnterPlayMode]
    static void OnEnterPlaymodeInEditor(EnterPlayModeOptions options)
    {
        Debug.Log("Entering PlayMode");        if (options.HasFlag(EnterPlayModeOptions.DisableDomainReload))
            s_MySimpleValue = 0;
    }
}
```

或者在进入运行模式时执行任何其他逻辑。

```c#
using UnityEngine;
using UnityEditor;class MyClass
{
    static int s_MyValue = 0;    static void MyClassPlaymodeSetup()
    {
        s_MyValue = 1000;
        //...
    }    [InitializeOnEnterPlayMode]
    static void OnEnterPlaymodeInEditor(EnterPlayModeOptions options)
    {
        Debug.Log("Entering PlayMode");
        MyClassPlaymodeSetup();
    }
}
```

# InitializeOnLoadAttribute

#### 描述

允许在 Unity 加载时和重新编译脚本时初始化 Editor 类。

重新编译项目中的脚本时，会调用带有此属性的静态构造函数（也称为[域重新加载](https://docs.unity3d.com/cn/2019.4/Manual/DomainReloading.html)）。在 Unity 首次加载项目时、在 Unity 检测到脚本修改时（取决于[自动刷新首选项](https://docs.unity3d.com/cn/2019.4/Manual/Preferences.html)），以及当进入运行模式时（取决于[运行模式配置](https://docs.unity3d.com/cn/2019.4/Manual/ConfigurableEnterPlayMode.html)），会进行此调用。

另请参阅：[启动时运行编辑器代码](https://docs.unity3d.com/cn/2019.4/Manual/RunningEditorCodeOnLaunch.html)。

# InitializeOnLoadMethodAttribute

#### 描述

允许在 Unity 加载时初始化编辑器类方法，无需用户操作。

```c#
using UnityEngine;
using UnityEditor;class MyClass
{
    [InitializeOnLoadMethod]
    static void OnProjectLoadedInEditor()
    {
        Debug.Log("Project loaded in Unity Editor");
    }
}
```

# LightingExplorerExtensionAttribute

继承自：[Rendering.ScriptableRenderPipelineExtensionAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/Rendering.ScriptableRenderPipelineExtensionAttribute.html)

#### 描述

用于标记 Lighting Explorer 的扩展类的属性。每个渲染管线仅支持一个扩展。

#### 构造函数

| [LightingExplorerExtensionAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/LightingExplorerExtensionAttribute-ctor.html) | 构造函数。 |
| ------------------------------------------------------------ | ---------- |
|                                                              |            |

#### 继承的成员

#### 变量

| [inUse](https://docs.unity3d.com/cn/2019.4/ScriptReference/Rendering.ScriptableRenderPipelineExtensionAttribute-inUse.html) | 确定当前的 ScriptableRenderPipeline 是否与构造函数给定的类型相同。如果 ScriptableRenderPipeline 为构造此属性时所用的类型，则返回 true。否则，返回 false。 |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
|                                                              |                                                              |

# MenuItem

#### 描述

MenuItem 属性用于向主菜单和检视面板上下文菜单添加菜单项。

该 MenuItem 属性能够将任何静态函数转变为菜单命令。仅静态函数可使用 MenuItem 属性。

要创建热键，您可以使用以下特殊字符：**%**（在 Windows 上为 ctrl，在 macOS 上为 cmd）、**#** (shift)、**&** (alt)。如果不需要特殊的修改键组合，该键可以在下划线后给出。例如，要创建一个带有热键 shift-alt-g 的菜单，可以使用`“MyMenu/Do Something #&g”`。要创建带有热键 **g** 而不按下修改键的菜单，则使用`“MyMenu/Do Something _g”`。

一些特殊的键盘键可支持作为热键，例如，“#LEFT”可映射到 shift-left。支持这一功能的键为：LEFT、RIGHT、UP、DOWN、F1 .. F12、HOME、END、PGUP 和 PGDN。

热键文本前必须有一个空格字符（`“MyMenu/Do_g”`不能被解释为热键，而`“MyMenu/Do _g”`则可以被解释为热键）。

将菜单项添加到“GameObject/”菜单，以在创建自定义游戏对象时，确保 调用 [GameObjectUtility.SetParentAndAlign](https://docs.unity3d.com/cn/2019.4/ScriptReference/GameObjectUtility.SetParentAndAlign.html)，从而确保在发生上下文单击事件时， 对新的游戏对象进行正确地重定父级（请参阅以下示例）。您的函数也应该调用 [Undo.RegisterCreatedObjectUndo](https://docs.unity3d.com/cn/2019.4/ScriptReference/Undo.RegisterCreatedObjectUndo.html)，以使创建操作可撤销并将 [Selection.activeObject](https://docs.unity3d.com/cn/2019.4/ScriptReference/Selection-activeObject.html) 设置到新创建的对象上。另请注意，为了将“GameObject/”中的菜单项 传播到层级视图 Create 下拉菜单和层级视图上下文菜单，它必须与 其他游戏对象创建菜单项归为一组。这可以通过将其优先级 设为 10 来实现（请参阅以下示例）。请注意，对于“GameObject/Create Other” 中没有明确优先级设置且支持旧版项目的 MenuItem 来说，接收到的优先级为 10 而非默认的 1000， 我们建议使用比“Create Other”更具描述性的类别名称，并将优先级 显式设置为 10。

```c#
using UnityEditor;
using UnityEngine;
public class MenuTest : MonoBehaviour
{
    // Add a menu item named "Do Something" to MyMenu in the menu bar.
    [MenuItem("MyMenu/Do Something")]
    static void DoSomething()
    {
        Debug.Log("Doing Something...");
    }    // Validated menu item.
    // Add a menu item named "Log Selected Transform Name" to MyMenu in the menu bar.
    // We use a second function to validate the menu item
    // so it will only be enabled if we have a transform selected.
    [MenuItem("MyMenu/Log Selected Transform Name")]
    static void LogSelectedTransformName()
    {
        Debug.Log("Selected Transform is on " + Selection.activeTransform.gameObject.name + ".");
    }    // Validate the menu item defined by the function above.
    // The menu item will be disabled if this function returns false.
    [MenuItem("MyMenu/Log Selected Transform Name", true)]
    static bool ValidateLogSelectedTransformName()
    {
        // Return false if no transform is selected.
        return Selection.activeTransform != null;
    }    // Add a menu item named "Do Something with a Shortcut Key" to MyMenu in the menu bar
    // and give it a shortcut (ctrl-g on Windows, cmd-g on macOS).
    [MenuItem("MyMenu/Do Something with a Shortcut Key %g")]
    static void DoSomethingWithAShortcutKey()
    {
        Debug.Log("Doing something with a Shortcut Key...");
    }    // Add a menu item called "Double Mass" to a Rigidbody's context menu.
    [MenuItem("CONTEXT/Rigidbody/Double Mass")]
    static void DoubleMass(MenuCommand command)
    {
        Rigidbody body = (Rigidbody)command.context;
        body.mass = body.mass * 2;
        Debug.Log("Doubled Rigidbody's Mass to " + body.mass + " from Context Menu.");
    }    // Add a menu item to create custom GameObjects.
    // Priority 1 ensures it is grouped with the other menu items of the same kind
    // and propagated to the hierarchy dropdown and hierarchy context menus.
    [MenuItem("GameObject/MyCategory/Custom Game Object", false, 10)]
    static void CreateCustomGameObject(MenuCommand menuCommand)
    {
        // Create a custom game object
        GameObject go = new GameObject("Custom Game Object");
        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }
}
```

#### 构造函数

| [MenuItem](https://docs.unity3d.com/cn/2019.4/ScriptReference/MenuItem-ctor.html) | 创建一个菜单项并在选中此菜单项后调用静态函数。 |
| ------------------------------------------------------------ | ---------------------------------------------- |
|                                                              |                                                |

# SettingsProviderAttribute

#### 描述

用于注册新 [SettingsProvider](https://docs.unity3d.com/cn/2019.4/ScriptReference/SettingsProvider.html) 的属性。使用此属性可以修饰返回 [SettingsProvider](https://docs.unity3d.com/cn/2019.4/ScriptReference/SettingsProvider.html) 实例的函数。如果函数返回 null，则 Settings 窗口中不会显示 SettingsProvider。

```c#
using System.IO;
using System.Linq;
using UnityEditor;class MyCustomSettingsProvider : SettingsProvider
{
    const string k_MyCustomSettingsPath = "Resources/MyCustomSettings.asset";
    public MyCustomSettingsProvider(string path, SettingsScope scope)
        : base(path, scope) {}    public static bool IsSettingsAvailable()
    {
        return File.Exists(k_MyCustomSettingsPath);
    }    [SettingsProvider]
    public static SettingsProvider CreateMyCustomSettingsProvider()
    {
        if (IsSettingsAvailable())
        {
            return new MyCustomSettingsProvider("MyCustomSettings", SettingsScope.Project);
        }        // Settings Asset doesn't exist yet. No need to display anything in the Settings window.
        return null;
    }
}
```

#### 构造函数

| [SettingsProviderAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/SettingsProviderAttribute-ctor.html) | 创建用于注册新 SettingsProvider 的 SettingsProviderAttribute。 |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
|                                                              |                                                              |

# SettingsProviderGroupAttribute

#### 描述

用于注册多个 [SettingsProvider](https://docs.unity3d.com/cn/2019.4/ScriptReference/SettingsProvider.html) 项的属性。使用此属性可以修饰返回一组 [SettingsProvider](https://docs.unity3d.com/cn/2019.4/ScriptReference/SettingsProvider.html) 实例的函数。如果函数返回 null，则 Settings 窗口中不会显示 SettingsProvider。

```c#
using System.IO;
using System.Linq;
using UnityEditor;class XRSettings : SettingsProvider
{
    const string k_XRSettingsFolder = "Assets/Editor/XRSettings";
    public XRSettings(string path, SettingsScope scope = SettingsScope.Project)
        : base(path, scope)
    {
    }    [SettingsProviderGroup]
    public static SettingsProvider[] CreateProviders()
    {
        var files = Directory.GetFileSystemEntries(k_XRSettingsFolder, "*.json");
        return files.Select(entry =>
        {
            // First parameter is the path of the settings in the Settings window.
            return new XRSettings("Project/XRSettings/" + Path.GetFileNameWithoutExtension(entry));
        }).ToArray();
    }
}
```

#### 构造函数

| [SettingsProviderGroupAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/SettingsProviderGroupAttribute-ctor.html) | 创建用于注册多个 SettingsProvider 的 SettingsProviderGroupAttribute。 |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
|                                                              |                                                              |