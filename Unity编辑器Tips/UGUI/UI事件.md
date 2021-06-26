###### IPointerEnterHandler - OnPointerEnter - 当指针进入对象时调用

###### IPointerExitHandler - OnPointerExit - 当指针退出对象时调用

###### IPointerDownHandler - OnPointerDown - 在对象上按下指针时调用

###### IPointerUpHandler - OnPointerUp - 松开指针时调用（在指针正在点击的游戏对象上调用）

当按下后离开之前的UI时再抬起，会在之前处理按下事件的UI上调用

###### IPointerClickHandler - OnPointerClick - 在同一对象上按下再松开指针时调用

光标不离开UI的情况下，完成一次按下 抬起后执行，如果按下后离开了UI再抬起，不触发



>###### IInitializePotentialDragHandler - OnInitializePotentialDrag - 在找到拖动目标时调用，可用于初始化值
>
>在可拖动UI上按下时触发，触发顺序在OnPointerDown之后
>
>###### IBeginDragHandler - OnBeginDrag - 即将开始拖动时在拖动对象上调用
>
>在Init之后，鼠标开始拖动时触发，如果init之后鼠标不拖动直接松开，不触发
>
>###### IEndDragHandler - OnEndDrag - 拖动完成时在拖动对象上调用
>
>拖动结束时触发，在OnDrop之后触发。
>
>###### IDropHandler - OnDrop - 在拖动目标对象上调用
>
>如果拖动结束时，
>
>1. 当前指针位置没有任何其他UI，自己继承了IDropHandler，调用自己的，否则不调用。
>
>2. 如果当前位置有其他UI，但没有继承Drop接口，不调用，包括自己。
>
>3. 如果指针位置有其他UI，且继承了接口，调用指针处UI的Drop。
>
>   需要注意的是，如果正在被拖动的UI层级在其他UI之上，覆盖了其他UI，阻挡了事件的射线，参考第一条。
>
>注：以上方法只会在继承下文IDragHandler接口后才会调用，且begin和end不需要成对继承，可以只继承任意一个单独接口，都会调用
>
>###### IDragHandler - OnDrag - 发生拖动时在拖动对象上每帧调用

###### 

###### IScrollHandler - OnScroll - 当鼠标滚轮滚动时调用

###### IUpdateSelectedHandler - OnUpdateSelected - 每次勾选时在选定对象上调用

在当前被选择的物体上每帧调用

###### ISelectHandler - OnSelect - 当对象成为选定对象时调用

一般通过EventSystem.current.SetSelectdGameObject时调用

###### IDeselectHandler - OnDeselect - 取消选择选定对象时调用

选定别的物体时，先调用之前物体的OnDeselect，再调用新物体的OnSelect，注意的是点击空白区域时CurrentSelected为空，也会触发这个事件。

###### IMoveHandler - OnMove - 发生移动事件（上、下、左、右等）时调用

当按下对应的按键时，在当前选中的物体上调用，UGUI用这个来做Selectable的导航，

###### ISubmitHandler - OnSubmit - 按下 Submit 按钮时调用

###### ICancelHandler - OnCancel - 按下 Cancel 按钮时调用

