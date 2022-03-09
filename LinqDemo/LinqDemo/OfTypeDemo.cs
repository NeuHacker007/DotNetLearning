using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo
{
    public class OfTypeDemo
    {
        public static void Demo1()
        {
            List<object> dataSource = new List<object>()
            {
                "Tom", "Mary", 50, "Prince", "Jack", 10, 20, 30, 40, "James"
            };

            var intsMethodFormat = dataSource.OfType<int>().ToList();
            var intsQueryFormat = (from item in dataSource
                                   where item is int
                                   select item).ToList();
            var strs = dataSource.OfType<string>().ToList();
            var strsQueryFormat = (from item in dataSource
                                   where item is string
                                   select item).ToList();

            foreach (var item in intsMethodFormat)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("*************************************");
            foreach (var item in strs)
            {
                Console.WriteLine(item);
            }

        }


    }
}
