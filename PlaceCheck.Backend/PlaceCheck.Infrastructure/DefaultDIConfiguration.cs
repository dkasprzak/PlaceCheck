using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlaceCheck.Infrastructure.GooglePlacesApi;


namespace PlaceCheck.Infrastructure;

public static class DefaultDIConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddGooglePlacesApi(configuration);
        return services;
    }
}
