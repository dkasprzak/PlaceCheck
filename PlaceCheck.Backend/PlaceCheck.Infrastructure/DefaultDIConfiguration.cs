using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlaceCheck.Infrastructure.GooglePlacesApi;
using PlaceCheck.Infrastructure.Persistence.Configurations;


namespace PlaceCheck.Infrastructure;

public static class DefaultDIConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSqlDatabase(configuration.GetConnectionString("MainDbSql")!);
        services.AddGooglePlacesApi(configuration);
        return services;
    }
}
