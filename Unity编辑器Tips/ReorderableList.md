## ReorderableList

可重新排序列表是UnityEditor中支持的一种类型,可以让List字段非常方便的进行拖拽更改顺序等操作

> **drawHeaderCallback**
>
> 绘制标题时的回调
>
> rect:表头的绘制区域
>
> **drawFooterCallback**
>
> 绘制尾部回调
>
> **drawElementCallback**
>
> 确定如何绘制list中的元素
>
> | rect      | 元素区域的大小            |
> | :-------- | :------------------------ |
> | index     | 列表的索引                |
> | isActive  | 是否激活,鼠标选中就激活   |
> | isFocused | 是否焦点,鼠标选中就是焦点 |
>
> **drawElementBackgroundCallback** 
>
> 确定如何绘制每个元素的背景
>
> **drawNoneElementCallback**
>
> 确定没有元素时如何绘制
>
> **elementHeightCallback**
>
> 确定每个元素的绘制高度
>
> **onReorderCallbackWithDetails**
>
> 详细信息重新排序时的回调
>
> **onReorderCallback**
>
> list重新排序时的回调
>
> **onSelectCallback**
>
> 选中列表时的回调
>
> **onAddCallback**
>
> 添加元素时的回调
>
> **onAddDropdownCallback**
>
> 添加按钮下拉选项的回调
>
> **onRemoveCallback**
>
> 删除元素时的回调
>
> **onMouseDragCallback**
>
> 鼠标拖拽时的回调
>
> **onMouseUpCallback**
>
> 鼠标抬起时的回调
>
> **onCanRemoveCallback**
>
> 是否显示可移除按钮的回调
>
> **onCanAddCallback**
>
> 是否显示添加按钮的回调
>
> **onChangedCallback**
>
> 列表改变时的回调

