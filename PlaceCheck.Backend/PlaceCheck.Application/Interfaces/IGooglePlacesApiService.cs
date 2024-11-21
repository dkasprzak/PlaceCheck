using PlaceCheck.Application.DTO;

namespace PlaceCheck.Application.Interfaces;

public interface IGooglePlacesApiService
{
    Task<IEnumerable<PlaceResponse>> SearchPlaces(string query);
}
