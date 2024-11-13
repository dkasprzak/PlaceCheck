using Microsoft.Extensions.DependencyInjection;

namespace PlaceCheck.Application;

public  static class DefaultDIConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services; 
    }
}
