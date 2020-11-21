参考StartForce中的GameEntry脚本,在初始化时注册所有的GF组件,和自己的自定义组件,同时继承GF的ProcedureBase类 ,方便之后的自定义流程扩展

重写和扩展自定义的Procedure后,记得在GF的预制体中选择Procedure,选择自己写好的流程和入口流程

GF初始化时借助了mono的生命周期函数,在awake函数中获取框架模块

框架只开放了模块借口供外部使用,内部的实现类不对外开放,外部获取模块的方法:

```c#
GameFrameworkEntry.GetModule<T>()where T : class
```

框架内部通过传入的类型参数获取T的Type元数据,创建模块实例,返回接口给调用方使用.

