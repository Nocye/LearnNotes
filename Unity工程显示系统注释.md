使用rider IDE可以无需处理,直接查看系统DLL的注释,但程序集路径非UnityDLL 暂不清楚原理.

使用visual studio时 进入Unity当前使用的.net版本目录

例子:**C:\Unity\2019.4.1f1\Editor\Data\MonoBleedingEdge\lib\mono\4.7.1-api\mscorlib.dll**

然后打开

**C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework**

下 根据DLL版本找到对应的文件夹 再进入其中的 **zh-Hans** 文件夹

如果该文件夹下的所有xml全部为1KB大小,打开可以看到XML内部转到了另一个文件夹,

**C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.X\zh-Hans**

复制这个文件夹 粘贴到之前打开的UnityDLL的文件夹中.

打开VS 可以看到.NET类以及有了注释

