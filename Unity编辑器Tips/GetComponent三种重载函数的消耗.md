## GetComponent三种重载函数

unity版本2019.4.1f1

```c#
public T GetComponent<T>();
public Component GetComponent(Type type);
public Component GetComponent(string type);
```

第一个泛型方法的函数消耗最低,10W次Component的函数消耗 三种函数的平均消耗分别为:

泛型方法:15~16毫秒

Type参数方法:19~17毫秒

字符串参数方法:320毫秒左右

应完全避免使用字符串获取组件的方法,

泛型方法的消耗可以忽略不计 只要避免在update之类的函数中调用,就不会发生性能问题

**请注意，某些脚本方法在 Editor 中运行时会产生分配内存，但在构建项目后不会产生分配内存。`GetComponent` 是最常见的示例；此方法始终在 Editor 中执行时分配内存，而不会在已构建的项目中分配内存。** --来自[Unity官方手册](https://docs.unity3d.com/cn/current/Manual/BestPracticeUnderstandingPerformanceInUnity4-1.html)