

[Visual Studio2019黑色主题](https://plugins.jetbrains.com/plugin/12255-visual-studio-code-dark-plus-theme)

> 因为rider默认会开启反编译 反编译后的字段数量较多且复杂,除非遇到BUG否则不建议开启,关闭的位置为
>
> 中文:**设置-工具-External Symbols-Decompile methods**
>
> 英文:**Settings-Tools-External Symbols-Decompile methods**
>
> 取消打勾即为取消反编译 详情查看:
>
> [官方文档解释](https://www.jetbrains.com/help/rider/Settings_Debugger_Symbols.html)
>
> 另外 在**Settings-Build, Execution, Deployment-Debugger-Enable external source debug** 选项
>
> 为是否反编译调试外部代码(猜测为.DLL),可能上文的反编译关闭后这里也无法反编译,需要后续实验
>
> [官方文档](
>
> [开启外部代码调试](https://www.jetbrains.com/help/rider/Debugging_External_Code.html) 一般用于调试其他dll中的代码,.配合反编译使用
>
> 英文:**Execution, Deployment -- Debugger --  Enable external source debug** 打勾为打开

unity的IL2CPP编译需要OPENJDK和VS的CPP环境,暂不确定rider是否可以代劳

碰见一个有意思的坑,卸载VS会连同.net开发环境一起卸载,会造成rider默认从远程下载.net代码,远程下载的代码是没有注释的,下载回.net开发环境解决

https://www.jetbrains.com/help/rider/Settings_Debugger.html#dotNet)



rider在碰到导航到DLL内的方法时,从自己的服务器查询有没有类似的代码,这个功能比较耗时,大部分情况不需要,可以关闭这个方法,位置为:

**Settings-Tools-External Symbols-Allow downloading symbols from remote locations**

需要开启 **Use sources from symbol files when available** 选项后才会显示



调试代码时可能会遇见调试变量的值不显示,需要手动点击刷新的问题,在

**Settings-Build, Execution, Deployment-Debugger-Allow property evaluations and other implicit function calls**

打开自动刷新显示,打开此选项后会出现**Evaluation timeout**选项 用处不明

还会出现**Refresh watched values on debugger pause**选项,根据官方的说法是在暂停时也不断地刷新显示的值,如果有复杂表达式会导致性能降低,如果没有特殊需求建议关闭,因为简单的表达式和值依旧会自动刷新

[官方文档](https://www.jetbrains.com/help/rider/Settings_Debugger.html#dotNet)

#### 中文注释

因为Rider自带的JetBrains Mono字体是不支持中文的 所以中文注释看起来会非常的虚,这时候需要取消只显示等宽字体的选项,并且选择一个支持中文的备用字体(微软雅黑 永远的神) 这样渲染出的中文就很舒服

