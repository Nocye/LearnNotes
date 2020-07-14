```c#
Mathf.Lerp(float a, float b, float t);
```

插值计算,数学原理为 **a+(b-a)*t**  传入0时该方法返回0,传入1时该方法返回b的值,传入0.5时返回a+(b-a*)0.5 该方法传入的T会被限制在0~1之间,一个简单的根据时间插值的算法为

```c#
float 经过时间 =0;
float 设定时间=2f;
float 当前值=10f;
float 目标值=20f;
float 缓存值=当前值;
 
while(经过时间<设定时间){
    yield return null;
    经过时间+=Time.deltaTime;
    //经过时间/设定时间 得出当前的步数
    当前值=Mathf.Lerp(缓存值,目标值,经过时间/设定时间)
}
//因为插值最终只能接近不能等于,所以插值结束后需要手动对齐一下
当前值=目标值;

```



```c#
Mathf.LerpUnclamped(float a, float b, float t)
```

和上一个的方法类似,但T不会限定在0~1之间,在清楚数学原理的情况下再用