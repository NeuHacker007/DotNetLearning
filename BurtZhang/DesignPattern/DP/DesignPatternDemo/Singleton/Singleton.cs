using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    public class Singleton
    {
        private Singleton() //1. 私有构造函数， 避免外部创建
        {
            long lResult = 0;

            for (int i = 0; i < 10000000; i++)
            {
                lResult +=i;
            }

            Thread.Sleep(1000);

            Console.WriteLine($"{nameof(Singleton)} constructed once");
        }

        /// <summary>
        /// 3. 全局唯一静态 重用这个变量
        /// </summary>
        private static volatile Singleton _singleton = null; // volatile 可以促进线程安全 让线程按顺序操作
        private static object Singleton_lock = new object();

        /// <summary>
        /// 2. 公开的静态方法提供对象实例
        /// </summary>
        /// <returns></returns>
        public static Singleton CreateInstance()
        {
            #region 版本1.0 线程不安全，会被多个线程构造多次

            //{
            //    // 版本1.0 线程不安全，会被多个线程构造多次
            //    if (_singleton == null)
            //    {
            //        _singleton = new Singleton();
            //    }
            //}

            #endregion

            #region 版本2.0 加入锁 能保证线程安全

            //{
            //    // 版本2.0 加入锁 能保证线程安全 但是性能不好
            //    lock (Singleton_lock)
            //    {
            //        if (_singleton == null)
            //        {
            //            _singleton = new Singleton();
            //        } 
            //    }
            //}

            #endregion
           

            {
                // 版本3.0 double check
                if (_singleton == null)
                {
                    // 假如现在5个线程过来初始化 第一个线程去把 _singleton 实例化；
                    // 5 分钟后， 又有100个线程同时创建
                    //            排队 -- 判断不为空 -- 返回 其实不该排队了，应该直接判断

                    lock (Singleton_lock) // 保证只有一个线程进去判断 + 初始化
                    {
                        if (_singleton == null) // 这个也不能去掉， 第一次5个线程进来的时候， 如果没有这个判断，还是重复创建的
                        {
                            _singleton = new Singleton();
                        }
                    }
                }
            }
           

            return _singleton;
        } //懒汉式， 调用了方法采取构造


        public int iTotal = 0;

        public void Show()
        {
            iTotal++;
        }


    }
}
