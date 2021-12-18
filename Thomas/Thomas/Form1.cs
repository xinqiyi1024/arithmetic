﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Thomas
{
    public partial class Form1 : Form
    {
        /* 全局变量 */
        PictureBox[] startPbs, endPbs;
        Label[] startLbs, endLbs, stackLbs;
        bool[] startFlags = new bool[10];
        bool[] endFlags = new bool[10];
        List<int> startCarriageNums = new List<int>();
        List<int> endCarriageNums = new List<int>();
        int count = 0, startNum = 0, endNum = 0;
        Stack<int> stack = new Stack<int>(9);
        /* 初始化 */
        public Form1()
        {
            InitializeComponent();
            // startPbs数组存放前车厢0-9
            startPbs = new PictureBox[] { start_pb0, start_pb1, start_pb2, start_pb3, start_pb4, start_pb5, start_pb6, start_pb7, start_pb8, start_pb9 };
            // endPbs数组存放后车厢0-9
            endPbs = new PictureBox[] { end_pb0, end_pb1, end_pb2, end_pb3, end_pb4, end_pb5, end_pb6, end_pb7, end_pb8, end_pb9 };
            // startlbs数组存放前车箱数字0-9
            startLbs = new Label[] { start_lb0, start_lb1, start_lb2, start_lb3, start_lb4, start_lb5, start_lb6, start_lb7, start_lb8, start_lb9 };
            // endLbs数组存放后车厢数字0-9
            endLbs = new Label[] { end_lb0, end_lb1, end_lb2, end_lb3, end_lb4, end_lb5, end_lb6, end_lb7, end_lb8, end_lb9 };
            // stackLbs数组存放栈0-8
            stackLbs = new Label[] { stack_lb0, stack_lb1, stack_lb2, stack_lb3, stack_lb4, stack_lb5, stack_lb6, stack_lb7, stack_lb8 };
        }

        /* 点击初始化按钮进行重置 */

        private void init_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                // 将前火车隐藏
                startPbs[i].Visible = false;
                startLbs[i].Visible = false;
                // 将后火车显示
                endPbs[i].Visible = true;
                endLbs[i].Visible = true;
                // 火车全变为绿色
                endPbs[i].Image = Thomas.Properties.Resources._1;
                startPbs[i].Image = Thomas.Properties.Resources._1;
            }
            // 重置数据
            endFlags = new bool[10];
            startCarriageNums = new List<int>();
            endCarriageNums = new List<int>();
            startFlags = new bool[10];
            endFlags = new bool[10];
            // 清空操作区
            carriage_lbx.Items.Clear();
            flow_lbx.Items.Clear();
            // 
            stack = new Stack<int>(9);
            count = startNum = endNum = 0;
        }

        /* 确认软卧车厢，并将车厢变色 */
        private void confirmStart_btn_Click(object sender, EventArgs e)
        {
            int i = int.Parse(start_carriage_cb.Text);
            endFlags[i] = !endFlags[i];
            endPbs[i].Image = endFlags[i] ? Thomas.Properties.Resources._2 : Thomas.Properties.Resources._1;
            endCarriageNums = new List<int>();
            for (int j = 0; j < 10; j++)
            {
                if (endFlags[j]) { endCarriageNums.Add(j); }
            }
        }

        /* 确认调度后的车厢，并写入 */
        private void confirmOver_btn_Click(object sender, EventArgs e)
        {
            int i = int.Parse(over_carriage_cb.Text);
            startFlags[i] = !startFlags[i];
            startPbs[i].Image = startFlags[i] ? Thomas.Properties.Resources._2 : Thomas.Properties.Resources._1;
            startCarriageNums = new List<int>();
            for (int j = 0; j < 10; j++)
            {
                if (startFlags[j]) { startCarriageNums.Add(j); }
            }
            display();
        }

        private void begin_btn_Click(object sender, EventArgs e)
        {
            if (endNum < 10 && startNum < 10)
            {
                int startCount = startCarriageNums.Count;
                int endCount = endCarriageNums.Count;
                if (startCount != endCount)
                {
                    MessageBox.Show("卧铺数量有错，调度前" + startCount + "个" + "调度后" + endCount + "个");
                }
                else
                {
                    count++;
                    Console.WriteLine("startFlag" + startFlags[startNum]);
                    Console.WriteLine("endFlag" + endFlags[endNum]);
                    if (startFlags[endNum] == endFlags[startNum])
                    {
                        flow_lbx.Items.Add("第" + count + "步：第" + startNum++ + "节车厢直接到位");
                        endNum++;
                        Console.WriteLine("startnum" + startNum);
                        Console.WriteLine("endnum" + endNum);
                    }
                    else
                    {
                        if ((startFlags[endNum] && endCarriageNums[0] > startCarriageNums[0]) || (endFlags[startNum] && endCarriageNums[0] < startCarriageNums[0]))
                        {
                            flow_lbx.Items.Add("第" + count + "步：第" + stack.push(startNum++) + "节车厢进库里暂等");
                            Console.WriteLine("startnum" + startNum);
                            Console.WriteLine("endnum" + endNum);
                        }
                        else
                        {
                            flow_lbx.Items.Add("第" + count + "步：第" + stack.pop() + "节车厢从库里调出");
                            endNum++;
                            Console.WriteLine("startnum" + startNum);
                            Console.WriteLine("endnum" + endNum);
                        }
                    }
                    Console.WriteLine("-------------------");
                }
            }
            else if (!stack.isEmpty())
            {
                count++;
                flow_lbx.Items.Add("第" + count + "步：第" + stack.pop() + "节车厢从库里调出");
            }
        }

        private void display()
        {
            carriage_lbx.Items.Clear();
            for (int i = 0; i < startCarriageNums.Count; i++)
            {
                carriage_lbx.Items.Add("第" + startCarriageNums[i] + "车厢");
            }
        }
    }
}