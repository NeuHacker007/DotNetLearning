﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreadState = System.Threading.ThreadState;

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
                action.BeginInvoke(name, null, null); // 是使用线程池的
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
            {
                this.ThreadWithCallBack(() => Console.WriteLine($"Action {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}"),
                    () => Console.WriteLine($"Callback {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}"));

                Func<int> func = this.ThreadWithReturn<int>(() =>
                {
                    Thread.Sleep(2000);
                    return DateTime.Now.Millisecond;
                });
                Console.WriteLine("12345234");
                int iResult = func.Invoke();
                Console.WriteLine(iResult);
            }

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

        // 启动子线程计算 -- 完成委托后， 该线程去执行后回调委托
        private void ThreadWithCallBack(Action act, Action callBack)
        {
            Thread thread = new Thread(() =>
            {
                act.Invoke();
                callBack.Invoke();

            });

            thread.Start();
        }
        // 待返回的异步调用 需要获取返回值

        /// <summary>
        /// 又要结果，又要不阻塞
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        private Func<T> ThreadWithReturn<T>(Func<T> func)
        {
            T t = default(T);
            Thread thread = new Thread(() =>
            {
                func.Invoke();
            });

            return () =>
            {
                //while (thread.ThreadState != ThreadState.Stopped)
                //{
                //    Thread.Sleep(200);
                //}

                thread.Join();

                return t;
            };
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

        /// <summary>
        /// .Net 3.0 出现， 基于thread pool 实现
        /// task 增加了多个API
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTask_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"**********************btnTask_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");
            {
                //Thread.Sleep VS Task.Delay

                {
                    // Thread.Sleep 会卡线程，然后再执行后续
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    Thread.Sleep(2000);

                    stopwatch.Stop();
                    Console.WriteLine(stopwatch.ElapsedMilliseconds);
                }
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    // Task Delay 不会卡线程， 是延迟启动 continuewith的任务
                    // 延迟触发
                    Task.Delay(2000).ContinueWith(t =>
                    {
                        stopwatch.Stop();
                        Console.WriteLine(stopwatch.ElapsedMilliseconds);
                    });
                }
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    //效果与delay相似
                    Task.Run(() =>
                    {
                        Thread.Sleep(2000);

                        stopwatch.Stop();
                        Console.WriteLine(stopwatch.ElapsedMilliseconds);
                    });
                }
            }
            {
                // 线程 -- task -- 启动方式
                Task.Run(() => this.DoSomethingLong("btnTask_Click1"));
                Task.Run(() => this.DoSomethingLong("btnTask_Click2"));

                TaskFactory taskFactory = Task.Factory;
                taskFactory.StartNew(() => this.DoSomethingLong("btnTask_Click3"));
                new Task(() => this.DoSomethingLong("btnTask_Click4")).Start();
            }

            {
                //如何感知某个任务已经完成
                TaskFactory factory = new TaskFactory();
                List<Task> tasks = new List<Task>();

                tasks.Add(factory.StartNew((o) => this.Coding("Ivan", "Client"), "Ivan"));
                tasks.Add(factory.StartNew((o) => this.Coding("Eva", "Portal"), "Eva"));
                tasks.Add(factory.StartNew((o) => this.Coding("Recheal", "Service"), "Recheal"));
                tasks.Add(factory.StartNew((o) => this.Coding("jack", "Jump"), "jack"));
                tasks.Add(factory.StartNew((o) => this.Coding("Elena", "Monitor"), "elena"));

                factory.ContinueWhenAny(tasks.ToArray(), t =>
                {
                    Console.WriteLine(t.AsyncState);
                    Console.WriteLine($"integration-test {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                });

                factory.ContinueWhenAll(tasks.ToArray(), t =>
                {
                    Console.WriteLine(t[0].AsyncState);
                    Console.WriteLine($"integration-test {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                });
            }

            {
                List<Task> tasks = new List<Task>();
                // 什么时候用多线程？ 任务能并发运行；提升速度; 优化体验
                Console.WriteLine($"Project manager start a project ... {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                Console.WriteLine($"pre-job ... {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                Console.WriteLine($"program.... {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                tasks.Add(Task.Run(() => this.Coding("Ivan", "Client")));
                tasks.Add(Task.Run(() => this.Coding("Eva", "Portal")));
                tasks.Add(Task.Run(() => this.Coding("Recheal", "Service")));
                tasks.Add(Task.Run(() => this.Coding("jack", "Jump")));
                tasks.Add(Task.Run(() => this.Coding("Elena", "Monitor")));


                tasks.Add(Task.WhenAny(tasks.ToArray()).ContinueWith(t =>
               {
                   Console.WriteLine($"haha .... {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
               }));

                tasks.Add(Task.WhenAll(tasks.ToArray()).ContinueWith(t =>
                {
                    //此时的continue with 开启一个新的线程执行，很可能会晚于
                    // line 525 的控制台输出，如果想要让其早于line 525 输出，需要把该task 加入tasks列表当中
                    Console.WriteLine($"Integration test .... {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                }));


                // 一个业务查询操作有多个数据源， 首页--多线程并发--拿到全部数据后才返回 Wait All
                // 一个商品搜索操作有多个数据源， 商品搜索 -- 多个数据源 -- 多线程并发 -- 只需要一个结果即可 -- Wait Any
                // 阻塞： 需要完成后再继续。


                // 多线程加快速度， 但是全部任务完成后，才能执行的操作
                Task.WaitAny(tasks.ToArray()); // 会阻塞当前线程，等着某个任务完成后，才进入下一行 卡界面
                Console.WriteLine($"complete milestone {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                Task.WaitAll(tasks.ToArray(), 1000); // 限时等待
                Task.WaitAll(tasks.ToArray()); // 会阻塞当前线程，等着全部任务都完成后，才进入下一行
                {
                    //又想等待又想不卡界面可以再包一层线程。因为waitAll wait any 卡主的是当前线程。

                    Task.Run(() =>
                    {
                        // 此时 wait all/any 紧卡住新开的线程而不会阻塞主线程 （UI线程）
                        Task.WaitAny(tasks.ToArray()); // 会阻塞当前线程，等着某个任务完成后，才进入下一行 卡界面
                        Console.WriteLine($"complete milestone {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                        Task.WaitAll(tasks.ToArray(), 1000); // 限时等待
                        Task.WaitAll(tasks.ToArray()); // 会阻塞当前线程，等着全部任务都完成后，才进入下一行
                        Console.WriteLine($"online {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                    });
                }


                {
                    // 完成10000个任务 但是只有11个线程
                    List<int> list = new List<int>();

                    for (int i = 0; i < 10000; i++)
                    {
                        list.Add(i);
                    }
                    Action<int> act = i =>
                    {
                        Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString("00"));
                        Thread.Sleep(new Random(i).Next(100, 300));
                    };


                    List<Task> taskList = new List<Task>();

                    foreach (var item in list)
                    {
                        int k = item;

                        taskList.Add(Task.Run(() => act.Invoke(k)));

                        if (taskList.Count > 10)
                        {
                            Task.WaitAny(taskList.ToArray());

                            taskList = taskList.Where(t => t.Status != TaskStatus.RanToCompletion).ToList();
                        }

                        Task.WaitAll(taskList.ToArray());
                    }
                }

                Console.WriteLine($"online {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            }


            Console.WriteLine($"**********************btnTask_Click End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");
        }

        private void Coding(string name, string task)
        {
            Console.WriteLine($"**********************Coding {name}, {task} Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");
            Thread.Sleep(200);
            Console.WriteLine($"**********************Coding {name}, {task} End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");
        }

        /// <summary>
        /// 并行编程 在Task的基础上做了封装 4.5
        /// Parallel 卡界面， 主线程参与计算，节约了一个线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParallel_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"**********************btnParallel_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");

            {
                Parallel.Invoke(() => this.Coding("Ivan", "Web")
                , () => this.Coding("Eva", "backend")
                , () => this.Coding("Elena", "frontend"));
            }

            {
                Parallel.For(0, 5, i =>
                {
                    this.Coding("Ivan", "Web" + i);
                });
            }

            {
                Parallel.ForEach(new string[] { "0", "1", "2", "3", "4" }, i => this.Coding("Ivan", "Web" + i));
            }
            {
                ParallelOptions options = new ParallelOptions();
                options.MaxDegreeOfParallelism = 3; // 控制并发数量
                Parallel.For(0, 10, options, i =>
                 {
                     this.Coding("Ivan", "Web" + i);
                 });
            }
            {
                ParallelOptions options = new ParallelOptions();
                options.MaxDegreeOfParallelism = 3; // 控制并发数量
                Parallel.For(0, 40, options, (i, state) =>
                 {
                     if (i == 2)
                     {
                         Console.WriteLine("Thread cancel, end of task");
                         state.Break();//当前这次结束
                         return;
                     }

                     if (i == 20)
                     {
                         Console.WriteLine("Thread cancel, end of Parallel");
                         state.Stop();//结束 Parallel
                         return; // 必须带上
                     }
                     this.Coding("Ivan", "Web" + i);
                 });
                // Break: 实际上结束了当前这个线程； 如果是主线程，等于Parallel 都结束了
            }

            Console.WriteLine($"**********************btnParallel_Click End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");
        }

        private static readonly object btnThreadCore_Click_lock = new object(); // MSDN 标准写法

        private int TotalCount = 0;
        private List<int> intList = new List<int>();

        private void btnThreadCore_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"**********************btnThreadCore_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");

            try
            {
                TaskFactory taskFactory = new TaskFactory();
                List<Task> tasks = new List<Task>();

                #region 异常处理
                // 线程里面的异常被吞掉了，因为已经脱离最外层的 Try catch 的范围了
                // line 685 ~ 697 会优先于 11， 12 异常结束，如果想在最外层catch 住
                // 需要在try 的最后一行加入wait all； wait all 会抓到所有多线程的所有exception
                // 线程里面不允许出现异常， 自己处理好 -- 最佳实践
                for (int i = 0; i < 20; i++)
                {
                    var name = string.Format($"btnThreadCore_Click_{i}");

                    Action<object> act = t =>
                    {
                        try
                        {
                            Thread.Sleep(2000);
                            if (t.ToString().Equals("btnThreadCore_Click_11"))
                            {
                                throw new Exception(string.Format($"{t} failed"));
                            }

                            if (t.ToString().Equals("btnThreadCore_Click_12"))
                            {
                                throw new Exception(string.Format($"{t} failed"));
                            }

                            Console.WriteLine("{0} succeed", t);
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);

                        }
                    };

                    tasks.Add(taskFactory.StartNew(act, name));
                }

                Task.WaitAll(tasks.ToArray());

                #endregion

                #region 线程取消

                // 多个线程并发，某个失败后，希望通知别的线程，都停下来
                // task 是外部无法中止的；因为线程是OS的资源，无法掌控啥时候取消
                // 线程自己停止自己 -- 公共的访问变量 -- 修改它 -- 线程不断地检测它
                // CancellationTokenSource 去标志任务是否取消，
                // cancel 表示取消; IsCancellationRequested 是否已经取消
                // Token 启动Task的时候传入， 那么如果cancel了， 这个任务会放弃启动，抛出异常
                CancellationTokenSource cts = new CancellationTokenSource();

                for (int i = 0; i < 40; i++)
                {
                    var name = string.Format($"btnThreadCore_Click_{i}");

                    Action<object> act = t =>
                    {
                        try
                        {
                            Thread.Sleep(2000);
                            if (t.ToString().Equals("btnThreadCore_Click_11"))
                            {
                                throw new Exception(string.Format($"{t} failed"));
                            }

                            if (t.ToString().Equals("btnThreadCore_Click_12"))
                            {
                                throw new Exception(string.Format($"{t} failed"));
                            }

                            if (cts.IsCancellationRequested)
                            {
                                Console.WriteLine("{0} canceled", t);
                            }
                            else
                            {
                                Console.WriteLine("{0} succeed", t);
                            }
                        }
                        catch (Exception exception)
                        {
                            cts.Cancel();
                            Console.WriteLine(exception.Message);

                        }
                    };

                    tasks.Add(taskFactory.StartNew(act, name, cts.Token));

                }

                Task.WaitAll(tasks.ToArray());

                #endregion

                #region 多线程临时变量

                for (int i = 0; i < 5; i++)
                {
                    Task.Run(() =>
                    {
                        Thread.Sleep(100);
                        // 会打印出5个5
                        Console.WriteLine(i);
                    });
                }

                for (int i = 0; i < 5; i++)
                {
                    int k = i;
                    Task.Run(() =>
                    {
                        Thread.Sleep(100);
                        // 会打印出0-5
                        Console.WriteLine(k);
                    });
                }

                //i 最后是5 全程只有一个i, sleep后 等着打印的时候， i = 5
                // k        全程有5个k 分别是0 1 2 3 4
                // k 在外面声明 全程只有一个K 等着打印的时候， k = 4
                for (int i = 0; i < 5; i++)
                {
                    int k = i;

                    new Action(() =>
                    {
                        Thread.Sleep(100);
                        Console.WriteLine($"k={k}; i={i}");
                    }).BeginInvoke(null, null);
                }

                #endregion

                #region 线程安全 lock
                // 共有变量: 所有线程都能访问的局部变量/全局变量/数据库的某个值/硬盘文件
                // 线程内部不共享的变量是安全的
                
                // 1. lock 解决， 因为只有一个线程可以进去，没有并发，所以OK 但是牺牲了性能， 所以要尽可能的缩小lock的范围
                // 2. 安全队列 ConcurrentQueue<> 还是一个线程去完成操作
                // 3. 最佳的方案就是 不要冲突--数据拆分,避免冲突
                {
                    // Without multi-thread
                    for (int i = 0; i < 10000; i++)
                    {
                        int k = i;

                        this.TotalCount += 1;
                        this.intList.Add(k);

                    }

                    Console.WriteLine(this.TotalCount); // 10000
                    Console.WriteLine(intList.Count); // 10000

                    this.TotalCount = 0;
                    intList.Clear();
                }

                {
                    // multi-thread unsafe 
                    tasks.Clear();
                    int TotalCountIn = 0; // 由于该变量也可以被各个线程访问，所以也存在不安全
                    for (int i = 0; i < 10000; i++)
                    {
                        int k = i;
                        int m = 3 + 2; //因为在线程当中所以m不会存在线程不安全的问题。
                        tasks.Add(taskFactory.StartNew(() =>
                        {
                            this.TotalCount += 1;
                            this.intList.Add(k);
                        }));
                    }

                    Task.WaitAll(tasks.ToArray());

                    // 计数不足10000 是因为存在多个线程覆盖了彼此的值
                    // 线程1 在0 加 1 count = 1
                    // 线程2 在1 加 1 count = 2 
                    // 线程3 在0 加 1 count = 1 线程3 覆盖线程2 
                    Console.WriteLine(this.TotalCount); // < 10000
                    Console.WriteLine(TotalCountIn);   // < 10000 
                    Console.WriteLine(intList.Count); //  < 10000

                    this.TotalCount = 0;
                    intList.Clear();
                }
                {
                    // Multi-thread safe lock
                    tasks.Clear();
                    int TotalCountIn = 0; // 由于该变量也可以被各个线程访问，所以也存在不安全
                    for (int i = 0; i < 10000; i++) // 由于 i 变量也可以被各个线程访问，所以也存在不安全
                    {
                        int k = i;
                        int m = 3 + 2; //因为在线程当中所以m不会存在线程不安全的问题。


                        tasks.Add(taskFactory.StartNew(() =>
                        {
                            {
                                string teacher = "Eleven";
                                string teacherVIP = "Eleven";

                                // 虽然两个变量名称不同，但是对于 string 来说，
                                // teacher 和 teacherVIP 使用的是同一个引用链接
                                // 故而 以下两个锁实际上是同一个锁。 

                                lock (teacher)
                                {

                                }

                                lock (teacherVIP)
                                {

                                }

                            }

                            
                            // private static readonly object btnThreadCore_Click_lock = new object();
                            // private => 防止外面也去lock该对象，
                            // static => 保证全场唯一， 不管new 多少个form 1， 都只有这一个对象 避免不同实例，锁不同
                            // readonly => 不要改动
                            // object => 表示引用


                            {
                                lock (this)
                                {
                                    // this -> form1 的实例 每次实例化不同的锁，各搞各的, 同一个实例是相同的锁
                                    // 但是这个实例别人也能访问到， 别人也能锁定
                                    // 推荐使用 -> private readonly object btnThreadCore_Click_lock = new object();
                                }
                            }

                            lock (btnThreadCore_Click_lock) // lock 后的方法快，任意时刻只有一个线程可以进入
                            // 值类型无法lock，编译器会报错，
                            // 只能锁引用类型，占用这个引用链接 不要用string 因为享元模式
                            {
                                this.TotalCount += 1;
                                TotalCountIn += 1;
                                this.intList.Add(k);
                            }

                            // lock 语法糖 等同于如下code
                            {
                                Monitor.Enter(btnThreadCore_Click_lock);
                                this.TotalCount += 1;
                                TotalCountIn += 1;
                                this.intList.Add(k);
                                Monitor.Exit(btnThreadCore_Click_lock);
                            }

                        }));
                    }

                    Task.WaitAll(tasks.ToArray());

                    Console.WriteLine(this.TotalCount); // < 10000
                    Console.WriteLine(TotalCountIn);   // < 10000 
                    Console.WriteLine(intList.Count); //  < 10000

                    this.TotalCount = 0;
                    intList.Clear();
                }



                #endregion
            }
            catch (AggregateException aggregateException)
            {
                foreach (var aggregateExceptionInnerException in aggregateException.InnerExceptions)
                {
                    Console.WriteLine(aggregateExceptionInnerException.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"**********************btnThreadCore_Click End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}********************");
        }
    }
}