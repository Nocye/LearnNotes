using System;
using System.Collections.Generic;

namespace Timer
{
    public class MinimumHeap<T> where T : IComparable<T>
    {
        private readonly IComparer<T> comparer;
        private T[] items;
        private int heapCount;


        public MinimumHeap() : this(4, null)
        {
        }

        public MinimumHeap(int capacity, IComparer<T> comparer)
        {
            items = new T[capacity];
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        public MinimumHeap(IEnumerable<T> enumerable) : this()
        {
            foreach (T item in enumerable)
            {
                Enqueue(item);
            }
        }



        public T Peek()
        {
            if (heapCount < 1) return default;

            return items[1];
        }

        public void Enqueue(T value)
        {
            if (items.Length - 1 < heapCount + 1) Array.Resize(ref items, items.Length * 2);

            heapCount++;
            items[heapCount] = value;
            Swim(heapCount);
        }
        public void Dequeue()
        {
            items[1] = items[heapCount];
            items[heapCount--] = default;
            Sink(1);
        }

        /// <summary>
        /// 上浮
        /// </summary>
        /// <param name="index"></param>
        private void Swim(int index)
        {
            int parentIndex = index / 2;
            //添加节点时从下往上堆化,保证自己只小于自己的父节点，如果是根节点的左右子节点，保证只小于根节点
            //在下次删除时，直接在根节点的左右子节点寻找最小的，与根节点交换
            while (parentIndex > 0 &&
                   0 > comparer.Compare(items[index], items[parentIndex]))
            {
                T temp = items[index];
                items[index] = items[parentIndex];
                items[parentIndex] = temp;
                index = parentIndex;
                parentIndex /= 2;
            }
        }

        /// <summary>
        /// 下沉
        /// </summary>
        /// <param name="index"></param>
        private void Sink(int index)
        {
            int length = heapCount;
            //现在的根节点是我们刚取的最后一个节点，他是一个比较大的节点
            //从上往下堆化,保证取把子树中最小的节点与子树根节点交换,根节点的左右节点最小的那个，就是堆中现在最小的节点
            while (index <= length)
            {
                int maxPos = index;
                int left = index * 2;
                //取左子节点对比，如果大于子节点则取左节点索引
                if (left <= length &&
                    0 < comparer.Compare(items[index], items[left]))
                    maxPos = left;

                int right = left + 1;
                //之后取右节点对比，
                if (right <= length && 0 < comparer.Compare(items[maxPos], items[right])) maxPos = right;

                //说明不需要下沉，已经是子树中最小的
                if (maxPos == index) break;
                //交换节点
                T temp = items[index];
                items[index] = items[maxPos];
                items[maxPos] = temp;
                //继续下个子树下沉
                index = maxPos;
            }
        }
    }
}