using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SetupApi.Business.Entities;

namespace SetupApi.Infra.Data.Mappings
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("TB_COURSE");
            builder.HasKey(p => p.Coding);
            builder.Property(p => p.Coding).ValueGeneratedOnAdd();
            builder.Property(p => p.Name);
            builder.Property(p => p.Description);
            builder.HasOne(p => p.User)
                .WithMany().HasForeignKey(fk => fk.UserCoding);
        }
    }
}
