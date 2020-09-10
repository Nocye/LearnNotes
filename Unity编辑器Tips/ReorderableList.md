## ReorderableList

可重新排序列表是UnityEditor中支持的一种类型,可以让List字段非常方便的进行拖拽更改顺序等操作

这些委托可以直接调用,比如绘制尾部按钮时直接调用添加和删除回调,就可以很方便的进行操作

> 坑注意:如果使用DoLayoutList();而不是DoList(Rect);给定一个矩形来绘制这个列表的话,假如列表超过了窗口大小,且你在窗口四周固定位置绘制了其他按钮,那么就会导致这些按钮无法被点击到,按钮点击事件会被列表的点击覆盖,虽然显示在列表层之上,这时候需要通过手算布局来计算出列表应该出现在的试图范围,例子:
>
> ```c#
> //绘制列表,在尾部空出一行,给按钮
>             Rect scrollRect = new Rect(0, 0, _setterWindow.position.width,
>                 _setterWindow.position.height - EditorGUIUtility.singleLineHeight);
>             Rect viewRect = new Rect(scrollRect.x, scrollRect.y, scrollRect.width, setList.GetHeight());
>             //因为显示出纵向滚动条时会导致view略微变大,导致横向滚动条也出现,影响观感,直接禁掉
>             scrollPosition = GUI.BeginScrollView(scrollRect, scrollPosition, viewRect, false, false, GUIStyle.none, GUI.skin.verticalScrollbar);
>             setList.DoList(viewRect);
>             GUI.EndScrollView();
>             DrawBottomButton();
> ```
>
> 

> **drawHeaderCallback**
>
> 绘制标题时的回调
>
> rect:表头的绘制区域
>
> **drawFooterCallback**
>
> 绘制尾部回调,当想重绘LIst的添加和删除按钮的时候添加这个委托,如果为空则不绘制删除和添加按钮
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
> 是否可移除移除元素的回调(用于判断删除按钮是否可以被点击)
>
> **onCanAddCallback**
>
> 是否可以添加元素的回调(用于判断添加按钮是否可以被点击)
>
> **onChangedCallback**
>
> 列表改变时的回调

> ```c#
> public static ReorderableList.Defaults defaultBehaviours
> ```
>
> 可重新排序列表的默认行为,反编译这部分代码后可以看到unity官方编写的可排序列表的绘制实现,是一个非常好的参考