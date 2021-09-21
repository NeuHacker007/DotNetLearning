using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    public class SingletonSecond
    {

        private SingletonSecond() //1. 私有构造函数， 避免外部创建
        {
            long lResult = 0;

            for (int i = 0; i < 10000000; i++)
            {
                lResult +=i;
            }

            Thread.Sleep(1000);

            Console.WriteLine($"{nameof(Singleton)} constructed once");
        }

        private static SingletonSecond _singleton = null;
       
        /// <summary>
        /// 静态构造函数： 由CLR保证， 程序第一次使用这个类型前被调用，且只调用一次
        /// </summary>
        static SingletonSecond()
        {
            _singleton = new SingletonSecond();
        }


        public static SingletonSecond CreateInstance()
        {
            return _singleton;
        }
    }
}
