using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.DataAccess.Models;

namespace EmployeeManagementWeb.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>() {
                new Employee(){ID = 1, EmployeeName="Ivan01", Department=Department.HR, Email="ab@c.com"},
                new Employee(){ID = 2, EmployeeName="Ivan02", Department=Department.HelpDesk, Email="ab@c.com"},
                new Employee(){ID = 3, EmployeeName="Ivan03", Department=Department.IT, Email="ab@c.com"},
            };
        }
        public Employee GetEmployee(int ID)
        {
            return this._employeeList.FirstOrDefault((employee) => employee.ID == ID);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeList;
        }

        public Employee Add(Employee employee)
        {
            employee.ID = _employeeList.Max(e => e.ID) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.ID == employeeChanges.ID);
            if (employee != null)
            {
                employee.EmployeeName = employeeChanges.EmployeeName;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }

            return employee;
        }

        public Employee Delete(int id)
        {
           Employee employee =  _employeeList.FirstOrDefault(e => e.ID == id);
           if (employee != null)
           {
               _employeeList.Remove(employee);
           }

           return employee;
        }
    }
}
