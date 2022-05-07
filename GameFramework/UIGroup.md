UIGroup，用来管理框架中UI的分组，其中的Refresh循环写的非常好。

UIGroup中使用链表来管理UI，因为链表可以很方便的插入，删除。

Refresh：

从头开始遍历链表，开始遍历时缓存next节点，假设几种情况：

1.在遍历中打开新UI，新UI会添加到链表头节点，并且执行一次refresh，因为没有改变顺序，所以这次遍历顺序和之前是一样的。回到最初的Refresh不改变结果。

2.在遍历中Refoucs UI，把UI提到最上层，然后执行一次新的Refresh，这次refresh是以新的UI顺序执行的，没有问题，执行完毕后回到最初的Refresh，假设Refoucs的UI是next节点的UI，那么因为GF的链表节点是复用的，此时Next已经是First节点，下次循环会从First开始再全部遍历，但第一次的Refresh中，如果已经pause，会导致Refoucs后的UI，因为回到了最初的Refresh，继承了上一次的Pause状态，导致出错。

所以使用Refoucs时，请确认自己调用的方法，避免在Refresh流程中调用。删除和添加没有这个问题。

