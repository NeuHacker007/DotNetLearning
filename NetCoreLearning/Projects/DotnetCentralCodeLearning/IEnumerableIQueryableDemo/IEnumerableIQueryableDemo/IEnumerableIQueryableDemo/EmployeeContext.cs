using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IEnumerableIQueryableDemo
{
    public class EmployeeContext : DbContext
    {
        private readonly string _connectionString;

        private readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(config => config.AddConsole());

        public EmployeeContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Employee> Employees { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}