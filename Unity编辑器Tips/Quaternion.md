### 四元数 (Quaternion)

> 四元数是用来表示旋转的。
>
> 它们结构紧凑，不会受到万向节锁定的影响，并且可以很容易地进行插值。Unity内部使用四元数来表示所有的旋转。
>
> 它们基于复杂的数字，不容易直观地理解。你几乎从来不会访问或修改单个的四元组（x,y,z,w）；大多数情况下，你只会获取现有的旋转（例如来自Transform），并使用它们来构建新的旋转（例如在两个旋转之间平滑插值）。你99%的时间都会用到的Quaternion函数是。Quaternion.LookRotation、Quaternion.Angle、Quaternion.Euler、Quaternion.Slerp、Quaternion.FromToRotation、Quaternion.identity。(其他函数仅用于特殊用途。)
>
> 你可以使用Quaternion.operator \*来旋转一个旋转，或者旋转一个向量。(增量旋转使用*=)
>
> 请注意，Unity期望Quaternions是归一化的。

> public [Vector3](Vector3.html) **eulerAngles**;
>
> 返回或设置旋转的欧拉角。
>
> Euler角可以通过围绕各个轴进行三次独立的旋转来表示三维旋转，在Unity中，这些旋转依次围绕Z轴、X轴和Y轴进行。
>
> 你可以通过设置这个属性来设置四元组的旋转，也可以通过读取这个属性来读取欧拉角值。
>
> 当使用 .eulerAngles 属性来设置旋转时，重要的是要明白，虽然你提供了 X、Y 和 Z 旋转值来描述你的旋转，但这些值并不存储在rotation中。取而代之的是，X、Y和Z值被转换为四元组的内部格式。所以尽量用别的函数实现.



> public static [Quaternion](Quaternion.html) **identity**;
>
> 这个四元数对应于 "无旋转",等于世界坐标系下的rotation(0,0,0);,



> public static float **Angle**([Quaternion](Quaternion.html) **a**, [Quaternion](Quaternion.html) **b**);
>
> 回两个四元数 a和b之间的角度，单位为度。



> public void **ToAngleAxis**(out float **angle**, out [Vector3](Vector3.html) **axis**);
>
> 将当前四元数的旋转转为角度和轴的表示方法,



> public static [Quaternion](Quaternion.html) **AngleAxis**(float **angle**, [Vector3](Vector3.html) **axis**);
>
> 创建一个围绕axis旋转若干角度的四元数。



> public static [Quaternion](Quaternion.html) **Euler**(float **x**, float **y**, float **z**);
>
> public static [Quaternion](Quaternion.html) **Euler**([Vector3](Vector3.html) **euler**);
>
> 返回围绕z轴旋转z度、围绕x轴旋转x度、围绕y轴旋转y度的四元数，并依次应用。



> public static [Quaternion](Quaternion.html) **FromToRotation**([Vector3](Vector3.html) **fromDirection**, [Vector3](Vector3.html) **toDirection**);
>
> public void **SetFromToRotation**([Vector3](Vector3.html) **fromDirection**, [Vector3](Vector3.html) **toDirection**);
>
> 返回一个，从 fromDirection 旋转到 toDirection之后的四元数.(求一个向量和另一个向量之间的夹角)
>
> 例子:transform.forward to Vector3.right; 



> public static [Quaternion](Quaternion.html) **Inverse**([Quaternion](Quaternion.html) **rotation**);
>
> 返回传入旋转的反向,(相反的方向)



> public static [Quaternion](Quaternion.html) **Lerp**([Quaternion](Quaternion.html) **a**, [Quaternion](Quaternion.html) **b**, float **t**);
>
> 在a和b之间用t进行插值，然后将结果标准化。参数 t 被限制在 [0, 1] 范围内。
>
> 这比 Slerp 快，但如果旋转的距离很远，看起来会比较糟糕。
>
> public static [Quaternion](Quaternion.html) **LerpUnclamped**([Quaternion](Quaternion.html) **a**, [Quaternion](Quaternion.html) **b**, float **t**);
>
> 不会限制参数t在0~1之间



> public static [Quaternion](Quaternion.html) **Slerp**([Quaternion](Quaternion.html) **a**, [Quaternion](Quaternion.html) **b**, float **t**);
>
> 在 a 和 b 之间用 t 进行球面插值。参数 t 被限制在 [0, 1] 范围内。
>
> 用此方法创建一个旋转，这个旋转在a和b之间,根据参数t决定.如果参数值接近0，输出将接近a，如果接近1，输出将接近b。
>
> public static [Quaternion](Quaternion.html) **SlerpUnclamped**([Quaternion](Quaternion.html) **a**, [Quaternion](Quaternion.html) **b**, float **t**);
>
> 不会限制参数t在0~1之间