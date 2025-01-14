using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PlaceCheck.Application.DTO;
using PlaceCheck.Application.Exceptions;
using PlaceCheck.Application.Interfaces;
using PlaceCheck.Infrastructure.GooglePlacesApi.Helpers;

namespace PlaceCheck.Infrastructure.GooglePlacesApi.Services;

public class GooglePlacesApiService : IGooglePlacesApiService
{
    private readonly HttpClient _httpClient;
    private readonly GooglePlacesApiOptions _apiOptions;
    
    public GooglePlacesApiService(HttpClient httpClient, IOptions<GooglePlacesApiOptions> apiOptions)
    {
        _httpClient = httpClient;
        _apiOptions = apiOptions.Value;
    }


    public async Task<IEnumerable<PlaceResponse>> SearchPlaces(string query)
    {
        var endpoint = $"{_apiOptions.BaseUrl}/places:searchText";
        var request = await _httpClient.PostAsJsonAsync(endpoint, new SearchText(query));

        if (!request.IsSuccessStatusCode)
        {
            var error = await request.Content.ReadAsStringAsync();
            var formattedError = JsonFormatter.FormatJson(error);
            throw new ApiException(request.StatusCode, error);
        }
        
        var content = await request.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<PlaceResult>(content);
        
        return result.Places;
    }

    record SearchText(string textQuery);
}
