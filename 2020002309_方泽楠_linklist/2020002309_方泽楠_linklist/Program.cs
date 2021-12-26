using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _2020002309_方泽楠_linklist
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Console.WriteLine("1、++++++++   建立的链表Linklist1:   10,13,15,18,21   ++++++++");
            LinkList<int> linkList1 = new LinkList<int>();
            linkList1.AddFirst(21);
            linkList1.AddFirst(18);
            linkList1.AddFirst(15);
            linkList1.AddFirst(13);
            linkList1.AddFirst(10);
            linkList1.Display();
            
            Console.WriteLine("2、++++++++   在链表linklist1的第3个位置插入100   ++++++++");
            linkList1.AddI(3, 100);
            linkList1.Display();

            Console.WriteLine("3、++++++++   删除链表linklist1的第2个的元素   ++++++++");
            linkList1.DeleteI(2);
            linkList1.Display();

            Console.WriteLine("4、++++++++   查找值为18的元素   ++++++++");
            Console.WriteLine(linkList1.LocateI(18));

            Console.WriteLine("5、++++++++   建立的链表linklist2:  11,13，14,17,20,23,30   ++++++++");
            LinkList<int> linkList2 = new LinkList<int>();
            linkList2.AddRead(11);
            linkList2.AddRead(13);
            linkList2.AddRead(14);
            linkList2.AddRead(17);
            linkList2.AddRead(20);
            linkList2.AddRead(23);
            linkList2.AddRead(30);
            linkList2.Display();

            Console.WriteLine("6、++++++++   将链表linklist2连接到linklist1后面: ++++++++");
            linkList1.Connect(linkList2);
            linkList1.Display();

            Console.WriteLine("7、++++++++   将链表linklist1中所有值为13的元素删除:  ++++++++ ");
            linkList1.DeleteValue(13);
            linkList1.Display();

            Console.WriteLine("8、++++++++   建立的链表linklist1:   10,13,15,18,25   ++++++++");
            linkList1 = new LinkList<int>();
            linkList1.AddRead(10);
            linkList1.AddRead(13);
            linkList1.AddRead(15);
            linkList1.AddRead(18);
            linkList1.AddRead(25);
            linkList1.Display();
            linkList2.Display();

            Console.WriteLine("9、++++++++   将有序链表linklist1,linklist2合并到linklist3,linklist3仍有序   ++++++++");
            LinkList<int> linklist3 = linkList1.orderedArrangement(linkList1, linkList2);
            linklist3.Display();
        }
    }
}
