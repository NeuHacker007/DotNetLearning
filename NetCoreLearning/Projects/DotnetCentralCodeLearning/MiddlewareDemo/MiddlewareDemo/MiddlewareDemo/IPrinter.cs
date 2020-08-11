using System;

namespace MiddlewareDemo
{
    public interface IPrinter
    {
        void Print();
    }

    public class Printer : IPrinter
    {
        public void Print()
        {
            Console.WriteLine($"Printing");
        }
    }
}