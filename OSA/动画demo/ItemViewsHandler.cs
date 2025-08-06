using System;
using System.Threading;
using BDT;
using UnityEngine;
using UnityEngine.UI;
using Com.ForbiddenByte.OSA.Core;
using Cysharp.Threading.Tasks;
using TMPro;

public class MyItemViewsHolder : BaseItemViewsHolder
{
    [Header("UI引用")] public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public Image backgroundImage;
    public Image iconImage;
    public Animator animator;
    private UnityEntranceAnimation entranceAnimation;
    private bool isAnimationComponentCached = false;
    private int AnimToken;
    private CanvasGroup canvasGroup;
    public override void CollectViews()
    {
        base.CollectViews();

        // 收集UI组件
        titleText = root.GetComponentInChildren<TextMeshProUGUI>();
        descriptionText = root.transform.Find("DescriptionText")?.GetComponent<TextMeshProUGUI>();
        backgroundImage = root.GetComponent<Image>();
        iconImage = root.transform.Find("IconImage")?.GetComponent<Image>();
        animator = root.GetComponent<Animator>();
        canvasGroup = root.GetOrAddComponent<CanvasGroup>();
        // 缓存动画组件
        CacheAnimationComponent();
    }

    private void CacheAnimationComponent()
    {
        if (!isAnimationComponentCached)
        {
            entranceAnimation = root.GetComponent<UnityEntranceAnimation>();
            if (entranceAnimation == null)
            {
                entranceAnimation = root.gameObject.AddComponent<UnityEntranceAnimation>();
            }

            isAnimationComponentCached = true;
        }
    }

    public void UpdateFromModel(ItemData model)
    {
        if (titleText != null)
            titleText.text = $"[#{ItemIndex}] {model.title}";

        if (descriptionText != null)
            descriptionText.text = model.description;

        if (backgroundImage != null)
            backgroundImage.color = model.backgroundColor;

        if (iconImage != null && model.icon != null)
        {
            iconImage.sprite = model.icon;
            iconImage.gameObject.SetActive(true);
        }
        else if (iconImage != null)
        {
            iconImage.gameObject.SetActive(false);
        }
    }

    public void PlayEntranceAnimation(float delay = 0f)
    {
        CacheAnimationComponent();
        //entranceAnimation.PlayEntranceAnimation(delay);
        AnimToken++;
        //animator.Play("OSAEnter", 0, 0);
        PlayAnim(AnimToken, delay, entranceAnimation.destroyCancellationToken).Forget();
    }

    public async UniTask PlayAnim(int token, float delay, CancellationToken cancellation)
    {
        canvasGroup.Hide();
        await UniTask.Delay(TimeSpan.FromSeconds(delay), cancellationToken: cancellation);
        if (token != AnimToken)
        {
            return;
        }
        canvasGroup.Show();
        animator.enabled = true;
        animator.Play("OSAEnter", 0, 0);
        var info = animator.GetCurrentAnimatorStateInfo(0);
        var elapsedTime = 0;
        while (elapsedTime < info.length)
        {
            await UniTask.NextFrame(cancellation);

            if (token != AnimToken)
            {
                return;
            }
        }

        animator.enabled = false;
    }

    public void ResetAnimationState()
    {
        CacheAnimationComponent();
        //entranceAnimation.SetNormalState();
        animator.Play("OSAEnter", 0, 1);
        animator.Update(Time.deltaTime);
        animator.enabled = false;
    }

    public override void MarkForRebuild()
    {
        Log.Error($"markrebuild:{Time.frameCount}");
        base.MarkForRebuild();
        foreach (var componentsInChild in root.GetComponentsInChildren<ContentSizeFitter>())
        {
            componentsInChild.enabled = true;
        }
        ResetAnimationState();
    }

    public override void UnmarkForRebuild()
    {
        base.UnmarkForRebuild();
        foreach (var componentsInChild in root.GetComponentsInChildren<ContentSizeFitter>())
        {
            componentsInChild.enabled = false;
        }
    }
}