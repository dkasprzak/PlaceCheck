using PlaceCheck.Application.Interfaces;
using PlaceCheck.Application.Logic.Abstarctions;
using PlaceCheck.Domain.Entities;

namespace PlaceCheck.Application.Logic.SearchedPlaceFunctions;

public class SearchedPlaceService : BaseService, ISearchedPlaceService
{
    public SearchedPlaceService(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
    }

    public async Task<Guid> SaveSearchedPlaceAsync(string phase)
    {
        var utcNow = DateTime.UtcNow;

        var searchedPlace = new SearchedPlace
        {
            Id = Guid.NewGuid(),
            SearchPhase = phase,
            InsertedOn = utcNow
        };
        
        _applicationDbContext.SearchedPlaces.Add(searchedPlace);
        await _applicationDbContext.SaveChangesAsync();
        
        return searchedPlace.Id;
    }
}
