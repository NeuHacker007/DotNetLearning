using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EntityframeworkCoreDemo
{
    public class EmployeeContext : DbContext
    {
        private readonly string _connectionString;

        public EmployeeContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
