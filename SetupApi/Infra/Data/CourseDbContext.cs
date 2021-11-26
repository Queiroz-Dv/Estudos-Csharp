using Microsoft.EntityFrameworkCore;
using SetupApi.Business.Entities;
using SetupApi.Infra.Data.Mappings;

namespace SetupApi.Infra.Data
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
    }
}
