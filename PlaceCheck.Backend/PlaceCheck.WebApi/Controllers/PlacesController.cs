using Microsoft.AspNetCore.Mvc;
using PlaceCheck.Application.Interfaces;

namespace PlaceCheck.WebApi.Controllers;

[ApiController]
[Route("[action]")]
public class PlacesController : ControllerBase
{
    private readonly IGooglePlacesApiService _api;

    public PlacesController(IGooglePlacesApiService api)
    {
        _api = api;
    }
    
    [HttpPost]
    public async Task<ActionResult> GetPlaces([FromQuery] string query)
    {
        var result = await _api.SearchPlaces(query);
        return Ok(result);
    }
}
