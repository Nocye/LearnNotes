Stream 流，抽象解释：比如一个非常大的文件，你读取他，如果一次性加载，会比较浪费时间，但是如果我一点一点加载，加载一定的长度后处理一下，或者写入一下，在脑海中把它想象成一条河流，我们在不同的位置停下来取水（copy、read）或者加水（write），在流中只有相对位置，没有绝对位置。

基础操作：所有的流都是托管资源，如果你不想手动Dispose，用using关键字包裹他，他将在using语句块结束时自动调用。

```c#
using(FileStram fs = new FileStram(path) ){

}//自动调用fs.Dispose()
```

基础读写操作：

```c#
private static void WriteText(string path)
{
    using (var fileStream = File.Create(path))
    {
        using (StreamWriter writer = new StreamWriter(fileStream, Encoding.UTF8))
        {
            for (int i = 0; i < 1000; i++)
            {
                writer.Write(i);
            }
            writer.Flush();
        }        
    }
}

async private static void ReadText(string path)
{
    byte[] buffer = new byte[16];
    using (FileStream fs = new FileStream(path, FileMode.Open))
    {
        UTF8Encoding encoding = new UTF8Encoding(true);
        StringBuilder sb = new StringBuilder();
        while ((await fs.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            Console.WriteLine(encoding.GetString(buffer));
        }             
    }
```

使用异步方法的时候发现一个有趣的点，因为是异步，主线程依旧会继续执行，如果你的代码比较短，主线程很快就结束，会带着异步一起结束，如果你是跑测试，可以用Task.WaitAll()，或者直接Console.ReadLine锁住。

要点：流在执行write或者read后是会改变当前的位置（Position）的，如果你想要在移动到流的某个位置，使用Seek()函数

```c#
if(stream.CanSeek){
	stream.Seek(0,SeekOrigin.Begin)
}
```

注意：不是所有的Stream都可以Seek，Seek时传入的第一个值如果是正数，代表从参考点往后移这个值，如果是负数代表往前移。