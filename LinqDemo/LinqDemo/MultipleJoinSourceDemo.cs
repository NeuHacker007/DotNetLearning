using LinqDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    public class MultipleJoinSourceDemo
    {
        public static void Demo1()
        {
            var queryFormat = from emp in JoinMultipleDataSource.Employee.GetAllEmployees()
                              join dep in JoinMultipleDataSource.Department.GetAllDepartments()
                              on emp.DepartmentId equals dep.ID
                              join addrs in JoinDataSource.Address.GetAllAddresses()
                              on emp.AddressId equals addrs.ID
                              select new
                              {
                                  ID = emp.ID,
                                  EmployeeName = emp.Name,
                                  DepartmentName = dep.Name,
                                  Address = addrs.AddressLine
                              };


            foreach (var employee in queryFormat)
            {
                Console.WriteLine($"ID = {employee.ID}, Name = {employee.EmployeeName}, Department = {employee.DepartmentName}, Addres = {employee.Address}");
            }
        }


        public static void Demo2()
        {
            var methodFormat = JoinMultipleDataSource.Employee.GetAllEmployees()
                .Join(JoinMultipleDataSource.Department.GetAllDepartments(),
                     (emp) => emp.DepartmentId,
                     (dep) => dep.ID,
                     (emp1, dep1) => new { emp1, dep1 }
                     )
                .Join(JoinMultipleDataSource.Address.GetAllAddresses(),
                      emp2 => emp2.emp1.AddressId,
                      addrs1 => addrs1.ID,
                      (emp2, addrs1) => new
                      {
                          emp2,
                          addrs1
                      })
                .Select(emp => new
                {
                    ID = emp.emp2.emp1.ID,
                    EmployeeName = emp.emp2.emp1.Name,
                    DepartmentName = emp.emp2.dep1.Name,
                    Address = emp.addrs1.AddressLine
                });


            foreach (var employee in methodFormat)
            {
                Console.WriteLine($"ID = {employee.ID}, Name = {employee.EmployeeName}, Department = {employee.DepartmentName}, Addres = {employee.Address}");
            }
        }
    }
}
