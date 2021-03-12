UTF8分为带BOM和不带BOM的格式区别，带BOM的会在文件开头添加3个字节（byte）的标识符，这个BOM只有windows创建的文件附带居多，其他的系统模式不会带这个BOM。

在C#中 **UTF8Encoding**这个类中有返回这个标识代表的字节的方法，可以参考这个来对是否有BOM进行筛选。

```c#
public override byte[] GetPreamble()
{
  if (!this.emitUTF8Identifier)
    return EmptyArray<byte>.Value;
  return new byte[3]
  {
    (byte) 239,
    (byte) 187,
    (byte) 191
  };
}
```

