try catch语句块通常用来对代码中的错误进行提示,顺序通常是try块执行，顺利执行就结束，不进入catch块，如果执行中出现错误就进入catch块执行，try catch块之后可以衔接finally块，这个块在try 和catch执行后执行，并且优先于return，

也就是说：

一个try catch块，不管错误与否，都要执行一些其他操作，这时候就用到了finally块。 

```c#
Console.WriteLine(Finally());

public static int Finally()
{
    try
    {
        Console.WriteLine("方法中");
        return 1 ;
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        return -1;
    }
    finally
    {
        Console.WriteLine("finally");
    }
}
```

扩展：

在GF中，E大的DefaultZipHelper解压缩类，有一个长度4096的byte数组来缓存每次读取的byte数据，通过finally块再每次解压缩完毕后清空缓存数组。就算出错返回失败也会正常清空。

