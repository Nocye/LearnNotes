元组用于将多个数据封装成一个轻型数据结构。

声明：

```c#
(double, int) t1 = (4.5, 3);
Console.WriteLine(t1.Item1 + t1.Item2); //通过item索引来访问

(double Sum, int Count) t2 = (4.5, 3);
Console.WriteLine(t2.Sum + t2.Count); //通过声明的成员名来访问

//直接在初始化时显示声明字段名
var t3 = （Sum: 4.5 , Count: 3）;
Console.WriteLine(t3.Sum + t3.Count);//直接通过显式声明的字段名来访问

double sum = 4.5;
int count = 3;
var t4 = (sum, count);
Console.WriteLine(t4.sum + t4.count);//通过实现声明的变量名推断出字段名
```

#### 元组赋值和析构

C# 支持满足以下两个条件的元组类型之间的赋值：

- 两个元组类型有相同数量的元素
- 对于每个元组位置，右侧元组元素的类型与左侧相应的元组元素的类型相同或可以隐式转换为左侧相应的元组元素的类型

元组元素是按照元组元素的顺序赋值的。 元组字段的名称会被忽略且不会被赋值，如下面的示例所示：

```c#
(int, double) t1 = (17, 3.14);
(double First, double Second) t2 = (0.0, 1.0);
t2 = t1;
Console.WriteLine($"{nameof(t2)}: {t2.First} and {t2.Second}");
// Output:
// t2: 17 and 3.14

(double A, double B) t3 = (2.0, 3.0);
t3 = t2;
Console.WriteLine($"{nameof(t3)}: {t3.A} and {t3.B}");
// Output:
// t3: 17 and 3.14
```

使用=号把元组的元素析构到单独的变量中

在括号内显式声明每个变量的类型：

```csharp
var t = ("post office", 3.6);
(string destination, double distance) = t;//把元组的元素析构到这俩个变量中
Console.WriteLine($"Distance to {destination} is {distance} kilometers.");
// Output:
// Distance to post office is 3.6 kilometers.
```