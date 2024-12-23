using Airways.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airways.DataAccess.Persistence.Configuration
{
    public class AicraftConfiguration:IEntityTypeConfiguration<Aicraft>
    {
        public void Configure(EntityTypeBuilder<Aicraft> builder)
        {
            builder.Property(ti => ti.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(ti => ti.Description)
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}
