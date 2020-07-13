```c#
[MenuItem(string itemName,bool isValidateFunction, int priority)]
```

创建一个在unity工具栏中的按钮,itemName代表按钮的路径名,类似目录名的结构,

isValidateFunction如果为true,则表示被该特性装饰的方法是一个验证函数,方法的返回值必须是一个bool值,在显示该按钮时调用,根据返回值来判断按钮是否为可用状态

priority表示这个按钮在列表中显示的顺序

