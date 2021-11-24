using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _2020002309_方泽楠_Stack
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
            new FormChoice().Show();
            Application.Run();
        }
    }
}
