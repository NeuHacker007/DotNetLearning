using LinqDemo.Models;
using System;
using System.Linq;

namespace LinqDemo
{
    public class InnerJoinDemo
    {
        public static void Demo1()
        {
            var methodFormat = JoinDataSource.Employee.GetAllEmployees()
                .Join(
                JoinDataSource.Address.GetAllAddresses(),
                emp => emp.AddressId,
                addrs => addrs.ID,
                (emp, address) => new
                {
                    EmployeeID = emp.ID,
                    EmployeeName = emp.Name,
                    EmployeeAddressId = emp.AddressId,
                    AddressId = address.ID,
                    Address = address.AddressLine,
                }
                );
            var queryFormat = from emp in JoinDataSource.Employee.GetAllEmployees()
                              join address in JoinDataSource.Address.GetAllAddresses()
                              on emp.AddressId equals address.ID
                              select new
                              {
                                  EmployeeID = emp.ID,
                                  EmployeeName = emp.Name,
                                  EmployeeAddressId = emp.AddressId,
                                  AddressId = address.ID,
                                  Address = address.AddressLine,
                              };

            foreach (var employee in methodFormat)
            {
                Console.WriteLine($"Name :{employee.EmployeeName}, Address : {employee.Address}");
            }
        }
    }
}
