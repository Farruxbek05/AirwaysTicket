using Airways.DataAccess.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Airways.DataAccess.Persistence
{
    public class AutomatedMigration
    {

        public static async Task MigrateAsync(IServiceProvider services)
        {
            var context = services.GetRequiredService<DataBaseContext>();

            if (context.Database.IsNpgsql()) await context.Database.MigrateAsync();

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            await DatabaseContextSeed.SeedDatabaseAsync(context, userManager);
        }
    }
}
