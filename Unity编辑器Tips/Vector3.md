### Vector3

用于表示 3D 向量和点。

Unity 内部使用该结构传递 3D 位置和方向。 此外，它还包含用于执行常见向量操作的函数。

除了下面列出的函数以外，也可以使用其他类操作向量和点。 例如，对于旋转或变换向量和点来说，[Quaternion](https://docs.unity.cn/cn/2019.4/ScriptReference/Quaternion.html) 和 [Matrix4x4](https://docs.unity.cn/cn/2019.4/ScriptReference/Matrix4x4.html) 类也很有用。

> public static [Vector3](https://docs.unity.cn/cn/2019.4/ScriptReference/Vector3.html) **Slerp** ([Vector3](https://docs.unity.cn/cn/2019.4/ScriptReference/Vector3.html) **a**, [Vector3](https://docs.unity.cn/cn/2019.4/ScriptReference/Vector3.html) **b**, float **t**);
>
> 在两个向量之间进行球形插值。
>
> 在 `a` 和 `b` 之间按大小 `t` 进行插值。 球形插值与线性插值（也称为“lerp”）的区别在于， 向量被视为方向而不是空间中的点。返回的向量的方向通过角度进行插值， 其 [magnitude](https://docs.unity.cn/cn/2019.4/ScriptReference/Vector3-magnitude.html) 在 `from` 和 `to` 的大小之间进行插值。
>
> 参数 `t` 限制在范围 [0, 1] 内。
>
> 比较难懂的一个方法,需要记住的是这个方法传入的不应该是点的坐标而是一个方向,球形插值的本质是旋转一个向量的方向,让他逐渐与目标方向重合,期间会像一个球形一样
>
> 比如有一个点sun和一个点moon,先求出他们俩的中心点(sun.pos+moon.pos)*0.5,然后根据所需要的球形弧度给这个中心点偏移,弧度大小与中心点偏移的大小取反,弧度的方向为中心点偏移的方向取反,最后根据方法的返回值(向量)+上中心点的坐标,就是插值后的期望坐标,

