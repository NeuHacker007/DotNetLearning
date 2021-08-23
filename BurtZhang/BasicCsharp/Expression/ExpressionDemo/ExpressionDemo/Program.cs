using System;

namespace ExpressionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    Console.WriteLine("*************Action + Func");
                    ActionFunc actionFunc = new ActionFunc();
                    actionFunc.Show();
                }

                {
                    Console.WriteLine("********************Expression****************");
                    // 存在于System.Linq.Expression命名空间
                    ExpressionTest.Show();
                }
                {
                    ExpressionVisitorTest.Show();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }

            Console.Read();
        }
    }
}
