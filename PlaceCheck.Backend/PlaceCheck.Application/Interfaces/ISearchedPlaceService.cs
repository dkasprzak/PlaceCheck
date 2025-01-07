namespace PlaceCheck.Application.Interfaces;

public interface ISearchedPlaceService
{
    Task<Guid> SaveSearchedPlaceAsync(string phase);
}
