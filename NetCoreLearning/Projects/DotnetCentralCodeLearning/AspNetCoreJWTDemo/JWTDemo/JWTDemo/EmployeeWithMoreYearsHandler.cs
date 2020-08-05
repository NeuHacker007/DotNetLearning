using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace JWTDemo
{
    public class EmployeeWithMoreYearsHandler : AuthorizationHandler<EmployeeWithMoreYearsRequirement>
    {
        private readonly IEmployeeNumberOfYears _employeeNumberOfYears;

        public EmployeeWithMoreYearsHandler(IEmployeeNumberOfYears employeeNumberOfYears)
        {
            _employeeNumberOfYears = employeeNumberOfYears;
        }
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            EmployeeWithMoreYearsRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                return Task.CompletedTask;
            }

            var name = context.User.FindFirst(c => c.Type == ClaimTypes.Name);

            var yearsofExperience = _employeeNumberOfYears.Get(name.Value);

            if (yearsofExperience >= requirement.Years)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
