# [Gizmos](https://docs.unity3d.com/cn/2019.4/ScriptReference/Gizmos.html)

## 描述

辅助图标用于协助在 Scene 视图中进行视觉调试或设置。

所有辅助图标绘图都必须在此脚本的 [OnDrawGizmos](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour.OnDrawGizmos.html) 或 [OnDrawGizmosSelected](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour.OnDrawGizmosSelected.html) 函数中进行。\ 每一帧都调用 [OnDrawGizmos](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour.OnDrawGizmos.html)。在 [OnDrawGizmos](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour.OnDrawGizmos.html) 中渲染的所有辅助图标均可选择。 仅在选择了附加此脚本的对象时才调用 [OnDrawGizmosSelected](https://docs.unity3d.com/cn/2019.4/ScriptReference/MonoBehaviour.OnDrawGizmosSelected.html)。

一般用来在场景中对一些特殊的物体绘制辅助线 方便调整,