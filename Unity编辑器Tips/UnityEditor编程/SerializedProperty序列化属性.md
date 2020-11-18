这个类的可以进行类似数组的集合操作,

获取方法:

```c#
///如果这个序列化属性是array,获取index索引处的元素
public SerializedProperty GetArrayElementAtIndex(int index)
```

添加方法 比较复杂 分两步:

1: 首先在array插入一个元素

```
public void InsertArrayElementAtIndex(int index)
```

2: 调用上面的get方法,修改获取到的值,

注意:可以理解为没有add,只有插入,索引请先计算好

