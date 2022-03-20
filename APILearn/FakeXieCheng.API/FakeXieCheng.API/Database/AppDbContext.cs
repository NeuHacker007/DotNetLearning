using FakeXieCheng.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeXieCheng.API.Database
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<TouristRoute> TouristRoutes {get; set;}
        public DbSet<TouristRoutePicture> TouristRoutePictures {get;set;}
    }
}
