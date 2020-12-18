## Regex的匹配行为

##### 默认模式[RegexOptions.None](https://docs.microsoft.com/zh-cn/dotnet/api/system.text.regularexpressions.regexoptions#System_Text_RegularExpressions_RegexOptions_None) 

选项指示尚未指定任何选项，正则表达式引擎使用其默认行为。 这包括：

- 该模式将被解释为一个规范而非 ECMAScript 正则表达式。
- 从左到右在输入字符串中匹配的正则表达式模式。
- 比较区分大小写。
- `^` 和 `$` 语言元素与输入字符串的开头和结尾匹配。
- `.` 语言元素与除 `\n` 之外的每个字符匹配。
- 正则表达式模式中的任意空白均解释为文本空白字符。
- 将模式与输入字符串进行比较时将使用当前区域性的约定。
- 正则表达式模式中的捕获组可以是隐式的，也可以是显式的。

##### 多行模式[RegexOptions.Multiline](https://docs.microsoft.com/zh-cn/dotnet/api/system.text.regularexpressions.regexoptions#System_Text_RegularExpressions_RegexOptions_Multiline)

默认情况下，`$` 仅与输入字符串的末尾匹配。 如果指定了 [RegexOptions.Multiline](https://docs.microsoft.com/zh-cn/dotnet/api/system.text.regularexpressions.regexoptions#System_Text_RegularExpressions_RegexOptions_Multiline) 选项，它将与换行符 (`\n`) 或输入字符串的末尾匹配。 但是，它并不与回车符/换行符的组合匹配。 若要成功匹配它们，使用子表达式 `\r?$` 只替代 `$`。

##### 单行模式[RegexOptions.Singleline](https://docs.microsoft.com/zh-cn/dotnet/api/system.text.regularexpressions.regexoptions#System_Text_RegularExpressions_RegexOptions_Singleline)

 选项或 `s` 内联选项导致正则表达式引擎将输入字符串视为由单行组成。 它通过更改句号 (`.`) 语言元素的行为，使其与每个字符匹配，而不是与除换行符 `\n` 或 \u000A 之外的每个字符匹配来执行此操作。

# Regex.Split 方法

在由指定正则表达式模式定义的位置将输入字符串拆分为一个子字符串数组。 如果未找到匹配项，则其他参数指定修改匹配操作的选项和超时间隔。

```csharp
public static string[] Split (string input, string pattern, System.Text.RegularExpressions.RegexOptions options, TimeSpan matchTimeout);
```

#### 参数

- input

  [String](https://docs.microsoft.com/zh-cn/dotnet/api/system.string?view=net-5.0)

要拆分的字符串。

- pattern

  [String](https://docs.microsoft.com/zh-cn/dotnet/api/system.string?view=net-5.0)

要匹配的正则表达式模式。

- options

  [RegexOptions](https://docs.microsoft.com/zh-cn/dotnet/api/system.text.regularexpressions.regexoptions?view=net-5.0)

枚举值的一个按位组合，这些枚举值提供匹配选项。

- matchTimeout

  [TimeSpan](https://docs.microsoft.com/zh-cn/dotnet/api/system.timespan?view=net-5.0)

超时间隔；若要指示该方法不应超时，则为 [InfiniteMatchTimeout](https://docs.microsoft.com/zh-cn/dotnet/api/system.text.regularexpressions.regex.infinitematchtimeout?view=net-5.0)。

和string.split方法类似,

**如果在输入字符串的开头或末尾找到了匹配项，则返回数组的开头或结尾处将包含空字符串。**(重要,返回的数组中如果出现空格属于正常现象)

**如果使用捕获括号()来指定分割的文本,则生成的字符串数组中会包含分割文本,如果不想捕获,请使用(?:exp)，多个条件用|与符号分开(\s|\w)**,

# Regex.Match 方法

```c#
public static System.Text.RegularExpressions.Match Match (string input, string pattern, System.Text.RegularExpressions.RegexOptions options, TimeSpan matchTimeout);
```

方法返回input字符串中第一个匹配pattern的子串,这个方法会new一个Regex实例然后调用Match方法,所以如果常用的匹配请缓存.

返回Match的Value就是匹配到的子串,如果要获取所有的字串,请使用Regex.Matches,获取匹配到的所有Match集合