使用crashsight时需要制作符号表上传查看堆栈信息,

libil2cpp需要在打包时勾选create symbol生成对应的符号表

libunity需要在{Unity}/Editor\Data\PlaybackEngines\AndroidPlayer\Variations\il2cpp\Release\Symbols\

路径下查找对应架构对应的dll
其他的so 例如libc.so这种 可以在ndk目录下查找