using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementWeb.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public Departments Department { get; set; }

    }
}
