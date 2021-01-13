[参考文章](https://zhuanlan.zhihu.com/p/30746354)

[微软官方文档](https://docs.microsoft.com/zh-cn/dotnet/framework/interop/interop-marshaling)

PInvoke,简单来说就是在c#调用c++代码

 在c++工程中需要设置的一些地方

生成类型为.dll，c/c++中关闭优化，不使用预编译，且删除预编译头。

因为c++不跨平台，所以在Unity的Plugins文件夹中需要建立平台相对应的子目录来存放不同的dll（IOS，Android，Windows32位，64位等）。

生成DLL完毕后，在Unity中的调用

```c#
[DllImport("PInvoke")]
public static extern int Add(int a, int b);
```

DllImport特性填写对应dll的文件名，因为是dll文件所以不需要后缀，如果是别的类型可能需要添加后缀。

方法是静态的，且被extern修饰符修饰。

调试：

我们可以直接在c++工程中进行调试，在VS中选择调试-附加到进程，寻找对应的Unity工程进程，如果没有找到或者找错，断点会显示：“当前不会命中断点。还没有为该文档加载任何符号”，重复几次找到对应的直到断点正常即可，不过我并未深究这个问题的原因，如果后期出现无法调试的问题再深入学习。



Unity 根据插件所在的文件夹，设置插件文件的导入设置的默认值：

| **文件夹**                                                   | **默认设置**                                                 |
| :----------------------------------------------------------- | :----------------------------------------------------------- |
| **Assets/../Editor**                                         | 将插件设置为仅与 Editor 兼容，在构建到平台时不会使用。       |
| **Assets/../Editor/**（**x86** 或 **x86_64** 或 **x64**）    | 将插件设置为仅与 Editor 兼容，根据子文件夹分配 CPU 值。      |
| **Assets/../Plugins/**（**x86_64** 或 **x64**）              | 将 x64 独立平台插件设置为兼容。                              |
| **Assets/../Plugins/x86**                                    | 将 x86 独立平台插件设置为兼容。                              |
| **Assets/Plugins/iOS**                                       | 将插件设置为仅与 iOS 兼容。                                  |
| **Assets/Plugins/WSA/**（**x86** 或 **ARM**）                | 将插件设置为仅与通用 Windows 平台兼容，如果存在 CPU 子文件夹，还会设置 CPU 值。可使用 Metro 关键字代替 WSA。 |
| **Assets/Plugins/WSA/**（**SDK80** 或 **SDK81** 或 **PhoneSDK81**） | 同上，还会设置 SDK 值，此后也可以添加 CPU 子文件夹。出于兼容性原因，SDK81 - Win81，PhoneSDK81 - WindowsPhone81。 |
| **Assets/Plugins/Tizen**                                     | 将插件设置为仅与 Tizen 兼容。                                |
| **Assets/Plugins/PS4**                                       | 将插件设置为仅与 Playstation 4 兼容。                        |