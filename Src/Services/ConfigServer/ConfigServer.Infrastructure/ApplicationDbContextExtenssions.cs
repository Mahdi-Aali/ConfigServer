using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigServer.Infrastructure;

public static class ApplicationDbContextExtenssions
{
    public static async Task SeedDataAsync(this IServiceProvider serviceProvider)
    {
        var services = serviceProvider.CreateAsyncScope().ServiceProvider;
        var context = services.GetRequiredService<ApplicationDbContext>();
        using (context)
        {
            if ((await context.Database.GetPendingMigrationsAsync()).Any())
            {
                await context.Database.MigrateAsync();
            }
        }
    }
}
