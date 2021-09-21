using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    public class SingletonThrid
    {
        private SingletonThrid() //1. 私有构造函数， 避免外部创建
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
        /// 静态字段： 在第一次使用这个类之前， 由CLR保证， 初始化且只初始化一次
        /// 这个比静态构造函数还要早
        /// </summary>
        private static SingletonThrid _singletonThrid = new SingletonThrid();

        public static SingletonThrid CreateInstance()
        {
            return _singletonThrid;
        }
    }
}
