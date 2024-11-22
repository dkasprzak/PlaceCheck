using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PlaceCheck.Infrastructure.GooglePlacesApi;
using Shouldly;

namespace PlaceCheck.Tests.Integration.Infrastructure;

public class GooglePlacesApiServiceTests
{
    private readonly HttpClient _httpClient;
    private readonly IOptions<GooglePlacesApiOptions> _options;
    
    public GooglePlacesApiServiceTests()
    {
        var basePath = AppContext.BaseDirectory;
        var projectDirectory = Path.GetFullPath(Path.Combine(basePath, "../../../../"));
        
        var configuration = new ConfigurationBuilder()
            .SetBasePath(projectDirectory) 
            .AddJsonFile("test.appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var googlePlacesApiOptions = configuration.GetSection("ApiClients:GooglePlacesApi").Get<GooglePlacesApiOptions>();
        _options = Options.Create(googlePlacesApiOptions);
        
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(_options.Value.BaseUrl)
        };
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("X-Goog-Api-Key", _options.Value.ApiKey);
        _httpClient.DefaultRequestHeaders.Add("X-Goog-FieldMask", "*");
    }

    [Theory]
    [InlineData("Kawiarnia Kraków")]
    public async Task Send_Search_Place_Request_Should_Return_Success(string query)
    {
        //Arrange
        var endpoint = $"{_options.Value.BaseUrl}/places:searchText";
        
        //Act
        var response = await _httpClient.PostAsJsonAsync(endpoint, new SearchText(query));
        
        //Assert
        response.IsSuccessStatusCode.ShouldBeTrue();
        var content = await response.Content.ReadAsStringAsync();
        content.ShouldNotBeNullOrEmpty();
    }
    
    private record SearchText(string textQuery);
}
