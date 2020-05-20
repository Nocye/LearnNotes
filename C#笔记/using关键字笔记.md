## using的用法：

**1. using指令：引入命名空间**

这是最常见的用法，例如：

```
using System;
using Namespace1.SubNameSpace;
```

**2. using static 指令：指定无需指定类型名称即可访问其静态成员的类型**

```
using static System.Math;var = PI; // 直接使用System.Math.PI
```

**3. 起别名**

```
using Project = PC.MyCompany.Project;
```

**4. using语句：将实例与代码绑定**

```
using (Font font3 = new Font("Arial", 10.0f),
            font4 = new Font("Arial", 10.0f))
{
    // Use font3 and font4.
}
```

代码段结束时，自动调用font3和font4的Dispose方法，释放实例。