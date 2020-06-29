因为rider默认会开启反编译 反编译后的字段数量较多且复杂,除非遇到BUG否则不建议开启,关闭的位置为

中文:设置-工具-External Symbols-Decompile methods

英文:Settings-Tools-External Symbols-Decompile methods

取消打勾即为取消反编译 详情查看:

[官方文档解释](https://www.jetbrains.com/help/rider/Settings_Debugger_Symbols.html)



另外 在Settings-Build, Execution, Deployment-Debugger-Enable external source debug 选项

为是否反编译调试外部代码(猜测为.DLL),可能上文的反编译关闭后这里也无法反编译,需要后续实验

[官方文档](https://www.jetbrains.com/help/rider/Settings_Debugger.html#dotNet)

