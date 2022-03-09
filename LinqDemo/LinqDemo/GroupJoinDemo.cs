using LinqDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    public class GroupJoinDemo
    {
        public static void Demo1()
        {
            var methodFormat = GroupDataSource.Department.GetAllDepartments()
                .GroupJoin(GroupDataSource.Employee.GetAllEmployees(),
                           dep => dep.ID,
                           emp => emp.DepartmentId,
                           (dept, emp) => new { dept, emp });


            foreach (var item in methodFormat)
            {
                Console.WriteLine("Department :" + item.dept.Name);
                //Inner Foreach loop for each employee of a department
                foreach (var employee in item.emp)
                {
                    Console.WriteLine("  EmployeeID : " + employee.ID + " , Name : " + employee.Name);
                }
            }
        }

        public static void Demo2()
        {
            var methodFormat = GroupDataSource.Employee.GetAllEmployees()
                .GroupJoin(
                 GroupDataSource.Department.GetAllDepartments(),
                 emp => emp.DepartmentId,
                 dep => dep.ID,
                 (emp, dep) => new {emp, dep});


            foreach (var item in methodFormat)
            {
                Console.WriteLine($"Employee Name : { item.emp.Name}");
                foreach (var dep in item.dep)
                {
                    Console.WriteLine($"dep id {dep.ID}, dep name: {dep.Name}");
                }
            }
        }


        public static void Demo3()
        {
            var queryFormat = from dep in GroupDataSource.Department.GetAllDepartments()
                              join emp in GroupDataSource.Employee.GetAllEmployees()
                              on dep.ID equals emp.DepartmentId into empGroups
                              select new { dep, empGroups };
            foreach(var item in queryFormat)
            {
                Console.WriteLine("Department :" + item.dep.Name);
                //Inner Foreach loop for each employee of a department
                foreach(var employee in item.empGroups)
                {
                    Console.WriteLine("  EmployeeID : " + employee.ID + " , Name : " + employee.Name);
                }
            }
        }
    }
}
