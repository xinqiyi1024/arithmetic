using System;

namespace _2020002309_方泽楠_linklist
{
    public struct xs
    {
        public int xh;
        public String name;
    }

    class LinkList<T>
    {
        /**单链表头*/
        public Node<T> Head;

        /**构造函数*/
        public LinkList()
        {
            Head = new Node<T>();
        }

        /**求单链表的长度（元素个数）*/
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

        /**添加新元素到单链表的头部*/
        public void AddFirst(T item)
        {
            Node<T> s = new Node<T>(item);
            s.Next = Head.Next;
            Head.Next = s;
        }

        /**将线性表中的元素遍历输出*/
        public void Display()
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

        /**增加新元素到单链表末尾*/
        public void AddRead(T item)
        {
            Node<T> p = Head;
            while (p.Next != null)
            {
                p = p.Next;
            }
            p.Next = new Node<T>(item);
        }

        /**查找第i个位置的元素*/
        public Node<T> findI(int i)
        {
            Node<T> h = Head;
            if (i < 1 || i > len())
            {
                return null;
            }
            else
            {
                int count = 1;
                while (h.Next != null && count++ <= i)
                {
                    h = h.Next;
                }
            }
            return h;
        }

        /**在第i个位置插入节点*/
        public void AddI(int i, T item)
        {
            Node<T> p = new Node<T>(item);
            p.Next = findI(i - 1).Next;
            findI(i - 1).Next = p;
        }

        /**删除第i个位置的节点*/
        public void DeleteI(int i)
        {
            bool b = i < 0 || i > len();
            if (!b)
            {
                if (i == 1)
                {
                    Head.Next = len() > 1 ? findI(i).Next : null;
                }
                else
                {
                    findI(i - 1).Next = findI(i).Next != null ? findI(i).Next : null;
                }
            }
            else
            {
                Console.WriteLine("位置输入错误");
            }
        }

        /**查找值的位置*/
        public int LocateI(T item)
        {
            Node<T> h = Head;
            int count = 0;
            while (h != null && !h.Date.Equals(item))
            {
                h = h.Next;
                count++;
            }
            return count;
        }

        /**将链表linklist2连接到linklist1后面*/
        public void Connect(LinkList<T> linklist)
        {
            Node<T> h = this.Head;
            while (h.Next != null)
            {
                h = h.Next;
            }
            h.Next = linklist.Head.Next;
        }

        /**删除链表中所有值为value的节点*/
        public void DeleteValue(T item)
        {
            while (LocateI(item) < len() && LocateI(item) > 0)
            {
                DeleteI(LocateI(item));
            }
        }

        /**将有序链表linklist1与linklist2合并到linklist3(有序)中*/
        public LinkList<int> orderedArrangement(LinkList<int> linklist1, LinkList<int> linklist2)
        {
            LinkList<int> linklist3 = new LinkList<int>();

            Node<int> h1 = linklist1.Head.Next;
            Node<int> h2 = linklist2.Head.Next;
            Node<int> h3 = linklist3.Head;

            while (h1 != null || h2 != null)
            {
                if (h1 != null && h2 != null)
                {
                    if (h1.Date < h2.Date)
                    {
                        h3 = h3.Next = h1;
                        h1 = h1.Next;
                    }
                    else
                    {
                        h3 = h3.Next = h2;
                        h2 = h2.Next;
                    }
                }
                else
                {
                    if (h1 != null)
                    {
                        h3 = h3.Next = h1;
                        h1 = h1.Next;
                    }
                    if (h2 != null)
                    {
                        h3 = h3.Next = h2;
                        h2 = h2.Next;
                    }
                }
            }
            return linklist3;
        }
    }
}
