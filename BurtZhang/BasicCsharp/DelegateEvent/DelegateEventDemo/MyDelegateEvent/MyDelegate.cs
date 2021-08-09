using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
    /// <summary>
    /// 委托: 本质上是一个sealed类，
    ///      继承自System.MulticastDelegate,
    ///      里面内置了几个方法
    ///
    /// 委托3个意义:
    /// 1. 委托解耦，减少代码
    /// 2. 异步多线程
    /// 
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

            {
                // beginInvoke
                WithReturnNoPara method = new WithReturnNoPara(this.GetSomething);
                int iResult = method.Invoke();
                iResult = method();

                var result = method.BeginInvoke(null, null);// 异步调用
                method.EndInvoke(result);
            }
            {
                // 多途径实例化

                {
                    NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);
                }
                {
                    NoReturnNoPara method = new NoReturnNoPara(DoNothingStatic);
                }
                {
                    NoReturnNoPara method = new NoReturnNoPara(Student.StudyAdvanced);
                }
                {
                    NoReturnNoPara method = new NoReturnNoPara(new Student().Study);
                }
            }
            {
                
                // 多播委托: 一个变量保存多个方法，可以增减;Invoke时候可以按顺序执行
                // += 为委托实例按顺序增加方法，形成方法链, Invoke时,是按顺序依次执行
                NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);
                method += new NoReturnNoPara(this.DoNothing);
                method += new NoReturnNoPara(DoNothingStatic);
                method += new NoReturnNoPara(Student.StudyAdvanced);
                method += new NoReturnNoPara(new Student().Study);// 不是同一个实例， 所以是不同的方法
                method += new NoReturnNoPara(student.Study);
                method.Invoke();


                method.BeginInvoke(null, null); // 多播委托不能异步

                foreach (NoReturnNoPara item in method.GetInvocationList())
                {
                        item.Invoke();
                }

                // -= 为委托实例移除方法， 从方法链的尾部开始匹配,
                // 遇到第一个完全吻合的,移除且移除一个，没有也不异常
                method -= new NoReturnNoPara(this.DoNothing);
                method -= new NoReturnNoPara(DoNothingStatic);
                method -= new NoReturnNoPara(Student.StudyAdvanced);
                method -= new NoReturnNoPara(new Student().Study);
                method -= new NoReturnNoPara(student.Study);

                method.Invoke(); 

                {
                    WithReturnNoPara method1 = new WithReturnNoPara(this.GetSomething);

                    method1 += new WithReturnNoPara(this.GetSomething2);
                    method1 += new WithReturnNoPara(this.GetSomething3);

                    int result = method1.Invoke(); //多播委托带返回值,结果以最后的为准
                    Console.WriteLine(result);
                }
            }
            

        }


        private int GetSomething()
        {
            return 1;
        }
        private int GetSomething2()
        {
            return 2;
        }
        private int GetSomething3()
        {
            return 3;
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
