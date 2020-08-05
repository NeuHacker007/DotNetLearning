using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace JWTDemo
{
    public class EmployeeWithMoreYearsRequirement : IAuthorizationRequirement
    {
        public int Years { get; }

        public EmployeeWithMoreYearsRequirement(int years)
        {
            Years = years;
        }
    }
}
