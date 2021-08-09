using System;
using MyDelegateEvent.DelegateExtend;

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

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Read();
        }
    }
}
