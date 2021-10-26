using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020002309_方泽楠_linklist
{
    class Node<T>
    {
        public T Date;
        public Node<T> Next;

        public Node(T item)
        {
            this.Date = item;
            this.Next = null;
        }

        public Node()
        {
            this.Date = default(T);
            this.Next = null;
        }
    }
}
