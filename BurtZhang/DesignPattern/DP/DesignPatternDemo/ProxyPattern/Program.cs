using System;

namespace ProxyPattern
{
    /// <summary>
    /// 1. 代理模式： 通过B来完成对A的访问
    /// 2. AOP: 日志代理 延迟代理 权限代理 单例代理 缓存代理
    ///        面向切面编程，不破坏类型封装的前提下，增加额外功能
    /// 3. 封装webservice orm
    ///
    /// 应用 代理模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    //new 一个对象  站着一些资源  但是干别的事儿去了
                    ISubject subject = new RealSubject(); // new 数据库连接
                    Console.WriteLine("do something else"); // 准备一些参数， 做一些判断
                    Console.WriteLine("do something else"); // new command 拼装 SQL
                    Console.WriteLine("do something else");
                    subject.GetSomethingLong();
                    subject.DoSomethingLong();
                }

                {
                    ISubject subject = new ProxySubject();
                    subject.GetSomethingLong();
                    subject.DoSomethingLong();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
