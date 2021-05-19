通过官方开源在[GitHub上的C#层](https://github.com/Unity-Technologies/UnityCsReference/blob/master/Editor/Mono/AssemblyInfo/AssemblyInfo.cs)代码可以得知，Unity在程序集中定义了很多友元程序集 ，当你不想通过反射去调用时，可以使用Unity的asmdef创建友元程序集来作为桥接访问。

1.创建一个程序集asmdef文件。

2.修改这个asmdef文件的Name，改为Unity设定的友元程序集之一的名字（Unity.InternalAPIEditorBridge比较常用）。

3.在这个asmdef目录下创建的脚本文件，都可以使用Unity 的internal内部类了。

Unity的asmdef文件，是获取当前目录和子目录下的脚本，把他编译为一个独立的dll文件，可以理解成c#的sln，asmdef的Name就是编译出的Dll的名字。



