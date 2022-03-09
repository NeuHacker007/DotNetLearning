using LinqDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo
{
    public class AggregateDemo
    {
        public static void Demo1()
        {
            string[] skills = { "C#.NET", "MVC", "WCF", "SQL", "LINQ", "ASP.NET" };

            var str = skills.Aggregate((a, b) => a + ',' + b);

            Console.WriteLine(str);
        }

        public static void Demo2()
        {
            /*
             How does it work?
             Step1: First it multiplies (2*3) to produce the result as 6
             Step2: Result of Step 1 i.e. 6 is then multiplied with 5 to produce the result as 30
             Step3: Result of Step 2 i.e. 30 is then multiplied with 7 to produce the result as 210.
             Step4: Result of Step 3 i.e. 210 is then multiplied with 9 to produce the final result as 1890.
             
             */
            int[] intNumbers = { 3, 5, 7, 9 };

            var product = intNumbers.Aggregate(2, (a, b) => a * b);

            Console.WriteLine(product);

        }

        public static void Demo3()
        {
            string employeeNames = Employee.GetEmployees().Aggregate("Employee Names: ", (empName, emp) => empName += emp.FirstName + ",");
            Console.WriteLine(employeeNames);
            Console.WriteLine("*******************************************");
            Console.WriteLine(employeeNames.Remove(employeeNames.LastIndexOf(",")));
        }

        public static void Demo4()
        {
            string employeeNames = Employee.GetEmployees()
                .Aggregate("Employee Names: ",
                           (empNames, emp) => empNames += emp.FirstName + ",",
                           empNames => empNames.Substring(0, empNames.Length - 1)
                           );
            Console.WriteLine(employeeNames);
        }

        public static void Demo5()
        {
            string stdsNames = DupStudent.GetStudents()
                .Select(std => std.Name)
                .Distinct()
                .Aggregate("Student Names: ",
                           (stdNames, name) => stdNames += name + ",",
                           stdNames => stdNames.Substring(0, stdNames.Length - 1)
                           );
            Console.WriteLine(stdsNames);
        }

        public static void Demo6()
        {
            string stdsNames = DupStudent.GetStudents()
                .SelectMany(std => new List<Tuple<int, string>>() { Tuple.Create(std.ID, std.Name) })
                .Distinct()
                .Aggregate("Student ID and Names: \n",
                           (stdNames, IdNamePair) => stdNames += IdNamePair.Item1 + " => " + IdNamePair.Item2 + "\n"
                           );
            Console.WriteLine(stdsNames);
        }
    }
}
