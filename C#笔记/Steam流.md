操作memoryStream中的buffer时，要注意设置流的position length等属性，因为操作buffer！=操作流（read，write）

一个例子：
当流扩容时（byte数组），会把新长度-旧长度中间的值全部清空，如果你操作buff的同时不设置Length，那么这部分数据就直接丢失了。