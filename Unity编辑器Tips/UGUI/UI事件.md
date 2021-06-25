###### IPointerEnterHandler - OnPointerEnter - 当指针进入对象时调用

###### IPointerExitHandler - OnPointerExit - 当指针退出对象时调用

###### IPointerDownHandler - OnPointerDown - 在对象上按下指针时调用

###### IPointerUpHandler - OnPointerUp - 松开指针时调用（在指针正在点击的游戏对象上调用）

当按下后离开之前的UI时再抬起，会在之前处理按下事件的UI上调用

###### IPointerClickHandler - OnPointerClick - 在同一对象上按下再松开指针时调用

光标不离开UI的情况下，完成一次按下 抬起后执行，如果按下后离开了UI再抬起，不触发

###### IInitializePotentialDragHandler - OnInitializePotentialDrag - 在找到拖动目标时调用，可用于初始化值

###### IBeginDragHandler - OnBeginDrag - 即将开始拖动时在拖动对象上调用

###### IDragHandler - OnDrag - 发生拖动时在拖动对象上调用

###### IEndDragHandler - OnEndDrag - 拖动完成时在拖动对象上调用

###### IDropHandler - OnDrop - 在拖动目标对象上调用

###### IScrollHandler - OnScroll - 当鼠标滚轮滚动时调用

###### IUpdateSelectedHandler - OnUpdateSelected - 每次勾选时在选定对象上调用

###### ISelectHandler - OnSelect - 当对象成为选定对象时调用

###### IDeselectHandler - OnDeselect - 取消选择选定对象时调用

###### IMoveHandler - OnMove - 发生移动事件（上、下、左、右等）时调用

###### ISubmitHandler - OnSubmit - 按下 Submit 按钮时调用

###### ICancelHandler - OnCancel - 按下 Cancel 按钮时调用