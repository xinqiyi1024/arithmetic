using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thomas
{
    class Stack<T>
    {
        /**栈的最大容量*/
        public int maxSize;
        /**用于存栈的元素*/
        public T[] data;
        /**栈顶指针*/
        public int top;

        /**有参构造*/
        public Stack(int size)
        {
            maxSize = size;
            data = new T[size];
            top = -1;
        }

        /**求栈的长度*/
        public int stackLength()
        {
            return top + 1;
        }

        /**清空栈*/
        public void clearStack()
        {
            top = -1;
        }

        /**判断栈是否为空*/
        public bool isEmpty()
        {
            return top == -1;
        }

        /**判断栈是否满了*/
        public bool isFull()
        {
            return top == maxSize - 1;
        }

        /**将item压入栈中*/
        public T push(T item)
        {
            bool b = false;
            if (!isFull())
            {
                data[++top] = item;
                b = !b;
            }
            return item;
        }

        /**返回栈顶元素，并且出栈*/
        public T pop()
        {
            T item = isEmpty() ? data[-1] : data[top--];
            return item;
        }
    }
}
