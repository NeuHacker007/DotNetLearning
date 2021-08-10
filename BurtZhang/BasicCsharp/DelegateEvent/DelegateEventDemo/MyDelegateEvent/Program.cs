using System;
using MyDelegateEvent.DelegateExtend;
using MyDelegateEvent.Event;

namespace MyDelegateEvent
{
    /// <summary>
    /// 事件: 可以把一堆可变的动作/行为封装出去, 交给第三方来指定
    ///      预定义一样， 程序设计的时候, 我们可以把程序分成两个部分
    ///      一部分是固定的, 直接写死
    /// 框架: 完成固定/通用部分, 把可变部分留出扩展点, 支持自定义
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("********************Delegate + Event***********************");

                {
                    MyDelegate myDelegate = new MyDelegate();

                    myDelegate.Show();
                }
                {
                    ListExtend test = new ListExtend();
                    test.Show();
                }

                {
                    Console.WriteLine("*************************Event********************");
                    {
                        Cat cat = new Cat();
                        cat.Miao();
                    }
                    {
                        Cat cat = new Cat();

                        cat.miaoDelegateHandler += new MiaoDelegate(new Mouse().Run);
                        cat.miaoDelegateHandler += new MiaoDelegate(new Baby().Cry);
                        cat.miaoDelegateHandler += new MiaoDelegate(new Mother().Wispher);
                        cat.miaoDelegateHandler += new MiaoDelegate(new Father().Roar);
                        cat.miaoDelegateHandler += new MiaoDelegate(new Neighbor().Awake);
                        cat.miaoDelegateHandler += new MiaoDelegate(new Stealer().Hide);
                        {
                            cat.miaoDelegateHandler.Invoke();
                            cat.miaoDelegateHandler = null;
                        }
                        cat.MiaoNew();

                    }

                    {
                        Cat cat = new Cat();

                        cat.miaoDelegateEvent += new MiaoDelegate(new Mouse().Run);
                        cat.miaoDelegateEvent += new MiaoDelegate(new Baby().Cry);
                        cat.miaoDelegateEvent += new MiaoDelegate(new Mother().Wispher);
                        cat.miaoDelegateEvent += new MiaoDelegate(new Father().Roar);
                        cat.miaoDelegateEvent += new MiaoDelegate(new Neighbor().Awake);
                        cat.miaoDelegateEvent += new MiaoDelegate(new Stealer().Hide);

                        {
                            // event 关键字不允许外部直接调用或者赋值
                            // 做了限制

                            //cat.miaoDelegateEvent.Invoke();
                            //cat.miaoDelegateEvent = null;
                        }
                       
                        cat.MiaoNew();

                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Read();
        }
    }
}
