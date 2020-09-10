> # ExecuteInEditMode
>
> class in UnityEngine
>
> ## 描述
>
> 使脚本的所有实例都在编辑模式下执行。
>
> 默认情况下，仅在播放模式下执行 MonoBehaviours。通过添加此属性，MonoBehaviour 的任何实例都将在编辑器处于编辑模式时执行其回调函数。
>
> 此属性正在逐步被淘汰，因为它不考虑预制件模式。如果在预制件模式下编辑一个带有 MonoBehaviour 并启用了此属性的预制件，然后进入播放模式，则编辑器将退出预制件模式，以防止由仅用于播放模式的逻辑引起的预制件意外修改。
>
> 要指示 MonoBehaviour 正确考虑了预制件模式并且在播放模式期间以预制件模式打开是安全的，可以使用属性 [ExecuteAlways](https://docs.unity3d.com/cn/2019.4/ScriptReference/ExecuteAlways.html) 取代此处的属性。
>
> 以下函数不像它们在播放模式下那样被不断调用。
> \- [Update](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour.Update.html) is only called when something in the Scene changed.
> \- [OnGUI](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour.OnGUI.html) is called when the Game View receives a non-editor-only [Event](https://docs.unity3d.com/cn/2019.4/ScriptReference/Event.html) that it does not use (e.g., [EventType.ScrollWheel](https://docs.unity3d.com/cn/2019.4/ScriptReference/EventType.ScrollWheel.html)) and does not forward to the Editor's keyboard shortcut system (e.g., [EventType.KeyDown](https://docs.unity3d.com/cn/2019.4/ScriptReference/EventType.KeyDown.html), [EventType.KeyUp](https://docs.unity3d.com/cn/2019.4/ScriptReference/EventType.KeyUp.html)). Events forwarded to the Game View are enqueued and are not guaranteed to be processed immediately.
> \- [OnRenderObject](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour.OnRenderObject.html) and the other rendering callback functions are called on every repaint of the Scene View or Game View.
>
> 另请参阅：[ExecuteAlways](https://docs.unity3d.com/cn/2019.4/ScriptReference/ExecuteAlways.html)、[Application.IsPlaying](https://docs.unity3d.com/cn/2019.4/ScriptReference/Application.IsPlaying.html)、[runInEditMode](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour-runInEditMode.html)、[EditorApplication.QueuePlayerLoopUpdate](https://docs.unity3d.com/cn/2019.4/ScriptReference/EditorApplication.QueuePlayerLoopUpdate.html)。



> # ExecuteAlways
>
> class in UnityEngine
>
> ## 描述
>
> 使脚本的实例在播放模式期间以及编辑时始终执行。
>
> 默认情况下，MonoBehaviours 仅在播放模式下并且仅当它们位于包含用户场景的主阶段中的游戏对象上时才执行。它们不会在编辑模式下执行，也不在预制件模式下编辑的对象上执行，即使此时在播放模式下也是如此。通过添加此属性，MonoBehaviour 的任何实例都将始终执行其回调函数。
>
> 当您希望脚本作为编辑器工具的一部分执行某些操作时，即可使用 [ExecuteAlways] 属性，不一定要与构建播放器和播放模式中发生的播放逻辑相关。有时，此类脚本的“播放”功能与其“编辑模式”功能相同，而其他情况下则相差很大。
>
> 使用此属性的 MonoBehaviour 必须确保它们在编辑模式下或者在对象不是游戏世界的一部分时不会运行可能导致对象被错误修改的播放逻辑。为达到此目的，可以使用 [Application.IsPlaying](https://docs.unity3d.com/cn/2019.4/ScriptReference/Application.IsPlaying.html)，在其中，脚本可以传入自己的游戏对象以检查它是否是游戏世界的一部分。
>
> 如果 MonoBehaviour 在播放模式下运行播放逻辑并且无法检查其游戏对象是否是游戏世界的一部分，则在预制件模式下编辑的预制件可能会被仅用作游戏世界一部分的逻辑错误地修改和保存。
>
> 如果您的脚本使用静态变量或单例模式，则应确保属于游戏世界的脚本实例和不属于游戏世界的实例不会通过这些变量或单例意外地相互影响。
>
> 在不属于游戏世界的对象上，不会像其他情况那样不断地调用以下函数。
> \- [Update](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour.Update.html) is only called when something in the Scene changed.
> \- [OnGUI](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour.OnGUI.html) is called when the Game view receives a non-editor-only [Event](https://docs.unity3d.com/cn/2019.4/ScriptReference/Event.html) that it does not use (e.g., [EventType.ScrollWheel](https://docs.unity3d.com/cn/2019.4/ScriptReference/EventType.ScrollWheel.html)) and does not forward to the Editor's keyboard shortcut system (e.g., [EventType.KeyDown](https://docs.unity3d.com/cn/2019.4/ScriptReference/EventType.KeyDown.html), [EventType.KeyUp](https://docs.unity3d.com/cn/2019.4/ScriptReference/EventType.KeyUp.html)). Events forwarded to the Game view are enqueued and are not guaranteed to be processed immediately.
> \- [OnRenderObject](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour.OnRenderObject.html) and the other rendering callback functions are called on every repaint of the Scene view or Game view.
>
> 另请参阅：[Application.IsPlaying](https://docs.unity3d.com/cn/2019.4/ScriptReference/Application.IsPlaying.html)、[runInEditMode](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour-runInEditMode.html)、[EditorApplication.QueuePlayerLoopUpdate](https://docs.unity3d.com/cn/2019.4/ScriptReference/EditorApplication.QueuePlayerLoopUpdate.html)。