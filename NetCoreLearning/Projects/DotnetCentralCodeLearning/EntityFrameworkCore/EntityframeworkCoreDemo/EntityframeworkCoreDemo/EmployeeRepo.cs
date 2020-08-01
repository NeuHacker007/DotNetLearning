using System;
using System.Collections.Generic;
using System.Text;

namespace EntityframeworkCoreDemo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeRepo(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public Employee Create(
            string firstname,
            string lastname,
            string address,
            string homephone,
            string cellphone)
        {
            var response = _employeeContext.Add(new Employee()
            {
                FirstName = firstname,
                LastName = lastname,
                Address = address,
                HomePhone = homephone,
                CellPhone = cellphone
            });

            _employeeContext.SaveChanges();

            return response.Entity;
        }

        public Employee Update(Employee employee)
        {
            var response = _employeeContext.Update(employee);
            _employeeContext.SaveChanges();
            return response.Entity;
        }

        public void Delete(Employee employee)
        {
            _employeeContext.Remove(employee);
            _employeeContext.SaveChanges();
        }
    }
}
