using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.ForbiddenByte.OSA.Core;
using Com.ForbiddenByte.OSA.CustomParams;

namespace BDT
{
    [System.Serializable]
    public class MyParams : BaseParamsWithPrefab
    {
        [Header("数据设置")] public List<ItemData> dataList = new List<ItemData>();

        [Header("动画设置")] public bool enableEntranceAnimation = true;
        public AnimationDelayController.DelayMode animationDelayMode = AnimationDelayController.DelayMode.Sequential;
        public float animationBaseDelay = 0.05f;
        public int maxAnimationCount = 20;
    }

    public class MyScrollViewAdapter : OSA<MyParams, MyItemViewsHolder>
    {
        private ItemEntranceAnimator _entranceAnimator = new ItemEntranceAnimator();
        private AnimationDelayController _delayController = new AnimationDelayController();
        private bool _isInitializing = false;

        protected override void Start()
        {
            // 根据参数设置动画控制器
            SetupAnimationControllers();

            // 根据设备性能调整
            AdjustAnimationPerformance();

            base.Start();
        }

        private void SetupAnimationControllers()
        {
            _delayController.delayMode = Parameters.animationDelayMode;
            _delayController.baseDelay = Parameters.animationBaseDelay;
            _entranceAnimator.SetMaxAnimationCount(Parameters.maxAnimationCount);
        }

        private void AdjustAnimationPerformance()
        {
            // 根据设备性能调整最大动画数量
            int maxAnimations = SystemInfo.processorCount > 4
                ? Parameters.maxAnimationCount
                : Parameters.maxAnimationCount / 2;
            _entranceAnimator.SetMaxAnimationCount(maxAnimations);

            // 低端设备使用更简单的延迟模式
            if (SystemInfo.systemMemorySize < 4000)
            {
                _delayController.delayMode = AnimationDelayController.DelayMode.Instant;
            }
        }

        protected override MyItemViewsHolder CreateViewsHolder(int itemIndex)
        {
            var vh = new MyItemViewsHolder();
            vh.Init(_Params.ItemPrefab, _Params.Content, itemIndex);
            return vh;
        }

        protected override void UpdateViewsHolder(MyItemViewsHolder newOrRecycled)
        {
            // 获取数据
            if (newOrRecycled.ItemIndex < 0 || newOrRecycled.ItemIndex >= Parameters.dataList.Count)
                return;

            var model = Parameters.dataList[newOrRecycled.ItemIndex];
            newOrRecycled.UpdateFromModel(model);
            ScheduleComputeVisibilityTwinPass();
            // 处理入场动画
            if (Parameters.enableEntranceAnimation &&
                _entranceAnimator.ShouldPlayEntranceAnimation(newOrRecycled.ItemIndex))
            {
                float delay = _delayController.GetDelayForItem(newOrRecycled.ItemIndex);
                newOrRecycled.PlayEntranceAnimation(delay);

                _entranceAnimator.MarkItemAsAnimated(newOrRecycled.ItemIndex);
                _delayController.IncrementAnimationCount();
            }
            else
            {
                newOrRecycled.ResetAnimationState();
            }
        }

        protected override void OnBeforeRecycleOrDisableViewsHolder(MyItemViewsHolder vh, int newItemIndex)
        {
            vh.ResetAnimationState();
            base.OnBeforeRecycleOrDisableViewsHolder(vh, newItemIndex);
        }

        public override void ChangeItemsCount(ItemCountChangeMode changeMode, int itemsCount,
            int indexIfInsertingOrRemoving = -1, bool contentPanelEndEdgeStationary = false,
            bool keepVelocity = false)
        {
            if (changeMode == ItemCountChangeMode.RESET)
            {
                _isInitializing = true;
                _entranceAnimator.Reset();
                _delayController.Reset();
            }

            base.ChangeItemsCount(changeMode, itemsCount, indexIfInsertingOrRemoving,
                contentPanelEndEdgeStationary, keepVelocity);
        }

        protected override void OnItemsRefreshed(int prevCount, int newCount)
        {
            base.OnItemsRefreshed(prevCount, newCount);
            Log.Error("refreshed");
            if (_isInitializing)
            {
                _entranceAnimator.OnRefreshComplete();
                _isInitializing = false;
                //StartCoroutine(DelayedRefreshComplete());
            }
        }

        private IEnumerator DelayedRefreshComplete()
        {
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            _entranceAnimator.OnRefreshComplete();
            _isInitializing = false;
        }

        // 公共方法
        public void RefreshWithAnimation()
        {
            if (Parameters.dataList != null)
            {
                ResetItems(Parameters.dataList.Count);
            }
        }

        public void AddItem(ItemData newItem)
        {
            if (Parameters.dataList == null)
                Parameters.dataList = new List<ItemData>();

            Parameters.dataList.Add(newItem);
            RefreshWithAnimation();
        }

        public void RemoveItem(int index)
        {
            if (Parameters.dataList != null && index >= 0 && index < Parameters.dataList.Count)
            {
                Parameters.dataList.RemoveAt(index);
                RefreshWithAnimation();
            }
        }

        public void ClearAll()
        {
            if (Parameters.dataList != null)
            {
                Parameters.dataList.Clear();
                ResetItems(0);
            }
        }
    }
}