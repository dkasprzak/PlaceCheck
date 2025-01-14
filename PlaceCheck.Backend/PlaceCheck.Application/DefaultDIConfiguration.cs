using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PlaceCheck.Application.Interfaces;
using PlaceCheck.Application.Logic.Abstarctions;
using PlaceCheck.Application.Logic.SearchedPlaceFunctions;

namespace PlaceCheck.Application;

public  static class DefaultDIConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IPlaceQueryService, PlaceQueryService>();
        services.AddScoped<ISearchedPlaceService, SearchedPlaceService>();
        return services; 
    }
}
