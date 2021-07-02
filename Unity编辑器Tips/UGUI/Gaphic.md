UI图形的基类，UI图像本质上也是一个个不同的mesh渲染出的，这个类负责生成UI对应的mesh。

主要关注这个方法

```c#
protected virtual void OnPopulateMesh(VertexHelper vh)
```

这个方法在ReBuild调用，生成对应的mesh，之后提供给CanvasRenderer使用