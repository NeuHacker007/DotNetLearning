using System;
using System.Collections.Generic;
using System.Text;

namespace PrintAll
{
    public class CustomerPrint
    {
        private string _name;

        public string Name => _name;

        public static string StaticName => "Static Name";

        public void Print()
        {
            Console.WriteLine("print from public print class");
        }

        public string GetName()
        {
            return _name;
        }

        public void PrintName()
        {
            Console.WriteLine($"Name set as {_name}");
        }

        public void Print(string name)
        {
            Console.WriteLine($"Name passed: {name}");
        }

        private void PrintPrivate()
        {
            Console.WriteLine($"printing from private");
        }


    }
}
