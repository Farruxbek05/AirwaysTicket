using Airways.Core.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Airways.DataAccess.Persistence.Configuration;

public class AirlineConfiguration : IEntityTypeConfiguration<Airline>
{
    public void Configure(EntityTypeBuilder<Airline> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(ti => ti.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasMany(ti => ti.aicrafts)
            .WithOne(x => x.Airline)
            .HasForeignKey(x => x.AirlineId)
            .OnDelete(DeleteBehavior.Restrict); // Bu bog'lanishni to'g'ri ko'rsatadi
    }

}
