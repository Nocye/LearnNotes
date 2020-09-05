### [LitJSON](https://litjson.net/) 一个开源的c# Json处理库

litjson写入字段时,首先做了一个解析层数或者叫解析深度的判断，这个是为了防止相互依赖引用的情况下导致解析进入死循环或者爆栈。然后在这里处理了Int、String、Bool这些最基本的类型，首先从基本类型起开始检测，如果匹配到合适的就用JsonWriter写入。然后再去检测是否是List、Dictionary等集合类型，如果是集合类型的话，会迭代每一个元素，然后递归调用WriteValue方法再对这些元素写值。然后再去上文中我们说的自定义序列化（custom_exporters_table）规则里面检索有没有匹配项，如果没有检测到合适的规则再去内置的 base_exporters_table里面检索，这里有一个值得注意的点，custom_exporters_table 的优先级是高于 base_exporters_table 的，所以我们可以在外部重新注册一些行为来屏蔽掉内置的规则，这一点在将LitJson源码打包成 dll 后，想修改内置规则又不用重新修改源码的情况下非常好用。在上述规则都没有匹配的情况下，我们一般会认为当前的object就是一个实实在在的对象了，首先调用 AddTypeProperties方法，将对象中的所有字段和属性拿到，然后再依次地对这些属性递归执行 WriteValue。

在打包成dll后扩展litjson 首先需要新建一个委托,在这个委托中执行对应类型的序列化方式,然后注册到JsonMapper里,这样一个自定义对象的序列化就扩展好了

```c#
            ExporterFunc<Vector3> writeVector3 = (v3, w) =>
            {
                w.WriteObjectStart();
                w.WritePropertyName("x");
                w.Write(v3.x);
                w.WritePropertyName("y");
                w.Write(v3.y);
                w.WritePropertyName("z");
                w.Write(v3.z);
                w.WriteObjectEnd();
            };
            JsonMapper.RegisterExporter(writeVector3);
```



