using System;

namespace LinqInternalDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var even = items.NewWhere(x => x % 2 == 0);

            foreach (var num in even)
            {
                Console.WriteLine(num);
            }
        }
    }
}
