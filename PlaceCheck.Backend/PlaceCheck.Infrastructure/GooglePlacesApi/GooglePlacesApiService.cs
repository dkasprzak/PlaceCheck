using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PlaceCheck.Application.Interfaces;

namespace PlaceCheck.Infrastructure.GooglePlacesApi;

public class GooglePlacesApiService : IGooglePlacesApiService
{
    private readonly HttpClient _httpClient;
    private readonly GooglePlacesApiOptions _apiOptions;
    
    public GooglePlacesApiService(HttpClient httpClient, IOptions<GooglePlacesApiOptions> apiOptions)
    {
        _httpClient = httpClient;
        _apiOptions = apiOptions.Value;
    }
}
