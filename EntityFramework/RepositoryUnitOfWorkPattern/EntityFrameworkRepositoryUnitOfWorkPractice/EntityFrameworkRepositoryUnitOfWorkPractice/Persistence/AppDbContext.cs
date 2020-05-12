
using EntityFrameworkRepositoryUnitOfWorkPractice.Core.Domain;
using EntityFrameworkRepositoryUnitOfWorkPractice.Persistence.EFConfigs;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkRepositoryUnitOfWorkPractice.Persistence
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<CourseTag> CourseTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfig());
        }
    }
}
