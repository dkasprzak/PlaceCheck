using Microsoft.Extensions.DependencyInjection;
using PlaceCheck.Application.Interfaces;
using PlaceCheck.Application.Logic.SearchedPlaceFunctions;

namespace PlaceCheck.Application;

public  static class DefaultDIConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ISearchedPlaceService, SearchedPlaceService>();
        return services; 
    }
}
