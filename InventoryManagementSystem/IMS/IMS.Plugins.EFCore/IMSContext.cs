using IMS.CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore
{
    public class IMSContext : DbContext
    {
        public IMSContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding data
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory()
                {
                    Id = 1,
                    Name = "Engine",
                    Price = 1000,
                    Quantity = 1
                },
                new Inventory()
                {
                    Id = 2,
                    Name = "Body",
                    Price = 400,
                    Quantity = 1
                },
                new Inventory()
                {
                    Id = 3,
                    Name = "Wheel",
                    Price = 100,
                    Quantity = 4
                },
                new Inventory()
                {
                    Id = 4,
                    Name = "Seat",
                    Price = 50,
                    Quantity = 5
                }

             );
        }

    }
}
