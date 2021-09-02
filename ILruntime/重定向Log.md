ILR热更里的日志打印的时候堆栈会包含主工程的IL堆栈，需要直接重定向到IL内部的堆栈，参考文档，直接在生成的CLR绑定代码加上这两句

```c#
string stackTrace = __domain.DebugService.GetStackTrace(__intp);
CustomLog.Debug(string.Format("[Hot] {0}\n{1}",@message,stackTrace));
```

注意：只有在生成了CLR绑定后才有用，否则通过反射调用无法实现重定向。