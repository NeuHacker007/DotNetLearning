using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Singleton
{
    /// <summary>
    /// 单例模式： 保证进程中，某个类只有一个实例
    ///           怎么样保证呢？ 怎么强制保证
    /// 
    /// 饿汉式： 第一时间创立实例
    /// 懒汉式： 需要才创建实例
    ///
    /// 单例模式会长期持有一个对象，不会释放
    /// 普通实例使用完后释放
    ///
    /// 单例可以只构造一次，提升性能（如果构造函数耗性能）
    ///
    /// 单例就是保证类型只有一个实例： 计数器、数据库连接池
    ///
    /// 程序中某个对象，只有一个实例
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TaskFactory taskFactory = new TaskFactory();

                List<Task> tasks = new List<Task>();

                //  for (int i = 0; i < 5; i++)
                //  {
                //      tasks.Add(taskFactory.StartNew(() =>
                //      {
                //          Singleton singleton = Singleton.CreateInstance();
                //          singleton.Show();
                //      }));
                //  }


                
                for (int i = 0; i < 10000; i++)
                {
                    tasks.Add(taskFactory.StartNew(() =>
                    {
                        Singleton singleton = Singleton.CreateInstance();
                        singleton.Show();
                    }));
                }

                Task.WaitAll(tasks.ToArray());

                Console.WriteLine(Singleton.CreateInstance().iTotal);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }
        }
    }
}
