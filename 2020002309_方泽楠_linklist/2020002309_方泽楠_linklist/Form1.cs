using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _2020002309_方泽楠_linklist
{
    public partial class Form1 : Form
    {
        LinkList<xs> l1 = new LinkList<xs>();
        xs x = new xs();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            try
            {
                x.xh = int.Parse(tb_xh.Text);
            x.name = tb_name.Text;
            l1.AddRead(x);
            }
            catch (Exception)
            {
                MessageBox.Show("输入错误");
            }
            Display();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            l1.DeleteI(int.Parse(textBox3.Text));
            Display();
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            try
            {
                int i = int.Parse(textBox4.Text);
                x = l1.findI(i).Date;
                MessageBox.Show("学号为" + x.xh + "姓名为" + x.name, i + "的信息为", MessageBoxButtons.OKCancel);
            }
            catch (Exception)
            {
                MessageBox.Show("输入错误");
            }
        }

        private void Display()
        {
            listBox1.Items.Clear();
            Node<xs> p = l1.Head.Next;
            while (p != null)
            {
                listBox1.Items.Add(p.Date.xh + "   " + p.Date.name);
                p = p.Next;
            }
        }
    }
}
