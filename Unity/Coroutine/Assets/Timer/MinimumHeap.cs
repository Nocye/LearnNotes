using System;
using System.Collections.Generic;

namespace Timer
{
    public class MinimumHeap<T> where T : IComparable<T>
    {
        private readonly IComparer<T> comparer;
        private T[] arr;
        private int tail;


        public MinimumHeap() : this(4, null)
        {
        }

        public MinimumHeap(int capacity, IComparer<T> comparer)
        {
            arr = new T[capacity];
            this.comparer = comparer ?? Comparer<T>.Default;
        }


        public void Enqueue(T value)
        {
            if (arr.Length - 1 < tail + 1) Array.Resize(ref arr, arr.Length * 2);

            tail++;
            arr[tail] = value;
            int index = tail;
            int parentIndex = tail / 2;
            //添加节点时从下往上堆化,保证自己只小于自己的父节点，如果是根节点的左右子节点，保证只小于根节点
            //在下次删除时，直接在根节点的左右子节点寻找最小的，与根节点交换
            while (parentIndex >= 0 &&
                   0 > comparer.Compare(arr[index], arr[parentIndex]))
            {
                T temp = arr[index];
                arr[index] = arr[parentIndex];
                arr[parentIndex] = temp;
                index = parentIndex;
                parentIndex /= 2;
            }
        }

        public void Dequeue()
        {
            arr[1] = arr[tail];
            arr[tail] = default;
            Heapify(arr, --tail, 1);
        }

        public T Peek()
        {
            if (tail < 1) return default;

            return arr[1];
        }

        private void Heapify(T[] arr, int length, int index)
        {
            //现在的根节点是我们刚取的最后一个节点，他是一个比较大的节点
            //从上往下堆化,保证取把子树中最小的节点与子树根节点交换,根节点的左右节点最小的那个，就是堆中现在最小的节点
            while (index <= length)
            {
                int maxPos = index;
                int left = index * 2;
                if (left <= length &&
                    0 < comparer.Compare(arr[index], arr[left]))
                    maxPos = left;

                int right = left + 1;
                if (right <= length && 0 < comparer.Compare(arr[maxPos], arr[right])) maxPos = right;

                if (maxPos == index) break;

                T temp = arr[index];
                arr[index] = arr[maxPos];
                arr[maxPos] = temp;
                index = maxPos;
            }
        }
    }
}