当Anchors不重合的时候，设置`sizeDelta`就不能正确控制RectTransform的大小，此时可以使用`SetSizeWithCurrentAnchors(axis, size)`来设置rect的width和height。

```csharp
// rect width
rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200);
// rect height
rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 200);
```

而`SetInsetAndSizeFromParentEdge(edge, inset, size)`可以根据父类的某个边，设置大小和间距（注意此方法会改变Anchors的位置）：

- edge：是父类的边，Left，Right，Top，Bottom
- inset：子类边到父类边的间距
- size：在边方向上的大小，如：Left和Right对应Width，Top和Bottom对应Height

```csharp
// 以下两个方法
// 可以将子类（Top，Left）边，定位到距离父类（Top，Left）边各100像素的地方
// 并且设置子类大小为（400，400）
SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top,  100, 400);
SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 100, 400);
```