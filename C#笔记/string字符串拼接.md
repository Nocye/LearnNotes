常用的拼接有三种方式：string.Concat()，string.Format()，$“”字符串内插，StringBuilder

在.net环境测试下，Concat要略快于Format，但在unity下，两者几乎没有区别。

使用$内插式拼接时，会根据拼接的参数来决定编辑成什么方法，当参数全部为string时候，会调用string.Concat()，当参数含有非string类型时，会编译为传统的string.Format()，把参数全部转为object传递，如果参数中含有值类型是会造成装箱的，所以字符串拼接时尽可能把参数全部转为string

StringBuilder可以当作Format的缓存来使用，减少GC（参考GF的Format类），一般是用来做大量的字符串拼接才会使用。

