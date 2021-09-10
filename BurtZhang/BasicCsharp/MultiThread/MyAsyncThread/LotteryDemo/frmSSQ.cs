using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotteryDemo
{
    /// <summary>
    /// 多线程双色球项目
    /// 双色球: 投注号码由6个红色球号码和1个蓝色球号码组成
    ///     红色球号码从01 -- 33 中选择(不能重复)
    ///     蓝色球号码从01 -- 16 中选择(可以跟红色球重复)
    /// 7个球杂乱无章的变化: 球的号码来自于复杂的数据计算 (费时间)
    ///
    /// 
    /// 随机的规则是远程获取一个数据，这个会有较长的时间损耗
    /// 使用多线程
    /// </summary>
    public partial class frmSSQ : Form
    {
        public frmSSQ()
        {
            InitializeComponent();
            btnStart.Enabled = true;
            btnEnd.Enabled = false;
        }

        private string[] RedNums =
        {
            "01","02","03","04","05","06","07","08","09","10"
            ,"11","12","13","14","15","16","17","18","19","20"
            ,"21","22","23","24","25","26","27","28","29","30"
            , "31", "32", "33"
        };

        private string[] BlueNums =
        {
            "01","02","03","04","05","06","07","08","09","10"
            ,"11","12","13","14","15","16"
        };

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                btnStart.Text = "starting";
                btnStart.Enabled = false;
                lblBlue1.Text = "00";
                lblRed1.Text = "00";
                lblRed2.Text = "00";
                lblRed3.Text = "00";
                lblRed4.Text = "00";
                lblRed5.Text = "00";
                lblRed6.Text = "00";
                Thread.Sleep(1000);
                TaskFactory taskFactory = new TaskFactory();
                foreach (var control in gbResult.Controls) 
                {
                    if (control is Label)
                    {
                        Label lbl = (Label) control;

                        if (lbl.Name.Contains("Blue"))
                        {
                            taskFactory.StartNew(() =>
                            {
                                while (true)
                                {
                                    int idx = RandomHelper.GetRandomNumber(0, BlueNums.Length);
                                    string sNum = BlueNums[idx];

                                    // winForm 中如果直接用下面的 子线程去更新主线程UI的控件会触发异常
                                    // 导致无法更新该控件的值。
                                    // lbl.Text = sNum;
                                    UpdateLbl(lbl, sNum);
                                }
                               
                            });
                        }
                    }   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"start exception: {ex.Message}");
                
            }
        }

        private void UpdateLbl(Label lbl, string text)
        {
            if (lbl.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    lbl.Text = text;

                    Console.WriteLine($"Current updateLbl Thread Id {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                })); // 交给 UI线程更新
            }
            else
            {
                lbl.Text = text;
            }
        }
    }
}
