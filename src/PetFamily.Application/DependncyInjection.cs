using Microsoft.Extensions.DependencyInjection;
using PetFamily.Application.AssemblyMarkers;

namespace PetFamily.Application;

public static class DependncyInjection
{
    public static IServiceCollection AddApplication(this 
        IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblies(typeof(IApplicationAssemblyMarker).Assembly);
        });

        return services;
    }
}
