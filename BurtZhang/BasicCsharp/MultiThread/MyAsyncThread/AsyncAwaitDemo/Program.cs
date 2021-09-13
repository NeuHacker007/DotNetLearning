using System;
using AwaitAsyncLibrary;

namespace AsyncAwaitDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("This is the console testing");
                AwaitAsyncClass.TestShow();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Read();
        }
    }
}
