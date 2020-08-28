# 排序组

**排序组 (Sorting Group)** 可以将具有[精灵渲染器 (Sprite Renderer)](https://docs.unity.cn/cn/2019.4/Manual/class-SpriteRenderer.html) 的游戏对象分组在一起，并控制这些渲染器渲染精灵的顺序。Unity 将同一排序组中的精灵渲染器一起渲染，就好像它们是单个游戏对象一样。比如一个2D物体通过多张精灵图片组成,如果不使用这个组件可能会造成重叠时层级错误的问题,使用这个组件,把多张精灵视为同一组渲染,就不会产生这个问题.

| 属性               | 功能                                                         |
| :----------------- | :----------------------------------------------------------- |
| **Sorting Layer**  | 从此下拉菜单中选择或添加[排序图层](https://docs.unity.cn/Manual/class-TagManager.html#SortingLayers)来确定排序组在渲染队列中的位置。Unity 通过排序图层在 Sorting Layer 设置中的位置来确定排序图层的顺序，按照排序图层在列表中显示的顺序来渲染排序图层。请参阅[标签和图层 (Tags and Layers)](https://docs.unity.cn/Manual/class-TagManager.html#SortingLayers) 以了解有关设置排序图层的信息。 |
| **Order in Layer** | 设置此排序组在其__排序图层__中的渲染顺序。Unity 首先在渲染队列中排入具有较低值的渲染器，使这些渲染器显示在具有较高值的渲染器之前。 |

## 对排序组中的渲染器进行排序

Unity 按 **Sorting Layer** 和 **Order in Layer** [渲染器属性](https://docs.unity.cn/cn/2019.4/Manual/class-SpriteRenderer.html)对同一排序组中的所有渲染器进行排序。在此排序过程中，Unity 不会考虑每个渲染器的 **Distance to Camera** 属性。实际上，Unity 会根据包含 Sorting Group 组件的根游戏对象的位置，为整个排序组（包括其所有子渲染器）设置 Distance to Camera 值。

Unity 相对于场景中其他渲染器和排序组对排序组进行排序时，排序组的内部排序顺序保持不变。

下图显示了排序过程。

![排序组内部排序过程。](https://raw.githubusercontent.com/Nocye/ImageBed/master/20200828181537.png)排序组内部排序过程。

Unity 将属于同一排序组的所有渲染器视为单个图层，并且基于未分组渲染器的 **Sorting Layer** 和 **Order in Layer** 属性设置对渲染器进行排序。

### 粒子系统

Editor 将一个作为排序组子项的[粒子系统](https://docs.unity.cn/cn/2019.4/Manual/class-ParticleSystem.html)视为该排序组内的另一渲染器，并基于 **Sorting Layer** 和 **Order in Layer** 属性设置将这个粒子系统与其他渲染器一起进行内部排序。__

Unity 将粒子系统与排序组内的其他渲染器一起排序时，会忽略粒子系统的 **Sorting Fudge** 值。

### 嵌套的排序组

嵌套的排序组是具有父排序组的一种排序组。Unity 首先对嵌套排序组中的渲染器进行排序，然后对其父级进行排序（请参阅[对排序组中的渲染器进行排序](https://docs.unity.cn/cn/2019.4/Manual/class-SortingGroup.html#InternalSort)）。

Unity 确定嵌套排序组的内部排序顺序后，会将嵌套排序组与父排序组中的其他渲染器或排序组一起进行排序。一个嵌套排序组可以有一个子嵌套排序组。Unity 首先对最里面的子组排序，然后对其各自父级排序。

下图提供了嵌套排序组的排序过程示例。

![嵌套排序组的排序过程。](https://raw.githubusercontent.com/Nocye/ImageBed/master/20200828181547.png)嵌套排序组的排序过程。

## 使用排序组

创建 2D 多精灵角色的最常见方法是在 Hierarchy 窗口中一起排列多个精灵渲染器并将它们设置为子代，从而形成一个角色。这时可以使用__排序组__来协助管理这种复杂的多精灵角色。

在以下示例中，精灵渲染器属于同一__排序图层 (Sorting Layer)**，但是具有不同的** Order in Layer__ 值。Unity 按照您希望角色的不同部分的出现顺序对这些部分进行排序。

![一个角色预制件及其各个部分位于一个层级视图中。](https://raw.githubusercontent.com/Nocye/ImageBed/master/20200828181607.png)一个角色预制件及其各个部分位于一个层级视图中。

配置排序组和排序图层之后，可以将角色另存为[预制件](https://docs.unity.cn/cn/2019.4/Manual/Prefabs.html)，并根据需要进行多次克隆。

但是，预制件精灵全部具有相同的 **Sorting Layer** 和 **Order in Layer** 值，并且与其他预制件一起渲染到相同图层，这可能导致一个预制件角色的不同部分错误地相交和分层。

![两个预制件的精灵错误相交，因为 Unity 在相同图层上渲染精灵。](https://raw.githubusercontent.com/Nocye/ImageBed/master/20200828181620.png)两个预制件的精灵错误相交，因为 Unity 在相同图层上渲染精灵。

为了确保预制件的渲染顺序一致以便正确显示，请将 Sorting Group 组件添加到每个预制件的根游戏对象。保存编辑后的预制件，使所有当前和将来的预制件实例也具有 Sorting Group 组件。

每个预制件应具有一个 Sorting Group 组件，且该组件的 **Sorting Layer** 和 **Order in Layer** 属性设置相同。这可能导致在同一__排序图层__上的预制件中的渲染器具有不一致的渲染方式，因为这些渲染器在[渲染器队列](https://docs.unity.cn/cn/2019.4/Manual/SL-SubShaderTags.html)中的优先级相同。

为了避免此问题，请向每个预制件的 Sorting Group 组件提供一个唯一的 **Order in Layer** 值。Unity 首先渲染 **Order in Layer** 值较小的排序组，然后值较大的排序组将覆盖值较小的排序组。请参阅[标签和图层 (Tags and Layers)](https://docs.unity.cn/cn/2019.4/Manual/class-TagManager.html) 以了解关于对__排序图层__进行编辑和重新排序的更多信息。 ![img](https://raw.githubusercontent.com/Nocye/ImageBed/master/20200828181641.png)

每个预制件都有一个 Sorting Group 组件，且该组件具有唯一的 **Order in Layer** 值，因此可以确保 Unity 正确渲染每个角色及其部分。