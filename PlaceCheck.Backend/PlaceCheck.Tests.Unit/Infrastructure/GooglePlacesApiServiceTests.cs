using System.Net;
using Microsoft.Extensions.Options;
using NSubstitute;
using PlaceCheck.Application.Logic.SearchedPlaceFunctions;
using PlaceCheck.Infrastructure.GooglePlacesApi;
using PlaceCheck.Infrastructure.GooglePlacesApi.Services;

namespace PlaceCheck.Tests.Unit.Infrastructure;

public class GooglePlacesApiServiceTests
{
    private readonly HttpClient _httpClient;
    private readonly GooglePlacesApiService _service;
    private readonly IOptions<GooglePlacesApiOptions> _apiOptions;

    public GooglePlacesApiServiceTests()
    {
        // test API options
        _apiOptions = Options.Create(new GooglePlacesApiOptions
        {
            BaseUrl = "https://places.googleapis.com/v1/place",
            ApiKey = "test-api-key"
        });

        // mock for HttpMessageHandler
        var httpMessageHandler = Substitute.ForPartsOf<HttpMessageHandler>();

        // use HttpClient with mock HttpMessageHandler
        _httpClient = new HttpClient(httpMessageHandler)
        {
            BaseAddress = new Uri(_apiOptions.Value.BaseUrl)
        };

        // initialize service
        _service = new GooglePlacesApiService(_httpClient, _apiOptions);
    }
    
}
