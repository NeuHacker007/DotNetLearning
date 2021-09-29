using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyPattern
{
    /// <summary>
    /// 模拟真实事件
    /// </summary>
    public class RealSubject : ISubject
    {
        /// <summary>
        /// 费时费资源
        /// </summary>
        public RealSubject()
        {
            
            Thread.Sleep(2000);
            long lResult = 0;

            for (int i = 0; i < 100000000; i++)
            {
                lResult += i;
            }

            Console.WriteLine("RealSubject is constructed");
        }
        /// <summary>
        /// 耗时查询
        /// 复杂的业务类封装完成后，因为一些公共逻辑的需求，不断地过来修改
        /// 假如这里是第三方团队提供呢
        /// 不希望业务类变复杂，跟公共逻辑混合在一起
        /// </summary>
        /// <returns></returns>
        public List<string> GetSomethingLong()
        {
            Console.WriteLine("prepare GetSomethingLong");

            Console.WriteLine("Load Large File info");
            Thread.Sleep(1000);
            Console.WriteLine("Read Big DB data table");
            Thread.Sleep(1000);

            Console.WriteLine("Call remote API");
            Thread.Sleep(1000);

            Console.WriteLine("combined results");
            return new List<string>()
            {
                "123",
                "456",
                "789"
            };
        }
        /// <summary>
        /// 耗时操作
        /// </summary>
        public void DoSomethingLong()
        {
            Console.WriteLine("prepare DoSomethingLong");
            Console.WriteLine("Make Order");
            Thread.Sleep(1000);
            Console.WriteLine("SMS Notification");
            Thread.Sleep(1000);

        }
    }
}
