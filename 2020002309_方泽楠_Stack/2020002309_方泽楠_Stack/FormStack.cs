using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _2020002309_方泽楠_Stack
{
    public partial class FormStack : Form
    {
        SeqStack<Car> stack = new SeqStack<Car>(10);
        Car car = new Car();

        public FormStack()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            car.carId = tb_num.Text;
            car.inTime = DateTime.Now;
            stack.push(car);
            display();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            stack.pop();
            display();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_time.Text = DateTime.Now.ToString();
            lb_num.Text = "" + (stack.maxSize - stack.stackLength());
            if(listBox1.SelectedIndex != -1) 
            {
                car = stack.data[listBox1.SelectedIndex];
                lb_carNum.Text = car.carId;
                lb_stopTime.Text = (DateTime.Now - car.inTime).ToString();
                lb_pay.Text = (DateTime.Now - car.inTime).Ticks / (2 << 21) + "";
            }
            
        }

        private void display() 
        {
            listBox1.Items.Clear();
            for(int i = 0;i < stack.stackLength();i++) {
                listBox1.Items.Add(stack.data[i].carId + "   |  " + stack.data[i].inTime);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            new FormChoice().Show();
        }      
    }
}
