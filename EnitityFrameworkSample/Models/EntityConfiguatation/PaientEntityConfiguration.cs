using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnitityFrameworkSample.Models.EntityConfiguatation
{
    public class PaientEntityConfiguration : IEntityTypeConfiguration<Paitent>
    {
        public void Configure(EntityTypeBuilder<Paitent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Id).UseIdentityColumn();
        }
    }
}
