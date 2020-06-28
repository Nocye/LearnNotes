# nameof 表达式（C# 参考）

`nameof` 表达式可生成变量、类型或成员的名称作为字符串常量：



```csharp
Console.WriteLine(nameof(System.Collections.Generic));  // output: Generic
Console.WriteLine(nameof(List<int>));  // output: List
Console.WriteLine(nameof(List<int>.Count));  // output: Count
Console.WriteLine(nameof(List<int>.Add));  // output: Add

var numbers = new List<int> { 1, 2, 3 };
Console.WriteLine(nameof(numbers));  // output: numbers
Console.WriteLine(nameof(numbers.Count));  // output: Count
Console.WriteLine(nameof(numbers.Add));  // output: Add
```

如前面的示例所示，对于类型和命名空间，生成的名称通常不是[完全限定的](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/language-specification/basic-concepts#fully-qualified-names)名称。

在[逐字标识符](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/tokens/verbatim)的情况下，`@` 字符不是名称的一部分，如以下示例所示：

C#复制运行

```csharp
var @new = 5;
Console.WriteLine(nameof(@new));  // output: new
```

`nameof` 表达式在编译时进行求值，在运行时无效。

可以使用 `nameof` 表达式使参数检查代码更易于维护：

```csharp
public string Name
{
    get => name;
    set => name = value ?? throw new ArgumentNullException(nameof(value), $"{nameof(Name)} cannot be null");
}
```