using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEntranceAnimator
{
    private HashSet<int> _animatedItems = new HashSet<int>();
    private bool _isFirstRefresh = true;
    private int _maxVisibleItems = 20;
    
    public bool ShouldPlayEntranceAnimation(int itemIndex)
    {
        if (!_isFirstRefresh) return false;
        if (_animatedItems.Count >= _maxVisibleItems) return false;
        return !_animatedItems.Contains(itemIndex);
    }
    
    public void MarkItemAsAnimated(int itemIndex)
    {
        _animatedItems.Add(itemIndex);
    }
    
    public int GetAnimatedItemsCount()
    {
        return _animatedItems.Count;
    }
    
    public void SetMaxAnimationCount(int maxCount)
    {
        _maxVisibleItems = maxCount;
    }
    
    public void Reset()
    {
        _animatedItems.Clear();
        _isFirstRefresh = true;
    }
    
    public void OnRefreshComplete()
    {
        _isFirstRefresh = false;
    }
}

public class AnimationDelayController
{
    public enum DelayMode
    {
        Sequential,     // 顺序播放
        Wave,          // 波浪式
        Random,        // 随机延迟
        Instant        // 同时播放
    }
    
    public DelayMode delayMode = DelayMode.Sequential;
    public float baseDelay = 0.05f;
    public float maxRandomDelay = 0.3f;
    public int waveSize = 3;
    
    private int animationCount = 0;
    
    public float GetDelayForItem(int itemIndex)
    {
        switch (delayMode)
        {
            case DelayMode.Sequential:
                return animationCount * baseDelay;
                
            case DelayMode.Wave:
                int waveIndex = animationCount / waveSize;
                int positionInWave = animationCount % waveSize;
                return waveIndex * 0.2f + positionInWave * baseDelay;
                
            case DelayMode.Random:
                return Random.Range(0f, maxRandomDelay);
                
            case DelayMode.Instant:
            default:
                return 0f;
        }
    }
    
    public void IncrementAnimationCount()
    {
        animationCount++;
    }
    
    public void Reset()
    {
        animationCount = 0;
    }
}
