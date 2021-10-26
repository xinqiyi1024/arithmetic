using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020002309_方泽楠_linklist
{
    class LinkList<T>
    {
        public Node<T> Head;

        //构造函数
        public LinkList()
        {
            Head = new Node<T>();
        }

        //求单链表的长度（元素个数）
        public int len()
        {
            int k = 0;
            Node<T> p = Head.Next;
            while (p != null)
            {
                k++;
                p = p.Next;
            }
            return k;
        }

        //添加新元素到单链表的头部
        public void AddFirst(T item)
        {
            Node<T> s = new Node<T>(item);
            s.Next = Head.Next;
            Head.Next = s;
        }

        //
        public void display()
        {
            Node<T> p = new Node<T>();
            p = Head.Next;
            while (p != null)
            {
                Console.Write(p.Date + " ");
                p = p.Next;
            }
            Console.WriteLine();
        }

        //增加新元素到单链表末尾
        public void AddRead(T item)
        {
            Node<T> p = Head;
            while (p.Next != null) 
            {
                p = p.Next;
            }
            p.Next = new Node<T>(item);
        }

        //在第i个位置插入节点
    }
}
