using Microsoft.AspNetCore.Mvc;
using PlaceCheck.Application.Interfaces;
using PlaceCheck.Application.Logic.SearchedPlaceFunctions.Queries;

namespace PlaceCheck.WebApi.Controllers;

[ApiController]
[Route("[action]")]
public class PlacesController : ControllerBase
{
    private readonly IPlaceQueryService _placeQueryService;

    public PlacesController(IPlaceQueryService placeQueryService)
    {
        _placeQueryService = placeQueryService;
    }
    
    [HttpPost]
    public async Task<ActionResult> GetPlaces([FromBody] SearchQuery query)
    {
        var result = await _placeQueryService.SearchPlaces(query);
        return Ok(result);
    }
}
