using System;
using System.Threading;
using System.Threading.Tasks;

namespace AwaitAsyncLibrary
{
    /// <summary>
    /// await/async 关键字
    ///
    /// 任何一个方法都可以加Async，不加await的时候不会异步跟不加是一样的
    /// await 放在task的前面
    ///
    /// await/async 要么不用，要么用到底
    /// </summary>
    public class AwaitAsyncClass
    {
        public static void TestShow()
        {
            Test();
        }

        private async static Task Test()
        {
            Console.WriteLine($"Current Thread Id={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            {
                NoReturnNoAwait();
            }
            {
                // 方法返回值如果是void 就无法在该方法前面放await
                // 方法返回值为空的话，async/await 方法中应该返回Task
                NoReturn();

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(300);
                    Console.WriteLine($"Main thread task ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                }
            }
            {
                Task t = NoReturnTask();
                Console.WriteLine($"Main thread task ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                t.Wait(); // 主线程等待Task的完成
                await t; // await 后的代码会由线程池的子线程执行
            }
            {
                Task<long> t = SumAsync();

                Console.WriteLine($"Main thread task ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                long lResult = t.Result; // 访问result 主线程等待task完成
                t.Wait();

            }
            {
                Task<int> t = SumFactory();
                Console.WriteLine($"Main thread task ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                long lResult = t.Result; // 没有await 和async 普通的task
                t.Wait();
            }

        }

        /// <summary>
        /// 只有async没有await，会有个warn
        /// 跟普通方法没有区别
        /// </summary>
        private static async void NoReturnNoAwait()
        {
            Console.WriteLine($"NoReturnNoAwait Sleep before await, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            Task task = Task.Run(() =>
            {
                Console.WriteLine($"NoReturnNoAwait Sleep before, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                Thread.Sleep(3000);
                Console.WriteLine($"NoReturnNoAwait Sleep after, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            });
            // 主线程执行
            Console.WriteLine($"NoReturnNoAwait sleep after task ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
        }
        private static async void NoReturn()
        {
            //主线程执行
            Console.WriteLine($"NOReturn Sleep before await, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            TaskFactory taskFactory = new TaskFactory();

            Task task = taskFactory.StartNew(() =>
            {
                Console.WriteLine($"NOReturn Sleep before, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                Thread.Sleep(3000);
                Console.WriteLine($"NOReturn Sleep after, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            });

            await task; // 主线程到这里就返回了，执行主线程任务

            // 一流水儿的写下去的，耗时任务就用await
            // 子线程执行    其实是封装成委托，在task之后成为回调（编译器功能  状态及实现）
            //      task.ContinueWith();
            // 这个回调的线程是不确定的；可能是主线程  可能是子线程  也可能是其他线程
            Console.WriteLine($"NOReturn Sleep after await, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
        }

        private static async Task NoReturnTask()
        {
            //主线程执行
            Console.WriteLine($"NOReturn Sleep before await, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            TaskFactory taskFactory = new TaskFactory();

            Task task = taskFactory.StartNew(() =>
            {
                Console.WriteLine($"NOReturn Sleep before, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                Thread.Sleep(3000);
                Console.WriteLine($"NOReturn Sleep after, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            });

            await task;
            Console.WriteLine($"NOReturn Sleep after await, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
        }

        private static async Task<long> SumAsync()
        {
            Console.WriteLine($"SumAsync 111 start, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            long result = 0;

            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"SumAsync {i} await task.run start, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                }

                for (int i = 0; i < 999999999; i++)
                {
                    result += i;

                }
            });
            Console.WriteLine($"SumAsync 111 end, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            return result;
        }

        private static Task<int> SumFactory()
        {
            Console.WriteLine($"SumFactory 111 start, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            TaskFactory taskFactory = new TaskFactory();

            Task<int> iResult = taskFactory.StartNew<int>(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine($"SumFactory 123 Task, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                return 123;
            });
            Console.WriteLine($"SumFactory 111 end, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            return iResult;
        }
    }
}
