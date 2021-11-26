using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SetupApi.Business.Entities;

namespace SetupApi.Infra.Data.Mappings
{
    public class UserMapping :IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("TB_USER");
            builder.HasKey(p => p.Coding);
            builder.Property(p => p.Coding).ValueGeneratedOnAdd();
            builder.Property(p => p.Login);
            builder.Property(p => p.Password);
            builder.Property(p => p.Email);
        }
    }
}
