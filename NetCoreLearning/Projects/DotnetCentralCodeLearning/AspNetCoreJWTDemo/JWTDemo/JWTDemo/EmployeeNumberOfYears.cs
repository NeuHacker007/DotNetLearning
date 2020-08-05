using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTDemo
{
    public class EmployeeNumberOfYears : IEmployeeNumberOfYears
    {
        public int Get(string employeeName)
        {
            if (employeeName == "test2")
            {
                return 21;
            }

            return 10;
        }
    }
}
