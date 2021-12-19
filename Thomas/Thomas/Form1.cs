using System;
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
        bool[] leftFlags = new bool[10];
        bool[] rightFlags = new bool[10];
        List<int> leftCarriageNums = new List<int>();
        List<int> rightCarriageNums = new List<int>();
        int count = 0, rightNum = 0, leftNum = 0, leftHead = 0, rightHead = 0;
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
            rightFlags = new bool[10];
            leftFlags = new bool[10];
            stack = new Stack<int>(9);
            leftCarriageNums = new List<int>();
            rightCarriageNums = new List<int>();
            count = rightNum = leftNum = leftHead = rightHead = 0;
            // 清空操作区
            carriage_lbx.Items.Clear();
            flow_lbx.Items.Clear();
        }

        /* 确认软卧车厢，并将车厢变色 */
        private void confirmStart_btn_Click(object sender, EventArgs e)
        {
            // 获取车厢号
            int i = int.Parse(start_carriage_cb.Text);
            // 车厢变色
            rightFlags[i] = !rightFlags[i];
            endPbs[i].Image = rightFlags[i] ? Thomas.Properties.Resources._2 : Thomas.Properties.Resources._1;
            // 重置数据
            rightCarriageNums = new List<int>();
            // 添加数据
            for (int j = 0; j < 10; j++)
            {
                if (rightFlags[j]) { rightCarriageNums.Add(j); }
            }
        }

        /* 确认调度后的车厢，并写入 */
        private void confirmOver_btn_Click(object sender, EventArgs e)
        {
            // 同上
            int i = int.Parse(over_carriage_cb.Text);
            leftFlags[i] = !leftFlags[i];
            startPbs[i].Image = leftFlags[i] ? Thomas.Properties.Resources._2 : Thomas.Properties.Resources._1;
            leftCarriageNums = new List<int>();
            for (int j = 0; j < 10; j++)
            {
                if (leftFlags[j]) { leftCarriageNums.Add(j); }
            }
            // 调用方法，显示数据
            display();
        }

        private void begin_btn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("----------------------------");

            if (leftNum < 10 && rightNum < 10)
            {
                // 统计软卧个数
                int rightCount = rightCarriageNums.Count;
                int leftCount = leftCarriageNums.Count;
                // 判断，如有误则提示
                if (rightCount != leftCount)
                {
                    MessageBox.Show("卧铺数量有错，调度前" + rightCount + "个" + "调度后" + leftCount + "个");
                }
                // 个数正确
                else
                {
                    // 计算步骤
                    count++;
                    Console.WriteLine("leftNum" + leftNum);
                    // 如果颜色相同直接到位
                    if (leftFlags[leftNum] == rightFlags[rightNum])
                    {
                        startPbs[leftNum].Visible = true;
                        startLbs[leftNum].Visible = true;
                        flow_lbx.Items.Add("第" + count + "步：第" + rightNum++ + "节车厢直接到位");
                        leftNum++;

                    }
                    // 颜色不同，进出栈
                    else
                    {
                        Console.WriteLine("leftHead" + leftHead);
                        Console.WriteLine("rightHead" + rightHead);
                        Console.WriteLine("leftFlags[leftNum]" + leftFlags[leftNum]);
                        Console.WriteLine("rightCarriageNums[rightHead] > leftCarriageNums[leftHead]" + (rightCarriageNums[rightHead] > leftCarriageNums[leftHead]));
                        Console.WriteLine("rightFlags[rightNum]" + rightFlags[rightNum]);
                        Console.WriteLine("rightCarriageNums[rightHead] < leftCarriageNums[leftHead])" + (rightCarriageNums[rightHead] < leftCarriageNums[leftHead]));
                        Console.WriteLine("leftHead" + leftHead);
                        Console.WriteLine("[rightHead" + rightHead);
                        // 软卧在左且右边还有软卧或软卧在右且左边还有软卧
                        if (leftFlags[leftNum] && (rightCarriageNums[rightHead] > leftCarriageNums[leftHead]) || rightFlags[rightNum] && (rightCarriageNums[rightHead] < leftCarriageNums[leftHead]))
                        {

                            // 如果栈顶是软卧，则调出
                            if (stack.stackLength() > 0 && leftFlags[leftNum] == rightFlags[stack.pope()])
                            {
                                Console.WriteLine("len" + stack.stackLength());
                                Console.WriteLine("pop1");
                                Console.WriteLine("pop1" + rightFlags[stack.pope()]);
                                startPbs[leftNum].Visible = true;
                                startLbs[leftNum].Visible = true;
                                flow_lbx.Items.Add("第" + count + "步：第" + stack.pop() + "节车厢从库里调出");
                                leftNum++;
                            }
                            // 非软卧，进栈
                            else
                            {
                                flow_lbx.Items.Add("第" + count + "步：第" + stack.push(rightNum++) + "节车厢进库里暂等");
                            }
                        }
                        // 不符合,调出
                        else
                        {
                            Console.WriteLine("pop2");
                            startLbs[leftNum].Visible = true;
                            startPbs[leftNum].Visible = true;
                            flow_lbx.Items.Add("第" + count + "步：第" + stack.pop() + "节车厢从库里调出");
                            leftNum++;
                        }
                        // 进行下一个软卧操作
                    }
                    leftHead = leftNum - 1 == leftCarriageNums[leftHead] && leftHead < leftCount - 1 ? ++leftHead : leftHead;
                    rightHead = rightNum - 1 == rightCarriageNums[rightHead] && rightHead < rightCount - 1 ? ++rightHead : rightHead;
                    Console.WriteLine("leftNum" + leftNum);

                }
            }
            // 如果栈内还有元素，调出
            else if (!stack.isEmpty())
            {
                count++;
                Console.WriteLine("pop3");
                startPbs[leftNum].Visible = true;
                startLbs[leftNum].Visible = true;
                flow_lbx.Items.Add("第" + count + "步：第" + stack.pop() + "节车厢从库里调出");
            }
        }

        /* 显示调度后的软卧车厢号 */
        private void display()
        {
            carriage_lbx.Items.Clear();
            for (int i = 0; i < leftCarriageNums.Count; i++)
            {
                carriage_lbx.Items.Add("第" + leftCarriageNums[i] + "车厢");
            }
        }
    }
}