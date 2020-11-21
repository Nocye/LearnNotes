# AddComponentMenu

#### 描述

使用 AddComponentMenu 属性可在“Component”菜单中的任意位置放置脚本，而不仅是“Component > Scripts”菜单。

使用此属性可以更好地组织 Component 菜单，从而改进添加脚本时的工作流程。 重要提示：您需要重新启动。

```
using UnityEngine;[AddComponentMenu("Transform/Follow Transform")]
public class FollowTransform : MonoBehaviour
{
}
```

#### 变量

| [componentOrder](https://docs.unity3d.com/cn/2019.4/ScriptReference/AddComponentMenu-componentOrder.html) | 组件在 Component 菜单中的顺序（顺序越低，位置越高）。 |
| ------------------------------------------------------------ | ----------------------------------------------------- |
|                                                              |                                                       |

#### 构造函数

| [AddComponentMenu](https://docs.unity3d.com/cn/2019.4/ScriptReference/AddComponentMenu-ctor.html) | 在 Component 菜单中添加一个项目。 |
| ------------------------------------------------------------ | --------------------------------- |
|                                                              |                                   |

# AssemblyIsEditorAssembly

#### 描述

程序集级别的属性。具有该属性的程序集中的任何类都将被视为编辑器类。

#### 构造函数

| [AssemblyIsEditorAssembly](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssemblyIsEditorAssembly-ctor.html) | 构造函数。 |
| ------------------------------------------------------------ | ---------- |
|                                                              |            |

# BeforeRenderOrderAttribute

#### 描述

当您需要为 Application.onBeforeRender 指定自定义回调顺序时，使用此 BeforeRenderOrderAttribute。

[Application.onBeforeRender](https://docs.unity3d.com/cn/2019.4/ScriptReference/Application-onBeforeRender.html) 将对所有已注册的事件接收器进行重新排序，然后根据此属性按从低到高的顺序调用它们。无属性代表顺序 0。

#### 变量

| [order](https://docs.unity3d.com/cn/2019.4/ScriptReference/BeforeRenderOrderAttribute-order.html) | 从低到高的顺序，这是将调用 Application.onBeforeRender 事件接收器的顺序。 |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
|                                                              |                                                              |

#### 构造函数

| [BeforeRenderOrderAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/BeforeRenderOrderAttribute-ctor.html) | 应用于方法时，指定在 Application.onBeforeRender 事件期间的调用顺序。 |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
|                                                              |                                                              |

# ColorUsageAttribute

继承自：[PropertyAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyAttribute.html)

#### 描述

属性，用于为颜色配置 ColorField 和拾色器的使用情况。

对 Color 使用此属性可将 Color Field 和拾色器配置为显示/隐藏 alpha 值，以及将颜色处理为 HDR 颜色还是正常 LDR 颜色。

#### 变量

| [hdr](https://docs.unity3d.com/cn/2019.4/ScriptReference/ColorUsageAttribute-hdr.html) | 如果设置为 true，则将 Color 处理为 HDR 颜色。                |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [showAlpha](https://docs.unity3d.com/cn/2019.4/ScriptReference/ColorUsageAttribute-showAlpha.html) | 如果为 false，则 ColorField 中会隐藏 alpha 栏，并且拾色器中不显示 alpha 值。 |

#### 构造函数

| [ColorUsageAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/ColorUsageAttribute-ctor.html) | Color 字段的属性。用于配置颜色的 GUI。 |
| ------------------------------------------------------------ | -------------------------------------- |
|                                                              |                                        |

#### 继承的成员

#### 变量

| [order](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyAttribute-order.html) | 可选字段，用于指定多个 DecorationDrawer 应采用的绘制顺序。 |
| ------------------------------------------------------------ | ---------------------------------------------------------- |
|                                                              |                                                            |

# ContextMenu

#### 描述

ContextMenu 属性用于向上下文菜单添加命令。

在该附加脚本的 Inspector 中，当用户选择该上下文菜单时， 将执行此函数。

这对于从该脚本自动设置场景数据非常有用。 此函数必须是非静态的。

```
using UnityEngine;public class ContextTesting : MonoBehaviour
{
    /// Add a context menu named "Do Something" in the inspector
    /// of the attached script.
    [ContextMenu("Do Something")]
    void DoSomething()
    {
        Debug.Log("Perform operation");
    }
}
```

#### 构造函数

| [ContextMenu](https://docs.unity3d.com/cn/2019.4/ScriptReference/ContextMenu-ctor.html) | 将此函数添加到该组件的上下文菜单。 |
| ------------------------------------------------------------ | ---------------------------------- |
|                                                              |                                    |

# ContextMenuItemAttribute

继承自：[PropertyAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyAttribute.html)

#### 描述

使用该属性可将上下文菜单添加到调用命名方法的字段。

```
using UnityEngine;public class Example : MonoBehaviour
{
    [ContextMenuItem("Reset", "ResetBiography")]
    [Multiline(8)]
    string playerBiography = "";    void ResetBiography()
    {
        playerBiography = "";
    }
}
```

#### 变量

| [function](https://docs.unity3d.com/cn/2019.4/ScriptReference/ContextMenuItemAttribute-function.html) | 应调用的函数的名称。   |
| ------------------------------------------------------------ | ---------------------- |
| [name](https://docs.unity3d.com/cn/2019.4/ScriptReference/ContextMenuItemAttribute-name.html) | 此上下文菜单项的名称。 |

#### 构造函数

| [ContextMenuItemAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/ContextMenuItemAttribute-ctor.html) | 使用该属性可将上下文菜单添加到调用命名方法的字段。 |
| ------------------------------------------------------------ | -------------------------------------------------- |
|                                                              |                                                    |

#### 继承的成员

#### 变量

| [order](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyAttribute-order.html) | 可选字段，用于指定多个 DecorationDrawer 应采用的绘制顺序。 |
| ------------------------------------------------------------ | ---------------------------------------------------------- |
|                                                              |                                                            |

# CreateAssetMenuAttribute

#### 描述

对 ScriptableObject 派生类型进行标记，使其自动列在 Assets/Create 子菜单中，以便能够轻松创建该类型的实例并将其作为“.asset”文件存储在项目中。

#### 变量

| [fileName](https://docs.unity3d.com/cn/2019.4/ScriptReference/CreateAssetMenuAttribute-fileName.html) | 此类型的新建实例使用的默认文件名。           |
| ------------------------------------------------------------ | -------------------------------------------- |
| [menuName](https://docs.unity3d.com/cn/2019.4/ScriptReference/CreateAssetMenuAttribute-menuName.html) | Assets/Create 菜单中显示的此类型的显示名称。 |
| [order](https://docs.unity3d.com/cn/2019.4/ScriptReference/CreateAssetMenuAttribute-order.html) | Assets/Create 菜单中菜单项的位置。           |

# CustomGridBrushAttribute

#### 描述

属性，用于将该类定义为网格画笔，以及使其在调色板窗口中可用。

#### 变量

| [defaultBrush](https://docs.unity3d.com/cn/2019.4/ScriptReference/CustomGridBrushAttribute-defaultBrush.html) | 如果设置为 true，则画笔将替换在调色板窗口中作为默认画笔的 Unity 内置画笔。任何时候都只应有一个类将 defaultBrush 设置为 true。 |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| [defaultName](https://docs.unity3d.com/cn/2019.4/ScriptReference/CustomGridBrushAttribute-defaultName.html) | 此画笔的默认实例的名称。                                     |
| [hideAssetInstances](https://docs.unity3d.com/cn/2019.4/ScriptReference/CustomGridBrushAttribute-hideAssetInstances.html) | 在该瓦片面板窗口中隐藏该画笔的所有资源实例。                 |
| [hideDefaultInstance](https://docs.unity3d.com/cn/2019.4/ScriptReference/CustomGridBrushAttribute-hideDefaultInstance.html) | 在该 Tile Palette 设置后，该摄像机渲染另一个通道（在不透明效果之后，但在图像效果之前）： |

#### 构造函数

| [CustomGridBrushAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/CustomGridBrushAttribute-ctor.html) | 属性，用于将该类定义为网格画笔，以及使其在调色板窗口中可用。 |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
|                                                              |                                                              |

# DelayedAttribute

继承自：[PropertyAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyAttribute.html)

#### 描述

属性，用于使脚本中的 float、int 或 string 变量被延迟。

当使用此属性时，直到用户按 Enter 键或将焦点从 float、int 或文本字段移开后，该字段才会返回新值。

#### 构造函数

| [DelayedAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/DelayedAttribute-ctor.html) | 属性，用于使脚本中的 float、int 或 string 变量被延迟。 |
| ------------------------------------------------------------ | ------------------------------------------------------ |
|                                                              |                                                        |

# DisallowMultipleComponent

#### 描述

防止将相同类型（或子类型）的 MonoBehaviour 多次添加到 GameObject。

# ExcludeFromObjectFactoryAttribute

#### 描述

将此属性添加到某个类可防止使用 [ObjectFactory](https://docs.unity3d.com/cn/2019.4/ScriptReference/ObjectFactory.html) 方法创建该类及其继承类。

# ExcludeFromPresetAttribute

#### 描述

将此属性添加到某个类可防止从该类的实例创建 [Preset](https://docs.unity3d.com/cn/2019.4/ScriptReference/Presets.Preset.html)。

# ExecuteAlways

#### 描述

使脚本的实例在播放模式期间以及编辑时始终执行。

默认情况下，MonoBehaviours 仅在播放模式下并且仅当它们位于包含用户场景的主阶段中的游戏对象上时才执行。它们不会在编辑模式下执行，也不在预制件模式下编辑的对象上执行，即使此时在播放模式下也是如此。通过添加此属性，MonoBehaviour 的任何实例都将始终执行其回调函数。

当您希望脚本作为编辑器工具的一部分执行某些操作时，即可使用 [ExecuteAlways] 属性，不一定要与构建播放器和播放模式中发生的播放逻辑相关。有时，此类脚本的“播放”功能与其“编辑模式”功能相同，而其他情况下则相差很大。

使用此属性的 MonoBehaviour 必须确保它们在编辑模式下或者在对象不是游戏世界的一部分时不会运行可能导致对象被错误修改的播放逻辑。为达到此目的，可以使用 [Application.IsPlaying](https://docs.unity3d.com/cn/2019.4/ScriptReference/Application.IsPlaying.html)，在其中，脚本可以传入自己的游戏对象以检查它是否是游戏世界的一部分。

如果 MonoBehaviour 在播放模式下运行播放逻辑并且无法检查其游戏对象是否是游戏世界的一部分，则在预制件模式下编辑的预制件可能会被仅用作游戏世界一部分的逻辑错误地修改和保存。

如果您的脚本使用静态变量或单例模式，则应确保属于游戏世界的脚本实例和不属于游戏世界的实例不会通过这些变量或单例意外地相互影响。

在不属于游戏世界的对象上，不会像其他情况那样不断地调用以下函数。
\- [Update](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour.Update.html) is only called when something in the Scene changed.
\- [OnGUI](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour.OnGUI.html) is called when the Game view receives a non-editor-only [Event](https://docs.unity3d.com/cn/2019.4/ScriptReference/Event.html) that it does not use (e.g., [EventType.ScrollWheel](https://docs.unity3d.com/cn/2019.4/ScriptReference/EventType.ScrollWheel.html)) and does not forward to the Editor's keyboard shortcut system (e.g., [EventType.KeyDown](https://docs.unity3d.com/cn/2019.4/ScriptReference/EventType.KeyDown.html), [EventType.KeyUp](https://docs.unity3d.com/cn/2019.4/ScriptReference/EventType.KeyUp.html)). Events forwarded to the Game view are enqueued and are not guaranteed to be processed immediately.
\- [OnRenderObject](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour.OnRenderObject.html) and the other rendering callback functions are called on every repaint of the Scene view or Game view.

另请参阅：[Application.IsPlaying](https://docs.unity3d.com/cn/2019.4/ScriptReference/Application.IsPlaying.html)、[runInEditMode](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour-runInEditMode.html)、[EditorApplication.QueuePlayerLoopUpdate](https://docs.unity3d.com/cn/2019.4/ScriptReference/EditorApplication.QueuePlayerLoopUpdate.html)。

```c#
using UnityEngine;[ExecuteAlways]
public class ExampleClass : MonoBehaviour
{
    void Start()
    {
        if (Application.IsPlaying(gameObject))
        {
            // Play logic
        }
        else
        {
            // Editor logic
        }
    }
}
```

# ExecuteInEditMode

#### 描述

使脚本的所有实例都在编辑模式下执行。

默认情况下，仅在播放模式下执行 MonoBehaviours。通过添加此属性，MonoBehaviour 的任何实例都将在编辑器处于编辑模式时执行其回调函数。

此属性正在逐步被淘汰，因为它不考虑预制件模式。如果在预制件模式下编辑一个带有 MonoBehaviour 并启用了此属性的预制件，然后进入播放模式，则编辑器将退出预制件模式，以防止由仅用于播放模式的逻辑引起的预制件意外修改。

要指示 MonoBehaviour 正确考虑了预制件模式并且在播放模式期间以预制件模式打开是安全的，可以使用属性 [ExecuteAlways](https://docs.unity3d.com/cn/2019.4/ScriptReference/ExecuteAlways.html) 取代此处的属性。

以下函数不像它们在播放模式下那样被不断调用。
\- [Update](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour.Update.html) is only called when something in the Scene changed.
\- [OnGUI](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour.OnGUI.html) is called when the Game View receives a non-editor-only [Event](https://docs.unity3d.com/cn/2019.4/ScriptReference/Event.html) that it does not use (e.g., [EventType.ScrollWheel](https://docs.unity3d.com/cn/2019.4/ScriptReference/EventType.ScrollWheel.html)) and does not forward to the Editor's keyboard shortcut system (e.g., [EventType.KeyDown](https://docs.unity3d.com/cn/2019.4/ScriptReference/EventType.KeyDown.html), [EventType.KeyUp](https://docs.unity3d.com/cn/2019.4/ScriptReference/EventType.KeyUp.html)). Events forwarded to the Game View are enqueued and are not guaranteed to be processed immediately.
\- [OnRenderObject](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour.OnRenderObject.html) and the other rendering callback functions are called on every repaint of the Scene View or Game View.

另请参阅：[ExecuteAlways](https://docs.unity3d.com/cn/2019.4/ScriptReference/ExecuteAlways.html)、[Application.IsPlaying](https://docs.unity3d.com/cn/2019.4/ScriptReference/Application.IsPlaying.html)、[runInEditMode](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour-runInEditMode.html)、[EditorApplication.QueuePlayerLoopUpdate](https://docs.unity3d.com/cn/2019.4/ScriptReference/EditorApplication.QueuePlayerLoopUpdate.html)。

```
// The PrintAwake script is placed on a GameObject.  The Awake function is
// called when the GameObject is started at runtime.  The script is also
// called by the Editor.  An example is when the Scene is changed to a
// different Scene in the Project window.
// The Update() function is called, for example, when the GameObject transform
// position is changed in the Editor.using UnityEngine;[ExecuteInEditMode]
public class PrintAwake : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Editor causes this Awake");
    }    void Update()
    {
        Debug.Log("Editor causes this Update");
    }
}
```

# GradientUsageAttribute

继承自：[PropertyAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyAttribute.html)

#### 描述

此属性用于为渐变配置 GradientField 和渐变编辑器的使用情况。

在渐变上使用此属性可将 GradientField 和渐变编辑器配置为将颜色视为 HDR 颜色或普通 LDR 颜色。

#### 变量

| [hdr](https://docs.unity3d.com/cn/2019.4/ScriptReference/GradientUsageAttribute-hdr.html) | 如果设置为 true，则渐变使用 HDR 颜色。 |
| ------------------------------------------------------------ | -------------------------------------- |
|                                                              |                                        |

#### 构造函数

| [GradientUsageAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/GradientUsageAttribute-ctor.html) | 渐变字段的属性。用于配置渐变编辑器的 GUI。 |
| ------------------------------------------------------------ | ------------------------------------------ |
|                                                              |                                            |

# GUITargetAttribute

#### 描述

允许控制针对哪个显示屏调用 OnGUI。

#### 构造函数

| [GUITargetAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/GUITargetAttribute-ctor.html) | 默认构造函数初始化要为所有可用显示屏调用的 OnGUI 的属性。 |
| ------------------------------------------------------------ | --------------------------------------------------------- |
|                                                              |                                                           |

# HeaderAttribute

继承自：[PropertyAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyAttribute.html)

#### 描述

使用该 [PropertyAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyAttribute.html) 在 Inspector 中的某些字段上方添加标题。

标题使用 [DecoratorDrawer](https://docs.unity3d.com/cn/2019.4/ScriptReference/DecoratorDrawer.html) 完成。

```
using UnityEngine;public class Example : MonoBehaviour
{
    [Header("Health Settings")]
    public int health = 0;
    public int maxHealth = 100;    [Header("Shield Settings")]
    public int shield = 0;
    public int maxShield = 0;
}
```

#### 变量

| [header](https://docs.unity3d.com/cn/2019.4/ScriptReference/HeaderAttribute-header.html) | 标题文本。 |
| ------------------------------------------------------------ | ---------- |
|                                                              |            |

#### 构造函数

| [HeaderAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/HeaderAttribute-ctor.html) | 在 Inspector 中的某些字段上方添加标题。 |
| ------------------------------------------------------------ | --------------------------------------- |
|                                                              |                                         |

# HelpURLAttribute

#### 描述

为类提供自定义文档 URL。

```
using UnityEngine;
using UnityEditor;[HelpURL("http://example.com/docs/MyComponent.html")]
public class MyComponent
{
}
```

#### 变量

| [URL](https://docs.unity3d.com/cn/2019.4/ScriptReference/HelpURLAttribute.URL.html) | 为该类指定的文档 URL。 |
| ------------------------------------------------------------ | ---------------------- |
|                                                              |                        |

#### 构造函数

| [HelpURLAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/HelpURLAttribute-ctor.html) | 使用文档 URL 初始化 HelpURL 属性。 |
| ------------------------------------------------------------ | ---------------------------------- |
|                                                              |                                    |

# HideInInspector

#### 描述

使变量不显示在 Inspector 中，但进行序列化。

```
using UnityEngine;public class Example : MonoBehaviour
{
    // Make the variable p not show up in the inspector
    // but be serialized.
    [HideInInspector]
    int p = 5;
}
```

# ImageEffectAfterScale

#### 描述

任何具有该属性的图像效果都将在动态分辨率阶段后渲染。

如果您希望在动态分辨率按比例缩放后应用图像效果，请添加该属性。效果将以全分辨率呈现，对于在某种程度上依赖于屏幕宽度和高度为特定大小的效果来说，这非常重要。

# ImageEffectAllowedInSceneView

#### 描述

任何具有该属性的图像效果都可以渲染到 Scene 视图摄像机中。

如果您希望将图像效果应用于 Scene 视图摄像机，请添加该属性。效果将在相同的位置应用，并且与来自开启该效果的摄像机的值相同。

# ImageEffectOpaque

#### 描述

任何具有该属性的图像效果都将在不透明几何形状之后但在透明几何形状之前渲染。

这使得大量使用深度缓冲器（SSAO 等）的效果仅影响不透明像素。该属性可用于通过后期处理减少场景中的视觉瑕疵。

# ImageEffectTransformsToLDR

#### 描述

使用 HDR 渲染时，有时可能需要在 ImageEffect 渲染期间切换到 LDR 渲染。

对图像效果使用该属性将使目标缓冲区成为 LDR 缓冲区， 并将剩余的图像效果管线切换到 LDR 模式。与该属性关联的图像效果负责 确保输出处于 LDR 范围内。

# ImageEffectUsesCommandBuffer

#### 描述

当图像效果是用 Command Buffer 实现的时，请使用此属性。

使用此属性时，Unity 将场景渲染到 RenderTexture 而不是实际目标中。请注意，Camera.forceIntoRenderTexture 可能有同样的效果，但仅限于某些情况。

# InspectorNameAttribute

继承自：[PropertyAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyAttribute.html)

#### 描述

对枚举值声明使用此属性可更改 Inspector 中显示的显示名称。

```
using UnityEngine;public enum ModelImporterIndexFormat
{
    Auto = 0,
    [InspectorName("16 bits")]
    UInt16 = 1,
    [InspectorName("32 bits")]
    UInt32 = 2,
}
```

#### 变量

| [displayName](https://docs.unity3d.com/cn/2019.4/ScriptReference/InspectorNameAttribute-displayName.html) | 要在 Inspector 中显示的名称。 |
| ------------------------------------------------------------ | ----------------------------- |
|                                                              |                               |

#### 构造函数

| [InspectorNameAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/InspectorNameAttribute-ctor.html) | 指定枚举值的显示名称。 |
| ------------------------------------------------------------ | ---------------------- |
|                                                              |                        |

# MinAttribute

继承自：[PropertyAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyAttribute.html)

#### 描述

用于使脚本中的 float 或 int 变量受限于特定最小值的属性。

#### 变量

| [min](https://docs.unity3d.com/cn/2019.4/ScriptReference/MinAttribute-min.html) | 允许的最小值。 |
| ------------------------------------------------------------ | -------------- |
|                                                              |                |

#### 构造函数

| [MinAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/MinAttribute-ctor.html) | 用于使脚本中的 float 或 int 变量受限于特定最小值的属性。 |
| ------------------------------------------------------------ | -------------------------------------------------------- |
|                                                              |                                                          |

# MultilineAttribute

继承自：[PropertyAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyAttribute.html)

#### 描述

用于通过多行文本字段编辑字符串的属性。

#### 构造函数

| [MultilineAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/MultilineAttribute-ctor.html) | 用于在多行文本区域中显示字符串值的属性。 |
| ------------------------------------------------------------ | ---------------------------------------- |
|                                                              |                                          |

# PreferBinarySerialization

#### 描述

使 ScriptableObject 派生类型优先使用二进制序列化（不考虑项目的资源序列化模式）。

对于包含大量数据的自定义资源类型，这非常有用。始终使它们存储为二进制可以提高读/写性能，以及在磁盘上生成更紧凑的表示。主要缺点是二进制资源文件不再人工可读，并且无法在版本控制软件中将其合并。

Unity 中的资源序列化对每个文件整体始终使用一致的序列化模式。因此，当资源文件包含多个资源时，强制特定资源使用二进制序列化可能无法始终满足。资源文件的序列化模式由该路径上的主资源控制。因此，在使用 AssetDabase.CreateAsset 和 [AssetDatabase.AddObjectToAsset](https://docs.unity3d.com/cn/2019.4/ScriptReference/AssetDatabase.AddObjectToAsset.html) 组合复杂资源时必须谨慎，以确保主资源是设置了此属性的对象。场景文件始终遵循在项目中配置的资源序列化模式，因而对于场景中嵌入的资源，会始终忽略 PreferBinarySerialization。

该属性只能应用于 ScriptableObject 派生类，对于所有其他类型，都会被忽略。

```c#
using UnityEngine;// Custom asset type that prefers binary serialization.
//
// Create a new asset file by going to "Asset/Create/Custom Data".
// If you open this new asset in a text editor, you can see how it
// is not affected by changing the project asset serialization mode.
//
[CreateAssetMenu]
[PreferBinarySerialization]
public class CustomData : ScriptableObject
{
    public float[] lotsOfFloatData = new[] { 1f, 2f, 3f };
    public byte[] lotsOfByteData = new byte[] { 4, 5, 6 };
}
```

# PropertyAttribute

#### 描述

用于派生自定义属性特性的基类。这可用于为脚本变量创建特性。

自定义特性可以与自定义 [PropertyDrawer](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyDrawer.html) 类连接，以控制具有该特性的脚本变量如何在 Inspector 中显示。

另请参阅：[PropertyDrawer](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyDrawer.html) 类。

# RangeAttribute

继承自：[PropertyAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyAttribute.html)

#### 描述

用于使脚本中的 float 或 int 变量受限于特定范围的属性。

使用此属性时，float 或 int 会在 Inspector 中显示为滑动条而不是默认数字字段。

```
using UnityEngine;public class Example : MonoBehaviour
{
    // This integer will be shown as a slider,
    // with the range of 1 to 6 in the Inspector
    [Range(1, 6)]
    public int integerRange;    // This float will be shown as a slider,
    // with the range of 0.2f to 0.8f in the Inspector
    [Range(0.2f, 0.8f)]
    public float floatRange;
}
```

#### 构造函数

| [RangeAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/RangeAttribute-ctor.html) | 用于使脚本中的 float 或 int 变量受限于特定范围的属性。 |
| ------------------------------------------------------------ | ------------------------------------------------------ |
|                                                              |                                                        |

# RequireComponent

#### 描述

RequireComponent 属性自动将所需的组件添加为依赖项。

向 GameObject 添加使用 RequireComponent 的脚本时，会自动将需要的组件添加到 GameObject 中。 这对避免设置错误非常有用。 例如，脚本可能要求始终向同一 GameObject 添加 Rigidbody。 使用 RequireComponent 可自动完成此工作，也就不会出现设置错误。 请注意，RequireComponent 只在组件添加到 GameObject 中时检查是否缺少依赖项。GameObject 缺少新依赖项的现有组件实例将不会自动添加这些依赖项。

```
using UnityEngine;// PlayerScript requires the GameObject to have a Rigidbody component
[RequireComponent(typeof(Rigidbody))]
public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }    void FixedUpdate()
    {
        rb.AddForce(Vector3.up);
    }
}
```

#### 构造函数

| [RequireComponent](https://docs.unity3d.com/cn/2019.4/ScriptReference/RequireComponent-ctor.html) | 需要一个组件。 |
| ------------------------------------------------------------ | -------------- |
|                                                              |                |

# RuntimeInitializeOnLoadMethodAttribute

继承自：[Scripting.PreserveAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/Scripting.PreserveAttribute.html)

#### 描述

允许在运行时加载游戏时不通过用户操作 初始化一个运行时类方法。

游戏加载后，将调用标记为 `[RuntimeInitializeOnLoadMethod]` 的 方法。这是在调用 `Awake` 方法后进行的。

**注意：**标记为 `[RuntimeInitializeOnLoadMethod]` 的方法的执行顺序是不确定的。

```c#
// Create a non-MonoBehaviour class which displays
// messages when a game is loaded.
using UnityEngine;class MyClass
{
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Debug.Log("After Scene is loaded and game is running");
    }    [RuntimeInitializeOnLoadMethod]
    static void OnSecondRuntimeMethodLoad()
    {
        Debug.Log("SecondMethod After Scene is loaded and game is running.");
    }
}
```

#### 变量

| [loadType](https://docs.unity3d.com/cn/2019.4/ScriptReference/RuntimeInitializeOnLoadMethodAttribute-loadType.html) | 设置 RuntimeInitializeOnLoadMethod 类型。 |
| ------------------------------------------------------------ | ----------------------------------------- |
|                                                              |                                           |

#### 构造函数

| [RuntimeInitializeOnLoadMethodAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/RuntimeInitializeOnLoadMethodAttribute-ctor.html) | 创建加载场景时使用的运行时类。 |
| ------------------------------------------------------------ | ------------------------------ |
|                                                              |                                |

# SelectionBaseAttribute

#### 描述

将此属性添加到脚本类，可将其 GameObject 标记为 Scene View 选取的选择基础对象。

在 Unity Scene View 中，当单击以选择对象时，Unity 将尝试找出为您选择的最佳对象。如果您单击作为预制件一部分的某个对象，则会选择该预制件的根，因为预制件根被视为选择基础。您也可以使其他对象被视为选择基础。您需要创建具有 SelectionBase 属性的脚本类，然后需要将该脚本添加到 GameObject。

# SerializeField

#### 描述

强制 Unity 对私有字段进行序列化。

当 Unity 对脚本进行序列化时，仅对公共字段进行序列化。 如果还需要 Unity 对私有字段进行序列化， 可以将 SerializeField 属性添加到这些字段。

Unity 将对所有脚本组件进行序列化，重新加载新程序集， 并从序列化的版本重新创建脚本组件。此 序列化是通过 Unity 内部序列化系统完成的；而不是通过 .NET 的序列化功能来完成。

序列化系统可执行以下操作：

\- 可序列化（可序列化类型的）公共非静态字段
\- 可序列化标记有 [SerializeField](https://docs.unity3d.com/cn/2019.4/ScriptReference/SerializeField.html) 属性的非公共非静态字段。
\- 不能序列化静态字段。
\- 不能序列化属性。


**可序列化的类型**

Unity 可序列化以下类型的字段：

\- 继承 UnityEngine.Object 的所有类，例如 GameObject、Component、MonoBehaviour、Texture2D、AnimationClip。
\- 所有基本数据类型，例如 int、string、float、bool。
\- 某些内置类型，例如 Vector2、Vector3、Vector4、Quaternion、Matrix4x4、Color、Rect、LayerMask。
\- 可序列化类型数组
\- 可序列化类型列表
\- 枚举
\- 结构

有关序列化的更多信息，请参阅[脚本序列化](https://docs.unity3d.com/cn/2019.4/Manual/script-Serialization.html)。

**注意：**如果在一个列表（或数组）中将一个元素放置两次，当此 列表被序列化时，将获得该元素的两个副本，而不是获得两次新列表中的一个副本。

**注意**：如果要序列化自定义 Struct 字段，则必须为该 Struct 给定 [System.Serializable] 属性。

**提示：**Unity 不会序列化 Dictionary，但您可以为键存储一个 List<> 和为值存储一个 List<>，然后在 Awake() 上将它们组合在非序列化字典中。这不能解决您需要修改字典 并将其“保存”回时出现的问题，但在许多其他情况下，这是一个方便的技巧。

```c#
using UnityEngine;public class SomePerson : MonoBehaviour
{
    //This field gets serialized because it is public.
    public string firstName = "John";    //This field does not get serialized because it is private.
    private int age = 40;    //This field gets serialized even though it is private
    //because it has the SerializeField attribute applied.
    [SerializeField]
    private bool hasHealthPotion = true;    void Start()
    {
        if (hasHealthPotion)
            Debug.Log("Person's first name: " + firstName + " Person's age: " + age);
    }
}
```

# SerializeReference

#### 描述

指示 Unity 将字段序列化为引用。

除非字段类型派生自 [UnityEngine.Object]，否则 Unity 在序列化对象时会将所有字段都序列化为值类型。 默认情况下，不支持多态字段，也无法在原生表示基于引用的拓扑，如图形。

建议从 ScriptableObject 派生字段类型，因为这样通常可以获得最佳性能。

但如果使用 ScriptableObjects 导致复杂程度无法接受，则用 [SerializeReference] 修饰字段可指示 Unity“按引用”而非“按值”序列化字段。

**注意：**
\- 字段类型不能是用于序列化 UnityEngine.Object 的类型。
\- 字段类型可以是抽象的。
\- 字段类型可以是接口。
\- 用 [SerializeReference] 修饰的通用列表和数组字段将属性应用于列表/数组的元素，而非列表/数组实例本身。
\- UnityEngine.Object 实例之间不能共享引用的值。例如，两个 MonoBehaviours 不能共享按引用序列化的对象。请使用 ScriptableObjects 而非共享数据。
\- 字段值可以是 null。
\- 字段值不能是通用类型（扩大的类型）的特化表示。
\- 分配给字段的动态实例/对象的类型必须是 [Serializable] 类型。
\- 字段类型也支持“System.Object”、“List<System.Object>”或“System.Object[]”类型。

```c#
using System;
using System.Collections.Generic;
using UnityEngine;public interface IShape {}[Serializable]
public class Cube : IShape
{
    public Vector3 size;
}[Serializable]
public class Thing
{
    public int weight;
}[ExecuteInEditMode]
public class BuildingBlocks : MonoBehaviour
{
    [SerializeReference]
    public List<IShape> inventory;    [SerializeReference]
    public System.Object bin;    [SerializeReference]
    public List<System.Object> bins;    void OnEnable()
    {
        if (inventory == null)
        {
            inventory = new List<IShape>()
            {
                new Cube() {size = new Vector3(1.0f, 1.0f, 1.0f)}
            };
            Debug.Log("Created list");
        }
        else
            Debug.Log("Read list");        if (bins == null)
        {
            // This is supported, the 'bins' serialized field is declared as holding a collection type.
            bins = new List<System.Object>() { new Cube(), new Thing() };
        }        if (bin == null)
        {
            // !! DO NOT USE !!
            // Although, this is syntaxically correct, it is NOT supported as a valid serialization construct because the 'bin' serialized field is declared as holding a single reference type.
            bin = new List<System.Object>() { new Cube() };
        }
    }
}
```

# SharedBetweenAnimatorsAttribute

#### 描述

SharedBetweenAnimatorsAttribute 是一个属性，它指定此 StateMachineBehaviour 仅应实例化一次，然后供所有 Animator 实例共享。此属性可减少每个控制器实例的内存占用量。

由程序员选择哪个 StateMachineBehaviour 可使用此属性。注意，如果 StateMachineBehaviour 更改某个成员变量，则会影响使用它的其他所有 Animator 实例。 另请参阅：[StateMachineBehaviour](https://docs.unity3d.com/cn/2019.4/ScriptReference/StateMachineBehaviour.html) 类。

```c#
using UnityEngine;[SharedBetweenAnimators]
public class AttackBehaviour : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("OnStateEnter");
    }
}
```

# SpaceAttribute

继承自：[PropertyAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyAttribute.html)

#### 描述

使用此 [PropertyAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyAttribute.html) 可在 Inspector 中添加一些间距。

间距是通过 [DecoratorDrawer](https://docs.unity3d.com/cn/2019.4/ScriptReference/DecoratorDrawer.html) 完成的。

```
using UnityEngine;public class Example : MonoBehaviour
{
    int health = 0;
    int maxHealth = 100;    [Space(10)] // 10 pixels of spacing here.    int shield = 0;
    int maxShield = 0;
}
```

#### 变量

| [height](https://docs.unity3d.com/cn/2019.4/ScriptReference/SpaceAttribute-height.html) | 间距（以像素为单位）。 |
| ------------------------------------------------------------ | ---------------------- |
|                                                              |                        |

#### 构造函数

| [SpaceAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/SpaceAttribute-ctor.html) | 使用此 DecoratorDrawer 可在 Inspector 中添加一些间距。 |
| ------------------------------------------------------------ | ------------------------------------------------------ |
|                                                              |                                                        |

# TextAreaAttribute

继承自：[PropertyAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyAttribute.html)

#### 描述

属性，用于通过高度灵活且可滚动的区域编辑字符串。

您可以指定 TextArea 的最小行数和最大行数，该字段将根据文本的大小进行扩展。如果文本大于可用区域，则会显示滚动条。

**注意：**最大行数指的是 TextArea 的最大大小。用户输入的行数没有最大值。

![img](Image/TextAreaAttribute.png)\ *Inspector 中的文本区域。*

```
using UnityEngine;public class TextAreaExample : MonoBehaviour
{
    [TextArea]
    public string MyTextArea;
}
```

#### 变量

| [maxLines](https://docs.unity3d.com/cn/2019.4/ScriptReference/TextAreaAttribute-maxLines.html) | 文本区域在开始使用滚动条前可显示的最大行数。 |
| ------------------------------------------------------------ | -------------------------------------------- |
| [minLines](https://docs.unity3d.com/cn/2019.4/ScriptReference/TextAreaAttribute-minLines.html) | 文本区域将使用的最小行数。                   |

#### 构造函数

| [TextAreaAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/TextAreaAttribute-ctor.html) | 属性，用于通过高度灵活且可滚动的区域编辑字符串。 |
| ------------------------------------------------------------ | ------------------------------------------------ |
|                                                              |                                                  |

# TooltipAttribute

继承自：[PropertyAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/PropertyAttribute.html)

#### 描述

为 Inspector 窗口中的字段指定工具提示。

![img](https://docs.unity3d.com/cn/2019.4/StaticFiles/ScriptRefImages/tooltip.png)\ *工具提示悬停在所添加到的类上。*

下面的脚本中添加了一个 `health`。它向用户提供有关 `health` 变量的值的范围信息。建议的范围在 `TooltipAttribute` 字符串中提供。

```
using UnityEngine;public class Example : MonoBehaviour
{
    [Tooltip("Health value between 0 and 100.")]
    int health = 0;
}
```

#### 变量

| [tooltip](https://docs.unity3d.com/cn/2019.4/ScriptReference/TooltipAttribute-tooltip.html) | 工具提示文本。 |
| ------------------------------------------------------------ | -------------- |
|                                                              |                |

#### 构造函数

| [TooltipAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/TooltipAttribute-ctor.html) | 为字段指定工具提示。 |
| ------------------------------------------------------------ | -------------------- |
|                                                              |                      |

# UnityAPICompatibilityVersionAttribute

#### 描述

声明一个与特定 Unity API 兼容（API 兼容）的程序集。内部工具用它来避免为确定程序集是否可以使用旧的 Unity API 而处理程序集。

#### 变量

| [version](https://docs.unity3d.com/cn/2019.4/ScriptReference/UnityAPICompatibilityVersionAttribute-version.html) | Unity API 版本。 |
| ------------------------------------------------------------ | ---------------- |
|                                                              |                  |

#### 构造函数

| [UnityAPICompatibilityVersionAttribute](https://docs.unity3d.com/cn/2019.4/ScriptReference/UnityAPICompatibilityVersionAttribute-ctor.html) | 初始化 UnityAPICompatibilityVersionAttribute 的新实例。 |
| ------------------------------------------------------------ | ------------------------------------------------------- |
|                                                              |                                                         |