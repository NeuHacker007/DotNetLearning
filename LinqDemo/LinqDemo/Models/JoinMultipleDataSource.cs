using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo.Models
{
    public class JoinMultipleDataSource
    {
        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int AddressId { get; set; }
            public int DepartmentId { get; set; }
            public static List<Employee> GetAllEmployees()
            {
                return new List<Employee>()
            {
                new Employee { ID = 1, Name = "Preety", AddressId = 1, DepartmentId = 10    },
                new Employee { ID = 2, Name = "Priyanka", AddressId = 2, DepartmentId =20   },
                new Employee { ID = 3, Name = "Anurag", AddressId = 3, DepartmentId = 30    },
                new Employee { ID = 4, Name = "Pranaya", AddressId = 4, DepartmentId = 0    },
                new Employee { ID = 5, Name = "Hina", AddressId = 5, DepartmentId = 0       },
                new Employee { ID = 6, Name = "Sambit", AddressId = 6, DepartmentId = 0     },
                new Employee { ID = 7, Name = "Happy", AddressId = 7, DepartmentId = 0      },
                new Employee { ID = 8, Name = "Tarun", AddressId = 8, DepartmentId = 0      },
                new Employee { ID = 9, Name = "Santosh", AddressId = 9, DepartmentId = 10   },
                new Employee { ID = 10, Name = "Raja", AddressId = 10, DepartmentId = 20    },
                new Employee { ID = 11, Name = "Ramesh", AddressId = 11, DepartmentId = 30  }
            };
            }
        }
        public class Address
        {
            public int ID { get; set; }
            public string AddressLine { get; set; }
            public static List<Address> GetAllAddresses()
            {
                return new List<Address>()
            {
                new Address { ID = 1, AddressLine = "AddressLine1"      },
                new Address { ID = 2, AddressLine = "AddressLine2"      },
                new Address { ID = 3, AddressLine = "AddressLine3"      },
                new Address { ID = 4, AddressLine = "AddressLine4"      },
                new Address { ID = 5, AddressLine = "AddressLine5"      },
                new Address { ID = 9, AddressLine = "AddressLine9"      },
                new Address { ID = 10, AddressLine = "AddressLine10"    },
                new Address { ID = 11, AddressLine = "AddressLine11"    },
            };
            }
        }
        public class Department
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public static List<Department> GetAllDepartments()
            {
                return new List<Department>()
                {
                    new Department { ID = 10, Name = "IT"       },
                    new Department { ID = 20, Name = "HR"       },
                    new Department { ID = 30, Name = "Payroll"  },
                };
            }
        }
    }
}
