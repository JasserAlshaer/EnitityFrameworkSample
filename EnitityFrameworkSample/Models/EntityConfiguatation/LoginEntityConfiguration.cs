using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnitityFrameworkSample.Models.EntityConfiguatation
{
    public class LoginEntityConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.Paitent).WithOne(x => x.Login)
                .HasForeignKey("Login", "PaitentId");
        }
    }
}
