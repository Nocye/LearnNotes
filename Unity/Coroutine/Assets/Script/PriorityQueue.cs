using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class PriorityQueue
    {
        private KeyValuePair<float, Action>[] heap;
        private int tail = 0;

        public PriorityQueue()
        {
            heap = new KeyValuePair<float, Action>[4];
        }

        public void Enqueue(Action task, float time)
        {
            if (heap.Length - 1 < tail + 1)
            {
                Array.Resize(ref heap, heap.Length * 2);
            }

            tail++;
            var keyValue = new KeyValuePair<float, Action>(time, task);
            heap[tail] = keyValue;
            var index = tail;
            while (index / 2 >= 0 && heap[index].Key < heap[index / 2].Key)
            {
                var temp = heap[index];
                heap[index] = heap[index / 2];
                heap[index / 2] = temp;
                index /= 2;
            }
        }

        public void Update(float currentTime)
        {
            if (tail >= 1 && heap[1].Key <= currentTime)
            {
                heap[1].Value?.Invoke();
                Dequeue();
            }
        }

        public void Dequeue()
        {
            heap[1] = heap[tail];
            heap[tail] = default;
            HeapUp(heap, --tail, 1);
        }

        public static void HeapUp(KeyValuePair<float, Action>[] arr, int length, int index)
        {
            while (true)
            {
                int maxPos = index;
                if (index * 2 <= length && arr[index].Key > arr[index * 2].Key)
                {
                    maxPos = index * 2;
                }

                if (index * 2 + 1 <= length && arr[maxPos].Key > arr[index * 2 + 1].Key)
                {
                    maxPos = index * 2 + 1;
                }

                if (maxPos == index)
                {
                    break;
                }

                KeyValuePair<float, Action> temp = arr[index];
                arr[index] = arr[maxPos];
                arr[maxPos] = temp;
                index = maxPos;
            }
        }
    }
}