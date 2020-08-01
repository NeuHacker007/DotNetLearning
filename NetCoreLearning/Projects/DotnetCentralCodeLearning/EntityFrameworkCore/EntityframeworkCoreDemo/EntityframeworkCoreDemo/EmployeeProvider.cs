using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityframeworkCoreDemo
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeProvider(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public Employee Get(int id)
        {
            return _employeeContext.Employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
