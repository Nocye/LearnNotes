using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace Timer
{
    public class MinimumHeap<T> where T : IComparable<T>
    {
        private T[] arr;
        private int tail = 0;
        private readonly IComparer<T> comparer;


        public MinimumHeap() : this(4, null)
        {
        }

        public MinimumHeap(int capacity, IComparer<T> comparer)
        {
            arr = new T[4];
            this.comparer = comparer ?? Comparer<T>.Default;
        }


        public void Enqueue(T value)
        {
            if (arr.Length - 1 < tail + 1)
            {
                Array.Resize(ref arr, arr.Length * 2);
            }

            tail++;
            T keyValue = value;
            arr[tail] = keyValue;
            int index = tail;
            while (index / 2 >= 0 &&
                   0 > comparer.Compare(arr[index], arr[index / 2]))
                // heap[index].Key < heap[index / 2].Key
            {
                var temp = arr[index];
                arr[index] = arr[index / 2];
                arr[index / 2] = temp;
                index /= 2;
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
            if (tail < 1)
            {
                return default(T);
            }

            return arr[1];
        }

        private void Heapify(T[] arr, int length, int index)
        {
            while (true)
            {
                int maxPos = index;
                if (index * 2 <= length &&
                    0 < comparer.Compare(arr[index], arr[index * 2])) //arr[index].Key > arr[index * 2].Key)
                {
                    maxPos = index * 2;
                }

                if (index * 2 + 1 <= length && 0 < comparer.Compare(arr[index], arr[index * 2 + 1]))
                {
                    maxPos = index * 2 + 1;
                }

                if (maxPos == index)
                {
                    break;
                }

                T temp = arr[index];
                arr[index] = arr[maxPos];
                arr[maxPos] = temp;
                index = maxPos;
            }
        }
    }
}