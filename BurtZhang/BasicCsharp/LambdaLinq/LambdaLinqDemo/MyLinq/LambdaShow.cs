using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
    public delegate void NoReturnNoParaOutClass();

    public delegate void GenericDelegate<T>();
    public class LambdaShow
    {
        public delegate void NoReturnNoPara();
        public delegate void NoReturnWithPara(int x, int y);
        public delegate int WithReturnNoPara();
        public delegate string WithReturnWithPara(out int x, ref int y);

        public void Show()
        {
            int k = 1;
            {
                //.NET 1.0, 1.1
                NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);
            }
            {
                // 2.0 匿名方法 访问到调用地方的变量

                NoReturnNoPara method = new NoReturnNoPara(delegate()
                {
                    Console.WriteLine("DO Nothing");
                    Console.WriteLine(k);
                });
            }
            {
                // 3.0 lambda 左边是参数列表  goes to   右边是方法体  本质就是一个方法

                NoReturnNoPara method = new NoReturnNoPara(() => // goes to
                {
                    Console.WriteLine("DO Nothing");
                    Console.WriteLine(k);
                });
            }

            {
                NoReturnWithPara method = new NoReturnWithPara((int x, int y) =>
                {
                    Console.WriteLine("DO Nothing");
                    Console.WriteLine(k);
                });
            }
            {
                // 可以省略参数类型 自动推算 要么都声明参数类型，要么都不声明
                NoReturnWithPara method = new NoReturnWithPara((x, y) =>
                {
                    Console.WriteLine("DO Nothing");
                    Console.WriteLine(k);
                });
            }
            {
                // 方法体只有一行可以省略大括号
                NoReturnWithPara method = (x, y) =>
                {
                    Console.WriteLine("DO Nothing");
                };

                // lambda 表达式是什么？
                // 首先不是委托 委托是类型
                // 也不是委托的实例
                // 只是一个方法 (作用)
                // 实际上编译后是一个类中类，里面的一个internal 方法， 然后被绑定到静态委托类型字段
            }
        }


        private void DoNothing()
        {
            Console.WriteLine("DO Nothing");
        }

    }
}
