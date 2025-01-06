using Airways.Core.Common;
using Airways.Core.Entity;
using Airways.DataAccess.Identity;
using Airways.Shared.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Airways.DataAccess.Persistence;

public class DataBaseContext : IdentityDbContext<ApplicationUser>
{
    private IClaimService? _claimService;

    public DataBaseContext(DbContextOptions options, IClaimService claimService) : base(options)
    {
        _claimService = claimService;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    
    

    public DbSet<Aicraft> Aicrafts { get; set; }
    public DbSet<Airline> Airlines { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PricePolicy> PricesPolicies { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Reys> Reys { get; set; }
    public DbSet<Tickets> Tickets { get; set; }
    public DbSet<User> AirwaysUser { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        if (_claimService != null)
        {
            foreach (var entry in ChangeTracker.Entries<IAuditedEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _claimService.GetUserId();
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = _claimService.GetUserId();
                        entry.Entity.UpdatedOn = DateTime.Now;
                        break;
                }
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}



