using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            //Application.Run(new Form1());
            LinkList<int> linkList = new LinkList<int>();
            linkList.AddFirst(21);
            linkList.AddFirst(18);
            linkList.AddFirst(15);
            linkList.AddFirst(13);
            linkList.AddFirst(10);
            linkList.display();
            Console.WriteLine(linkList.len());
        }
    }
}
