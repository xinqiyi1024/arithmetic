using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2020002309_方泽楠_Stack
{
    class c_queue<T>
    {
        /**队列的最大容量*/
        public int maxSize;
        /**用于存栈的元素*/
        public T[] data;
        /**队头指针*/
        public int front;
        /**队尾指针*/
        public int rear;


        /**构造方法，初始化栈*/
        public c_queue(int size)
        {
            maxSize = size;
            data = new T[size];
            front = rear = 0;
        }

        /**常用操作：求队列的长度（栈中的元素个数）*/
        public int queueLength()
        {
            return (rear - front + maxSize) % maxSize;
        }

        /**常用操作：清空队列*/
        public void clearQueue()
        {
            rear = front;
        }

        /**常用操作：判断队列是否为空*/
        public bool isEmpty()
        {
            return rear == front;
        }

        /**常用操作：判断队列是否为满*/
        public bool isFull()
        {
            return front == (rear + 1) % maxSize;
        }

        /**将item插入此队列*/
        public bool offer(T item)
        {
            bool b = false;
            if (!isFull()) 
            {
                data[rear++] = item;
                b = !b;
            }
            return b;
        }

        /**返回队首元素，并且出队列*/
        public T poll() 
        {
            T item = isEmpty() ? data[-1] : data[front++];
            return item;
        }
    }
}
