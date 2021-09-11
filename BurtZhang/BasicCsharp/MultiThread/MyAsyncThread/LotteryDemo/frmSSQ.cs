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

        private static readonly object frmSSQ_Lock = new object();
        private bool IsGoOn = true;
        private List<Task> tasks = new List<Task>();
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                btnStart.Text = "starting";
                btnStart.Enabled = false;
                tasks.Clear();
                lblBlue1.Text = "00";
                lblRed1.Text = "00";
                lblRed2.Text = "00";
                lblRed3.Text = "00";
                lblRed4.Text = "00";
                lblRed5.Text = "00";
                lblRed6.Text = "00";
                IsGoOn = true;
                Thread.Sleep(1000);
                TaskFactory taskFactory = new TaskFactory();
                foreach (var control in gbResult.Controls)
                {
                    if (control is Label)
                    {
                        Label lbl = (Label)control;

                        if (lbl.Name.Contains("Blue"))
                        {
                            tasks.Add(taskFactory.StartNew(() =>
                           {
                               while (this.IsGoOn)
                               {
                                   int idx = RandomHelper.GetRandomNumberLong(0, BlueNums.Length);
                                   string sNum = BlueNums[idx];

                                   // winForm 中如果直接用下面的 子线程去更新主线程UI的控件会触发异常
                                   // 导致无法更新该控件的值。
                                   // lbl.Text = sNum;
                                   UpdateLbl(lbl, sNum);
                               }

                           }));
                        }
                        else
                        {
                            tasks.Add(taskFactory.StartNew(() =>
                            {
                                while (IsGoOn)
                                {

                                    // 已经来就已经锁住了，导致实际效果跟单线程执行一样
                                    //  lock (frmSSQ_Lock)
                                    //  {
                                    //      int idx = RandomHelper.GetRandomNumberLong(0, RedNums.Length);
                                    //      string sNum = RedNums[idx];

                                    //      if (IsRedExist(sNum))
                                    //      {
                                    //          continue; //重复了就放弃更新， 重新获取
                                    //      }
                                    //      // winForm 中如果直接用下面的 子线程去更新主线程UI的控件会触发异常
                                    //      // 导致无法更新该控件的值。
                                    //      // lbl.Text = sNum;
                                    //      UpdateLbl(lbl, sNum);
                                    //  }

                                    {
                                        int idx = RandomHelper.GetRandomNumberLong(0, RedNums.Length);
                                        string sNum = RedNums[idx];

                                        lock (frmSSQ_Lock)
                                        {
                                            if (IsRedExist(sNum))
                                            {
                                                continue; //重复了就放弃更新， 重新获取
                                            }
                                            // winForm 中如果直接用下面的 子线程去更新主线程UI的控件会触发异常
                                            // 导致无法更新该控件的值。
                                            // lbl.Text = sNum;
                                            UpdateLbl(lbl, sNum);

                                        }

                                    }

                                }

                            }));
                        }
                    }
                }

                // 这种等待不靠谱，因为虽然每2秒更新一次数据，
                // 但是由于红球不能重复，一旦发现有重复需要从新获取，
                // 耗时可能超过3秒等待。如果写死时间并不能真正解决问题
                // Thread.Sleep(3000);

                //while (true)
                //{
                //    Thread.Sleep(1000);
                //    // 死锁: 主线程等着子线程更新数据；子线程又等着主线程来更新
                //    if (! this.IsRedExist("00") && !this.lblBlue1.Text.Equals("00"))
                //    {
                //        btnEnd.Enabled = true;
                //        break;
                //    }
                //}

                Task.Run(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        // 死锁: 主线程等着子线程更新数据；子线程又等着主线程来更新
                        if (!this.IsRedExist("00") && !this.lblBlue1.Text.Equals("00"))
                        {
                            // 子线程不能直接更新UI主线程，必须使用updatelabel 中的方式更新一下
                            // 即 调用 control 父类的invoke方法把UI更新动作交给主线程(UI)
                            this.Invoke(new Action(() =>
                            {
                                btnEnd.Enabled = true;
                            }));

                            break;
                        }
                    }
                });

                taskFactory.ContinueWhenAll(tasks.ToArray(), ts => ShowResult());
                //  btnEnd.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"start exception: {ex.Message}");

            }
        }

        private void ShowResult()
        {
            MessageBox.Show(string.Format("Lottery Result: {0} {1} {2} {3} {4} {5}  Blue: {6}",
                lblRed1.Text,
                lblRed2.Text,
                lblRed3.Text,
                lblRed4.Text,
                lblRed5.Text,
                lblRed6.Text,
                lblBlue1.Text

                ));
        }
        private bool IsRedExist(string sNum)
        {
            List<string> list = new List<string>();
            foreach (var control in gbResult.Controls)
            {
                if (control is Label)
                {
                    Label lbl = (Label)control;


                    if (lbl.Name.Contains("Red") && lbl.Text.Equals(sNum))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void UpdateLbl(Label lbl, string text)
        {
            if (lbl.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    //  if (!IsGoOn) return; // 此处为了使得点击Stop按钮后，界面不再更新, 放弃了最后那次更新
                    //  不加这个变量也可以做到，message box 和 UI result 区域显示的结果一致， 需要用到 wait all
                    lbl.Text = text;
                    Console.WriteLine(
                        $"Current updateLbl Thread Id {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                })); // 交给 UI线程更新
            }
            else
            {
                lbl.Text = text;
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnEnd.Enabled = false;
            IsGoOn = false;
            // 会造成死锁，主线程等着子线程的任务全部结束，但是子线程还等待主线程更新界面
            //  Task.WaitAll(tasks.ToArray()); 
            //  this.ShowResult();
        }
    }
}
