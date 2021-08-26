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

namespace MyAsyncThread
{
    /// <summary>
    /// 1.进程-线程-多线程， 同步异步
    /// 2. 委托启动异步调用
    /// 3. 多线程特点: 不卡主线程、速度快、无序性
    /// 4. 异步的回调和参数状态
    /// 5. 异步等待的三种方式
    /// 6. 异步返回值
    ///
    /// 进程 线程 计算机概念
    /// 进程： 一个程序运行时， 占用的全部计算资源的总和
    /// 线程： 程序执行流的最小单位；任何操作都是由线程完成的
    ///        线程是依托于进程存在的，一个进程可以包含多个线程
    ///        线程也可以有自己的计算资源
    /// 多线程: 多个执行流同时运行
    ///        1. CPU 太快了， 分时间片 -- 上下文切换（加载环境 --计算-- 保存环境）
    ///           微观角度 一个核同一时刻只能执行一个线程
    ///           宏观角度 是多线程并发
    ///        2. 多CPU 多核 可以独立工作
    ///
    /// Thread 命名空间 -> C# 对线程对象的封装
    ///
    /// 是对方法执行的描述
    /// 同步:完成计算之后，再进入下一行
    /// 异步：不会等待方法的完成， 会直接进入下一行 非阻塞
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"**********************btnSync_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");
            int i = 3;
            int k = 5;
            int m = i + k;

            for (int j = 0; j < 5; j++)
            {
                string name = string.Format($"btnSync_Click_{i}");
                this.DoSomethingLong(name);
            }

            Console.WriteLine($"**********************btnSync_Click End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");
        }

        /// <summary>
        /// 异步方法
        /// 1. 同步方法 卡界面 主(UI)线程忙于计算
        ///    异步多线程方法不卡界面， 主线程完事儿了，计算任务交给子线程做。
        ///
        ///    提升用户体验；
        /// 2. 同步方法慢， 只有一个线程干活
        ///    异步多线程方法 因为多个线程兵法计算
        ///    并不是线性增长
        ///        a. 因为资源换时间， 可能资源不够
        ///        b. 多线程也有管理成本 不是越多越好
        ///    多个独立任务可以同时运行
        /// 3. 异步多线程无序： 启动无序， 执行时间不确定 结束也无序
        ///    一定不要通过延迟毫秒数 来控制线程顺序/启动/执行时间/结束
        ///
        /// 回调/等待状态/信号量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAysnc_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"**********************btnAysnc_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");

            Action<string> action = DoSomethingLong;

            //action.Invoke("btnAysnc_Click1");
            //action("btnAysnc_Click2");
            //action.BeginInvoke("btnAysnc_Click3", null, null);

            for (int j = 0; j < 5; j++)
            {
                string name = string.Format($"btnSync_Click_{j}");
                action.BeginInvoke(name, null, null);
            }

            Console.WriteLine($"**********************btnAysnc_Click End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");
        }

        
        private void DoSomethingLong(string name)
        {
            Console.WriteLine($"**********************DoSomethingLong {name} Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");
            long lResult = 0;
            for (int i = 0; i < 100000000; i++)
            {
                lResult += i;
            }
            Thread.Sleep(2000);
            Console.WriteLine($"**********************DoSomethingLong {name} End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} {lResult}********************");
        }
    }
}
