using Microsoft.EntityFrameworkCore;
using PetFamily.Infrastructure.Contexts;

namespace PetFamily.Api.Extensions;

internal static class ApplicationBuilderExtension
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        dbContext.Database.Migrate();
    }
}
