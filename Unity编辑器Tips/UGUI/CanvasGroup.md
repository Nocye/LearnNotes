CanvasGroup，用来方便的管理自身及子物体的交互开关和透明度，

```c#
public static IEnumerator FadeHide(this CanvasGroup group, float delay)
{
    group.interactable = false; //先关闭组件交互，防止在动画中再次交互

    float time = 0;
    if (group.alpha == 0) yield break;
    while (time < delay)
    {
        group.alpha = Mathf.Lerp(1, 0, time / delay);
        time += Time.deltaTime;
        yield return null;
    }

    group.blocksRaycasts = false;
    group.alpha = 0;
}

public static IEnumerator FadeShow(this CanvasGroup group, float delay)
{
    float time = 0;
    group.blocksRaycasts = true; //先打开射线检测，但是不打开组件交互，防止点穿
    while (time < delay)
    {
        group.alpha = Mathf.Lerp(0, 1, time / delay);
        time += Time.deltaTime;
        yield return null;
    }

    group.alpha = 1;
    group.interactable = true;
}
```