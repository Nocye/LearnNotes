想要让异步方法的返回值是自己的自定义类型，需要实现 AsyncMethodBuilder 这个Attribute（特性），编写一个Builder类让编译器知道如何编译一个异步状态机。

一个方法内部的多次await 可以被一个Task Like的返回值所描述 

编译方法时会生成一个状态机，这个状态机通过上文的特性来构造一个状态机，状态机内部会包含一个叫Task的awaiter字段，方法返回的就是这个字段，在状态机内部的其他Task执行完毕之后，会调用状态机Task的SetResult ，这时如果外部有Task嵌套，就会进入下一个状态机的MoveNext函数中执行。这也是为什么异步有传染性的原因。

异步流程

1. 进入方法 创建状态机，执行状态机的Start方法。
   1. Start内部执行一次MoveNext，每个await都是一个状态机状态，执行到第一个await时，获取awaiter类型（一般是Task），调用Builder的函数，给当前这个awaiter添加coutine委托（MoveNext）。
2. 返回状态机内部的Task。
3. awaiter执行完毕，回调回状态机，如果没有其他awaiter，执行状态机内部Task的SetResult。
4. 如果是嵌套异步方法，这时SetResult内部会执行上一层状态机的coutine委托，进入上层状态机的MoveNext，内部会调用这层Task的GetResult来获取结果。