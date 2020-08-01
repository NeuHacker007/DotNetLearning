using System;

namespace EntityframeworkCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeContext = new EmployeeContext("Server=IVAN_ZHANG;Database=DotnetCoreCentralDemo;Integrated Security=true;");
            var provider = new EmployeeProvider(employeeContext);

            var employee = provider.Get(1);

            Console.WriteLine($"{employee.FirstName} - {employee.LastName} - {employee.CellPhone}");


            var repo = new EmployeeRepo(employeeContext);
            // Create
            repo.Create("aa", "bb", "cc", "dd", "ee");
            repo.Create("Eva", "bb", "cc", "dd", "ee");
            repo.Create("KK", "bb", "cc", "dd", "ee");
            // update 

            var employee1 = provider.Get(3);

            employee1.FirstName = "DD";

            repo.Update(employee1);


            repo.Delete(employee1);
            Console.ReadKey();
        }
    }
}
