using System;
using MyDelegateEvent.DelegateExtend;
using MyDelegateEvent.Event;

namespace MyDelegateEvent
{
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
