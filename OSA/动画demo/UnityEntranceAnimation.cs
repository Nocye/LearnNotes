using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UnityEntranceAnimation : MonoBehaviour
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Coroutine animationCoroutine;
    
    [Header("动画设置")]
    public float scaleDuration = 0.3f;
    public float fadeDuration = 0.2f;
    public AnimationCurve scaleCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
    public AnimationCurve fadeCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }
    
    public void PlayEntranceAnimation(float delay = 0f)
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }
        animationCoroutine = StartCoroutine(EntranceAnimationCoroutine(delay));
    }
    
    public void SetNormalState()
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
            animationCoroutine = null;
        }
        
        rectTransform.localScale = Vector3.one;
        canvasGroup.alpha = 1f;
    }
    
    private IEnumerator EntranceAnimationCoroutine(float delay)
    {
        // 设置初始状态
        rectTransform.localScale = Vector3.zero;
        canvasGroup.alpha = 0f;
        
        // 等待延迟
        if (delay > 0f)
            yield return new WaitForSeconds(delay);
        
        // 同时播放缩放和透明度动画
        float maxDuration = Mathf.Max(scaleDuration, fadeDuration);
        float elapsed = 0f;
        
        while (elapsed < maxDuration)
        {
            elapsed += Time.deltaTime;
            
            // 缩放动画
            if (elapsed < scaleDuration)
            {
                float scaleProgress = elapsed / scaleDuration;
                float scaleValue = scaleCurve.Evaluate(scaleProgress);
                rectTransform.localScale = Vector3.one * scaleValue;
            }
            else
            {
                rectTransform.localScale = Vector3.one;
            }
            
            // 透明度动画
            if (elapsed < fadeDuration)
            {
                float fadeProgress = elapsed / fadeDuration;
                float alphaValue = fadeCurve.Evaluate(fadeProgress);
                canvasGroup.alpha = alphaValue;
            }
            else
            {
                canvasGroup.alpha = 1f;
            }
            
            yield return null;
        }
        
        // 确保最终状态
        rectTransform.localScale = Vector3.one;
        canvasGroup.alpha = 1f;
        animationCoroutine = null;
    }
}
