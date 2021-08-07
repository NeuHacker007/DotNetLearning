using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
    /// <summary>
    /// 委托: 本质上是一个sealed类， 继承自System.MulticastDelegate， 里面内置了几个方法
    /// </summary>
    public delegate void NoReturnNoParaOutClass();
    public class MyDelegate
    {
        public delegate void NoReturnNoPara<T>(T t);
        public delegate void NoReturnNoPara(); // 1. 声明委托

        public delegate void NoReturnWithPara(int x, int y);

        public delegate int WithReturnNoPara();

        public delegate string WithReturnWithPara(out int x, ref int y);

        public void Show()
        {
            Student student = new Student()
            {
                Id = 123,
                Name = "Ivan",
                Age = 32,
                ClassId = 1
            };

            student.Study();

            {
                //把方法包装成变量， invoke 的时候自动执行方法
                NoReturnNoPara method = new NoReturnNoPara(this.DoNothing); // 2. 委托的实例化， 要求传入参数，参数为一个函数，函数必须与委托有同样的函数签名及返回值

                {
                    //3. 委托实例的调用， 相当于把传入的函数执行一遍
                    method.Invoke(); // Invoke 是delegate IL 中的方法， 相当于调用类的实例方法
                    method(); // 也可以直接省略Invoke进行调用
                }
              
            }

        }

        private void DoNothing()
        {
            Console.WriteLine("Do nothing");
        }

        private static void DoNothingStatic()
        {
            Console.WriteLine("Do Nothing Static");
        }

    }
}
