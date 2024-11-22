using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlaceCheck.Application.Interfaces;
using PlaceCheck.Infrastructure.GooglePlacesApi.Services;

namespace PlaceCheck.Infrastructure.GooglePlacesApi;

public static class GooglePlacesApiConfiguration
{
    public static IServiceCollection AddGooglePlacesApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<GooglePlacesApiOptions>(configuration.GetSection("ApiClients:GooglePlacesApi"));
        services.AddHttpClient<IGooglePlacesApiService, GooglePlacesApiService>(client =>
        {
            var options = configuration.GetSection("ApiClients:GooglePlacesApi").Get<GooglePlacesApiOptions>();
            client.BaseAddress = new Uri(options.BaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-Goog-Api-Key", options.ApiKey);
            client.DefaultRequestHeaders.Add("X-Goog-FieldMask", "*");
        });
        
        return services;
    }
}
