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
    public partial class FormQueue : Form
    {
        c_queue<Car> queue = new c_queue<Car>(10);
        Car car = new Car();

        public FormQueue()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            car.carId = tb_num.Text;
            car.inTime = DateTime.Now;
            queue.offer(car);
            display();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            queue.poll();
            display();
        }

        private void display() 
        {
            listBox1.Items.Clear();
            for (int i = queue.front; i != queue.rear; i = (i + 1) % queue.maxSize)
            {
                listBox1.Items.Add(queue.data[i].carId + "   |  " + queue.data[i].inTime);
            }
        }

        private void FormQueue_FormClosing(object sender, FormClosingEventArgs e)
        {
            new FormChoice().Show();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lb_time.Text = DateTime.Now.ToString();
            lb_num.Text = "" + (queue.maxSize - queue.queueLength());
            if (listBox1.SelectedIndex != -1)
            {
                car = queue.data[listBox1.SelectedIndex];
                lb_carNum.Text = car.carId;
                lb_stopTime.Text = (DateTime.Now - car.inTime).ToString();
                lb_pay.Text = (DateTime.Now - car.inTime).Ticks / (2 << 21) + "";
            }
        }
    }
}
