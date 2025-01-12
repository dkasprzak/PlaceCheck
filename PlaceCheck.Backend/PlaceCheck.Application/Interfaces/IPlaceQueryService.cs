using PlaceCheck.Application.DTO;
using PlaceCheck.Application.Logic.SearchedPlaceFunctions.Queries;

namespace PlaceCheck.Application.Interfaces;

public interface IPlaceQueryService
{
    Task<IEnumerable<PlaceResponse>> SearchPlaces(SearchQuery query);
}
