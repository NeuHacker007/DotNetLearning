using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthCheckDemo
{
    public static class DbHealthCheckProvider
    {
        public static HealthCheckResult Check(string connectionString)
        {
            // code to check if db is running 
            return HealthCheckResult.Healthy();
        }
    }
}
