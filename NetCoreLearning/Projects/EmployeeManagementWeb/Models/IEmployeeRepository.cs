using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementWeb.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int ID);
        IEnumerable<Employee> GetEmployees();
    }
}
