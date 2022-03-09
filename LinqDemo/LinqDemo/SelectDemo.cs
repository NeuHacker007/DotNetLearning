using System;
using System.Linq;

namespace LinqDemo
{
    public class SelectDemo
    {

        public static void Demo1()
        {
            var queryFormat = (from emp in Employee.GetEmployees()
                               select emp).ToList();

            foreach (Employee emp in queryFormat)
            {
                Console.WriteLine($"ID : {emp.ID} Name : {emp.FirstName} {emp.LastName}");
            }

            var methodFormat = Employee.GetEmployees().ToList();
            foreach (Employee emp in methodFormat)
            {
                Console.WriteLine($"ID : {emp.ID} Name : {emp.FirstName} {emp.LastName}");
            }
        }
        public static void Demo2()
        {
            var queryFormat = (from emp in Employee.GetEmployees()
                               select emp.ID).ToList();

            foreach (var id in queryFormat)
            {
                Console.WriteLine($"ID : {id}");
            }


            var methodFormat = Employee
                               .GetEmployees()
                               .Select(emp => emp.ID)
                               .ToList();
            foreach (var id in methodFormat)
            {
                Console.WriteLine($"ID : {id}");
            }

        }
        public static void Demo3()
        {
            var queryFormat = from emp in Employee.GetEmployees()
                              select new Employee
                              {
                                  ID = emp.ID,
                                  FirstName = emp.FirstName,
                                  LastName = emp.LastName,
                                  Salary = emp.Salary
                              };

            foreach (var emp in queryFormat)
            {
                Console.WriteLine($" Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary} ");
            }


            var methodFormat = Employee
                .GetEmployees()
                .Select(emp => new Employee()
                {
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Salary = emp.Salary
                });
            foreach (var emp in methodFormat)
            {
                Console.WriteLine($" Name : {emp.FirstName} {emp.LastName} Salary : {emp.Salary} ");
            }

        }

        public static void Demo4()
        {
            var queryFormat = (from emp in Employee.GetEmployees()
                               select new
                               {
                                   EmployeeId = emp.ID,
                                   FullName = emp.FirstName + " " + emp.LastName,
                                   AnnualSalary = emp.Salary * 12
                               });

            foreach (var emp in queryFormat)
            {
                Console.WriteLine($" ID {emp.EmployeeId} Name : {emp.FullName} Annual Salary : {emp.AnnualSalary} ");
            }
            //Method Syntax
            var methodFormat = Employee.GetEmployees().
                                          Select(emp => new
                                          {
                                              EmployeeId = emp.ID,
                                              FullName = emp.FirstName + " " + emp.LastName,
                                              AnnualSalary = emp.Salary * 12
                                          }).ToList();
            foreach (var emp in methodFormat)
            {
                Console.WriteLine($" ID {emp.EmployeeId} Name : {emp.FullName} Annual Salary : {emp.AnnualSalary} ");
            }
        }

        public static void Demo5()
        {
            var queryFormat = (from emp in Employee
                              .GetEmployees()
                              .Select((value, index) => new { value, index })
                               select new
                               {
                                   IndexPosition = emp.index,
                                   FullName = emp.value.FirstName + " " + emp.value.LastName,
                                   Salary = emp.value.Salary
                               }).ToList();

            foreach (var emp in queryFormat)
            {
                Console.WriteLine($" Position {emp.IndexPosition} Name : {emp.FullName} Salary : {emp.Salary} ");
            }

            var methodFormat = Employee.GetEmployees()
                .Select((emp, index) => new
                {
                    IndexPosition = index,
                    FullName = emp.FirstName + " " + emp.LastName,
                    Salary = emp.Salary
                });
            foreach (var emp in methodFormat)
            {
                Console.WriteLine($" Position {emp.IndexPosition} Name : {emp.FullName} Salary : {emp.Salary} ");
            }


        }
    }
}
