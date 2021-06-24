如果有一个参数，需要检查他的参数是否符合一些条件，且是否为空

```c#
Module module=new Module();
if(module!=null && module.number==10){
    //run
}
module = null;

if(module!=null && module.number==10){
    //not run
}

//使用模式匹配重写上面的条件运算符
if(module is {number==10}) //这里也会检测module是否为null
```

该特性出现在c#7.0

需要注意的是 ：[将表达式与 `null` 匹配时，编译器保证不会调用用户重载的 `==` 或 `!=` 运算符](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/is#:~:text=%E6%9C%89%E5%85%B3%20is%20%E8%BF%90%E7%AE%97%E7%AC%A6%E6%94%AF%E6%8C%81%E7%9A%84%E6%A8%A1%E5%BC%8F%E7%9A%84%E5%AE%8C%E6%95%B4%E5%88%97%E8%A1%A8%EF%BC%8C%E8%AF%B7%E5%8F%82%E9%98%85%E6%A8%A1%E5%BC%8F%E3%80%82)。

所以这个特性不能用于Unity中的Object及其子类，因为Object重载了空判定运算。

