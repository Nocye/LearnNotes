c#中

```c#
public void TestAction(Action action)
{
    action?.Invoke();
}
```

lua中

```lua
function test()
    testaction(function() print("测试方法") end)
end
function testaction(action)   
    TestComponent:TestAction(action);    
end
```

简单来说,传递时请用function和end关键字 像声明方法一样包装一下



当委托作为一个字段时

c#

```c#
public Action action;
```

lua

```lua
--添加
function addac(action)
   TestComponent.ac=TestComponent.ac+action;   
   --lua中没有+=
end
--调用
function runac()
    TestComponent.ac()
end
```

