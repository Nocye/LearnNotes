查阅资料时发现有空Graphic作为透明遮罩，减少OverDraw的手段，试验了一下，确实不会产生OverDraw

```c#
public class EmptyGraphic : UnityEngine.UI.Graphic
{
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();
    }
}
```

不过，文章提到这个手段是为了解决透明的Image仍然会被渲染的问题，在Unity2020和2021中测试了一下，发现把Image的Alpha，还是CanvasGroup的Alpha改到0，Image也不会被渲染了，没有产生OverDraw。

说明这个优化方式已经过时？

后续需要找一下Unity是在哪个版本更新的这个优化。

