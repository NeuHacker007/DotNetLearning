using CustomerMembership.Models;
using System.Data.Entity;

namespace CustomerMembership.Context
{
    public class CustomerDbContext : DbContext
    {

        public CustomerDbContext() : base("name=MemberDbContext")
        {

        }

        public DbSet<tblUser> TblUsers { get; set; }
    }
}