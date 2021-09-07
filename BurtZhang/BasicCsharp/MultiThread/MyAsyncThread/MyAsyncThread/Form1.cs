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

        private void btnAsyncAdvanced_Click(object sender, EventArgs e)
        {

            Console.WriteLine($"**********************btnAsyncAdvanced_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");

            Action<string> action = DoSomethingLong;

            IAsyncResult asyncResult = null;
            {
                //回调
                AsyncCallback callback = x =>
                {
                    Console.WriteLine("Is x the same with ayncResult: {0}", object.ReferenceEquals(asyncResult, x));
                    Console.WriteLine(x.AsyncState);

                    Console.WriteLine(
                        $"compute finished {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
                };

                asyncResult = action.BeginInvoke("btnAsyncAdvanced_Click", callback, "hao");

                //如果不用call back， 下面的函数会在线程开始前，子线程计算还未结束就打印出来
                // Console.WriteLine($"compute finished {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
            }

            {
                // 主线程 需要在子线程结束后，才返回UI 可以用以下方法
                AsyncCallback callback = x =>
                {
                    Console.WriteLine("Is x the same with ayncResult: {0}", object.ReferenceEquals(asyncResult, x));
                    Console.WriteLine(x.AsyncState);

                    Console.WriteLine(
                        $"compute finished {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
                };
                asyncResult = action.BeginInvoke("btnAsyncAdvanced_Click", callback, "hao");

                {
                    //带sleep延迟版本
                    int i = 0;
                    while (!asyncResult.IsCompleted) //1. 卡界面 主线程在忙于等待
                    {
                        // 可以等待，边等边做其他操作
                        // 可能最多200ms的延迟，因为延迟的时候可能线程已经结束计算，但我们还等待200ms
                        // Thread.Sleep(200);
                        if (i < 10)
                        {
                            Console.WriteLine($"Upload {i++ * 10}%..");
                        }
                        else
                        {
                            Console.WriteLine($"Upload 99.99%..");
                        }
                        Thread.Sleep(200);
                    }

                    Console.WriteLine($"Upload Successfully");
                }

                {
                    Thread.Sleep(200);
                    Console.WriteLine("Do something");
                    Console.WriteLine("Do something");
                    Console.WriteLine("Do something");
                    Console.WriteLine("Do something");
                    Console.WriteLine("Do something");

                    asyncResult.AsyncWaitHandle.WaitOne();// 利用信号量等待任务完成。 子线程完成后会给主线程发信号，界面同样会卡
                    asyncResult.AsyncWaitHandle.WaitOne(1000);// 等待； 但是最多等待1000ms
                }

                {
                    action.EndInvoke(asyncResult); // 可以等待；获取返回值
                    {
                        Func<int> func = () =>
                        {
                            Thread.Sleep(2000);
                            return DateTime.Now.Day;
                        };

                        Console.WriteLine($"func.Invoke()= {func.Invoke()}");

                       asyncResult = func.BeginInvoke(r =>
                           {
                               func.EndInvoke(r); // 在回调函数当中获取异步操作返回值。但是该返回值只能用一次，要么在回调函数内，要么在回调函数外。
                                Console.WriteLine(r.AsyncState);
                            }
                            , "Ivan");

                       //Console.WriteLine($"func.EndInvoke(asyncResult)={func.EndInvoke(asyncResult)}");
                    }
                }

            }

            Console.WriteLine($"Actually Finished, return to user {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            Console.WriteLine($"**********************btnAsyncAdvanced_Click End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");

        }

        private void btnThread_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"**********************btnThread_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");


            ThreadStart threadStart = () => this.DoSomethingLong("btnThread_Click");

            Thread thread = new Thread(threadStart);

            thread.Start();
            // 这两个方法已经不推荐使用了，因为有可能导致死锁
            //thread.Suspend(); // 线程挂起
            //thread.Resume(); //  唤醒线程

            try
            {
                thread.Abort(); // 销毁， 方式是异常 也不建议
            }
            catch (Exception)
            {

                Thread.ResetAbort();// 取消异常
            }

            thread.Join(500); // 最多等待500毫秒
            Console.WriteLine("等待500ms");
            thread.Join(); //当前线程等待thread完成

            while (thread.ThreadState != ThreadState.Stopped)
            {
                Thread.Sleep(100);
            }

            Console.WriteLine(thread.IsBackground); //默认是前台线程， 启动之后一定要完成任务的，阻止进程退出

            thread.IsBackground = true; // 指定后台线程： 随着进程退出

            thread.Priority = ThreadPriority.Highest; //线程优先级
            // CPU会优先执行 highest 不代表会最先
            Console.WriteLine($"**********************btnThread_Click End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");
        }

        /// <summary>
        /// .NET 2.0 出现 线程池 -- 享元模式 -- 数据库连接池
        /// 1. Thread 提供了太多的API
        /// 2. 无限使用线程 加以限制
        /// 3. 重用线程， 避免重复创建和销毁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThreadPool_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"**********************btnThreadPool_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");
            
            ThreadPool.QueueUserWorkItem(t => this.DoSomethingLong("btnThreadPool_Click"));

            {
                ThreadPool.GetMaxThreads(out int wokThreads, out int completionPortThreads);
                Console.WriteLine($" GetMaxThreads wokThreads={wokThreads}, completionPortThreads= {completionPortThreads} ");
            }

            {
                ThreadPool.GetMinThreads(out int wokThreads, out int completionPortThreads);
                Console.WriteLine($" GetMinThreads wokThreads={wokThreads}, completionPortThreads= {completionPortThreads} ");
            }
            Console.WriteLine("*********************************************");
            ThreadPool.SetMaxThreads(16, 16);
            ThreadPool.SetMinThreads(8, 8);
            {
                ThreadPool.GetMaxThreads(out int wokThreads, out int completionPortThreads);
                Console.WriteLine($" GetMaxThreads wokThreads={wokThreads}, completionPortThreads= {completionPortThreads} ");
            }

            {
                ThreadPool.GetMinThreads(out int wokThreads, out int completionPortThreads);
                Console.WriteLine($" GetMinThreads wokThreads={wokThreads}, completionPortThreads= {completionPortThreads} ");
            }

            {
                //类 包含了一个bool属性
                // false -- WaitOne 等待--Set --True -- WaitOne直接过去
                // true -- Waitone 直接过去 -- reset -- false -- waitone 等待
                ManualResetEvent manualResetEvent = new ManualResetEvent(false);

                
                ThreadPool.QueueUserWorkItem(t =>
                {
                    this.DoSomethingLong("btnThreadPool_Click");
                    manualResetEvent.Set();

                    //manualResetEvent.Reset();
                });

                manualResetEvent.WaitOne();
                // 一般来说不要阻塞线程池线程
                for (int i = 0; i < 20; i++)
                {
                    int k = i;
                    ThreadPool.QueueUserWorkItem(t =>
                    {
                        Console.WriteLine(k);
                        if (k < 18)
                        {
                            manualResetEvent.WaitOne();
                        }
                        else
                        {
                            manualResetEvent.Set();
                        }
                    });
                   
                }

                if (manualResetEvent.WaitOne())
                {
                    Console.WriteLine("没有死锁");
                }
                Console.WriteLine("等待queueUserWorkItem执行完");

            }

            Console.WriteLine($"**********************btnThreadPool_Click End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");
        }
    }
}
