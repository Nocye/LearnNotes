> ## 关于可空类型的特性
> * AllowNull: 标记一个不可空的输入实际上是可以传入 null 的。
> *  DisallowNull: 标记一个可空的输入实际上不应该传入 null。
> * MaybeNull: 标记一个非空的返回值实际上可能会返回 null，返回值包括输出参数。
> * NotNull: 标记一个可空的返回值实际上是不可能为 null 的。
> * MaybeNullWhen: 当返回指定的 true/false 时某个输出参数才可能为 null，而返回相反的值时> 那个输出参数则不可为 null。
> * NotNullWhen: 当返回指定的 true/false 时，某个输出参数不可为 null，而返回相反的值时那个输出参数则可能为 null。
> * NotNullIfNotNull: 指定的参数传入 null 时才可能返回 null，指定的参数传入非 null 时就不可能返回 null。
> * DoesNotReturn: 指定一个方法是不可能返回的。
> * DoesNotReturnIf: 在方法的输入参数上指定一个条件，当这个参数传入了指定的 true/false 时方法不可能返回。

### Conditional

指示编译器，除非定义了指定的有条件编译符号，否则，应忽略方法调用或属性。

注意无法用在有返回值的方法上,区分大小写