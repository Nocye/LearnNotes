多值字典是GF中一个常用的数据结构，内部使用一个字典+GF链表实现，优点是无GC，可以存储同key多值数据。

GameFrameworkLinkedList<T>是GF自己封装的一个链表结构，内部采用了缓存节点实例的方式，删除节点时会把Node实例缓存起来，等待下一次添加节点时直接使用现有的Node实例，避免重复实例化Node实例。

具体的储存方式为字典储存键值+键值对应的链表范围（GameFrameworkLinkedListRange），在GF链表中储存实际的数据，外部不能访问到链表。

看一下关键的方法：

初次添加到多值字典中时，首先创建一个链表范围，该值当作头，默认值为尾。

添加已存在key的value时，根据链表的特性，直接把值添加到尾节点之前。

```c#
public void Add(TKey key, TValue value)
{
    GameFrameworkLinkedListRange<TValue> range = default(GameFrameworkLinkedListRange<TValue>);
    if (m_Dictionary.TryGetValue(key, out range))
    {
        m_LinkedList.AddBefore(range.Terminal, value);
    }
    else
    {
        LinkedListNode<TValue> first = m_LinkedList.AddLast(value);
        //注意这里，尾节点当作哨兵用。始终是类型默认值，不包含实际值。
        LinkedListNode<TValue> terminal = m_LinkedList.AddLast(default(TValue));
        m_Dictionary.Add(key, new GameFrameworkLinkedListRange<TValue>(first, terminal));
    }
}
```

删除节点时需要判断一下是否头节点，如果是头节点就需要重新指定字典中的链表范围

```c#
public bool Remove(TKey key, TValue value)
{
    GameFrameworkLinkedListRange<TValue> range = default(GameFrameworkLinkedListRange<TValue>);
    if (m_Dictionary.TryGetValue(key, out range))
    {
        //用for写while的循环，很好的范例
        //循环条件：当节点不为空，节点不是范围的尾部，移动到下一个节点
        for (LinkedListNode<TValue> current = range.First; current != null && current != range.Terminal; current = current.Next)
        {
            if (current.Value.Equals(value))
            {
                //如果需要删除的是范围的头节点，那么就需要修改节点范围
                if (current == range.First)
                {
                    LinkedListNode<TValue> next = current.Next;
                    //检测当前节点（头节点）的下一个是否为尾节点
                    if (next == range.Terminal)
                    {
                        //如果是尾节点，那么可以直接删除这个键值对，和尾节点，因为尾节点只用作哨兵.
                        m_LinkedList.Remove(next);
                        m_Dictionary.Remove(key);
                    }
                    else
                    {
                        //如果当前节点的下一个节点不是尾节点，证明这个节点中还有其他实际用到的节点，那么用新的头节点重置链表范围
                        m_Dictionary[key] = new GameFrameworkLinkedListRange<TValue>(next, range.Terminal);
                    }
                }
                //不是头就直接简单粗暴删除
                m_LinkedList.Remove(current);
                return true;
            }
        }
```