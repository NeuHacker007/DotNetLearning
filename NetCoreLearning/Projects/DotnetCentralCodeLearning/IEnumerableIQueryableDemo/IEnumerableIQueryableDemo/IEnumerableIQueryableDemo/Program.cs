using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerableIQueryableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new EmployeeContext("Server=IVAN_ZHANG;Database=DotnetCoreCentralDemo;Integrated Security=true;");

            IEnumerable<Employee> employees = context.Employees.Where(e => e.Id > 1);

            Console.WriteLine("-----------------------------------------------------------");
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} - {employee.LastName}");
            }
            Console.WriteLine("-----------------------------------------------------------");
            var top1Employee = employees.Take(1);
            foreach (var employee in top1Employee)
            {
                Console.WriteLine($"{employee.FirstName} - {employee.LastName}");
            }
            Console.WriteLine("-----------------------------------------------------------");

            IQueryable<Employee> employeesQuery = context.Employees.Where(e => e.Id > 1);
            foreach (var employee in employeesQuery)
            {
                Console.WriteLine($"{employee.FirstName} - {employee.LastName}");
            }

            Console.WriteLine("-----------------------------------------------------------");
            var top2 = employeesQuery.Take(2);

            foreach (var employee in top2)
            {
                Console.WriteLine($"{employee.FirstName} - {employee.LastName}");
            }

            Console.ReadKey();
        }
    }
}
