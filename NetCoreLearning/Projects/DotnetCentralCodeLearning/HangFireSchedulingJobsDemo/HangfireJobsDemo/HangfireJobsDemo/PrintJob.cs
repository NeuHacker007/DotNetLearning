using System;

namespace HangfireJobsDemo
{
    public class PrintJob : IPrintJob
    {
        public void Print()
        {
            Console.WriteLine("Printing from printer method");
        }
    }
}