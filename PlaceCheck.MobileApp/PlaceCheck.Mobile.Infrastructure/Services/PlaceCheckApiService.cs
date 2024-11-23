using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PlaceCheck.Mobile.Application.Interfaces;
using PlaceCheck.Mobile.Application.ViewModels;
using PlaceCheck.Mobile.Infrastructure.PlaceCheckApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PlaceCheck.Mobile.Infrastructure.Services
{
    public class PlaceCheckApiService : IPlaceCheckApiService
    {
        private readonly HttpClient _httpClient;
        private readonly PlaceCheckApiOptions _apiOptions;

        public PlaceCheckApiService(HttpClient httpClient, IOptions<PlaceCheckApiOptions> apiOptions)
        {
            _httpClient = httpClient;
            _apiOptions = apiOptions.Value;
        }

        public async Task<IEnumerable<PlaceListViewModel>> GetPlaces(string query)
        {
            var endpoint = $"{_apiOptions.BaseUrl}/GetPlaces?query={query}";

            var request = await _httpClient.PostAsJsonAsync(endpoint, query);

            var content = await request.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<PlaceListViewModel>>(content);

            return result;
        }
    }
}
