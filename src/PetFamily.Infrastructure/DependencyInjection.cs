using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetFamily.Application.Abstraction.Persistense;
using PetFamily.Infrastructure.Contexts;
using PetFamily.Infrastructure.SlqConnectionFactories;

namespace PetFamily.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this 
        IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddPersistance(configuration);

        return services;
    }

    private static IServiceCollection AddPersistance(this
        IServiceCollection services, 
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database") ??
            throw new ApplicationException("connection string is empty");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IUnitOfWork>(serviceProvider => 
            serviceProvider.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => 
            new SqlConnectionFactory(connectionString));

        return services;
    }
}
