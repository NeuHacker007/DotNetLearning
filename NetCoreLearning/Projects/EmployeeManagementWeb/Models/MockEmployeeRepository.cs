using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementWeb.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>() {
                new Employee(){ID = 1, EmployeeName="Ivan01", Department="AOS", Email="ab@c.com"},
                new Employee(){ID = 2, EmployeeName="Ivan02", Department="SOA", Email="ab@c.com"},
                new Employee(){ID = 3, EmployeeName="Ivan03", Department="OSA", Email="ab@c.com"},
            };
        }
        public Employee GetEmployee(int ID)
        {
            return this._employeeList.FirstOrDefault((employee) => employee.ID == ID);
        }
    }
}
