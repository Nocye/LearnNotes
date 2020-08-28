### 这个组件是在游戏空间中遮罩Sprite Render,与UI的Mask一样

| Sprite            | 用于遮罩的精灵图片                                           |
| ----------------- | ------------------------------------------------------------ |
| **Alpha Cutoff**  | **如果 Alpha 包含透明区域和不透明区域之间的混合，则可以手动确定所显示区域的分界点。通过调整 Alpha Cutoff 滑动条即可更改此分界点。**(简单来说就是让边界圆滑) |
| Custom Range      | 自定义遮罩层级的范围,打开时,Front起始层级,Back结束层级(层级越后越优先显示),关闭时,可以使用**Sorting Group**组件来辅助使用,遮罩所有子物体, |
| Sprite Sort Point | 默认情况下，精灵的 **[Sort Point（排序点）](https://docs.unity.cn/Manual/class-SpriteRenderer.html#sortpoint)**设置为其 **Center**，因此 Unity 会测量摄像机的变换位置与精灵的中心之间的距离，以确定它们在排序过程中的渲染顺序。另一种选项是将精灵的 **Sort Point** 设置为世界空间中的 **Pivot** 位置。为此，请在精灵的 [Sprite Renderer](https://docs.unity.cn/cn/2019.4/Manual/class-SpriteRenderer.html) 属性设置中选择 **Pivot** 选项，然后在 [Sprite Editor](https://docs.unity.cn/cn/2019.4/Manual/SpriteEditor.html) 中编辑精灵的 Pivot 位置。 |

对于需要在场景中显示的SpeiteRender遮罩的需求 可以用这个组件实现,配合Sorting Group可以很方便的实现遮罩一组物体.

