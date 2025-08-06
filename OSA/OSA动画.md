OSA的动画控制 主要分为滚动列表内部维护一个状态机,来控制动画的播放时机,队列等信息.动画是每个item自己单独持有,状态机只控制动画的播放时机(delay),是否播放
例子:在ChangeItemCount的 changeMode为Reset时,进入动画播放状态
```csharp
public override void ChangeItemsCount(ItemCountChangeMode changeMode, int itemsCount,
            int indexIfInsertingOrRemoving = -1, bool contentPanelEndEdgeStationary = false,
            bool keepVelocity = false)
        {
            if (changeMode == ItemCountChangeMode.RESET)
            {
                animFsm.EnterPlayAnimationState();
            }

            base.ChangeItemsCount(changeMode, itemsCount, indexIfInsertingOrRemoving,
                contentPanelEndEdgeStationary, keepVelocity);
        }
```
状态机大概有这几种属性:
1. 当前index是否可以播放动画
2. 记录当前正在播放动画的index
3. 重置动画状态

至于动画需要用什么方式实现,用animator,还是tween,或者自己代码中实现,没有限制,根据
根据AI提示当数据刷新后,如果item是可变大小,即使用了ContentSizeFitter组件并继承了ForRebuild等函数时,可能会出现动画开始时尺寸计算还没结束的问题,可能要控制动画开始播放的时机,不过暂时没有遇到 