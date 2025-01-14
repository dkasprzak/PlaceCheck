using PlaceCheck.Application.DTO;
using PlaceCheck.Application.Exceptions;
using PlaceCheck.Application.Interfaces;
using PlaceCheck.Application.Logic.SearchedPlaceFunctions.Queries;
using PlaceCheck.Application.Helpers;

namespace PlaceCheck.Application.Logic.SearchedPlaceFunctions;

public class PlaceQueryService : IPlaceQueryService
{
   private readonly IGooglePlacesApiService _googlePlacesApiService;
   private readonly ISearchedPlaceService _searchedPlaceService;

   public PlaceQueryService(IGooglePlacesApiService googlePlacesApiService, ISearchedPlaceService searchedPlaceService)
   {
       _googlePlacesApiService = googlePlacesApiService;
       _searchedPlaceService = searchedPlaceService;
   }
   
   public async Task<IEnumerable<PlaceResponse>> SearchPlaces(SearchQuery query)
   {
       var searchPhase = $"{query.SearchPhase} {query.City}";
       var placesQuery = await _googlePlacesApiService.SearchPlaces(searchPhase);

       if (placesQuery is null)
       {
           throw new NotFoundException("PlacesNotFound");
       }
       
       var filters = query.PlaceFilters;
       if (filters is null)
       {
           return placesQuery;
       }

       await _searchedPlaceService.SaveSearchedPlaceAsync(query.SearchPhase, query.City);
       
       return placesQuery
           .WhereIf(filters.OutdoorSeating.HasValue, x => x.OutdoorSeating == filters.OutdoorSeating!.Value)
           .WhereIf(filters.LiveMusic.HasValue, x => x.LiveMusic == filters.LiveMusic!.Value)
           .WhereIf(filters.MenuForChildren.HasValue, x => x.MenuForChildren == filters.MenuForChildren!.Value)
           .WhereIf(filters.ServesCocktails.HasValue, x => x.ServesCocktails == filters.ServesCocktails!.Value)
           .WhereIf(filters.ServesDessert.HasValue, x => x.ServesDessert == filters.ServesDessert!.Value)
           .WhereIf(filters.ServesCoffee.HasValue, x => x.ServesCoffee == filters.ServesCoffee!.Value)
           .WhereIf(filters.GoodForChildren.HasValue, x => x.GoodForChildren == filters.GoodForChildren!.Value)
           .WhereIf(filters.AllowsDogs.HasValue, x => x.AllowsDogs == filters.AllowsDogs!.Value)
           .WhereIf(filters.Restroom.HasValue, x => x.Restroom == filters.Restroom!.Value)
           .WhereIf(filters.GoodForGroups.HasValue, x => x.GoodForGroups == filters.GoodForGroups!.Value)
           .WhereIf(filters.GoodForWatchingSports.HasValue, x => x.GoodForWatchingSports == filters.GoodForWatchingSports!.Value)
           .WhereIf(filters.WheelchairAccessibleParking.HasValue, x => x.WheelchairAccessibleParking == filters.WheelchairAccessibleParking!.Value)
           .WhereIf(filters.WheelchairAccessibleEntrance.HasValue, x => x.WheelchairAccessibleEntrance == filters.WheelchairAccessibleEntrance!.Value)
           .WhereIf(filters.WheelchairAccessibleRestroom.HasValue, x => x.WheelchairAccessibleRestroom == filters.WheelchairAccessibleRestroom!.Value)
           .WhereIf(filters.WheelchairAccessibleSeating.HasValue, x => x.WheelchairAccessibleSeating == filters.WheelchairAccessibleSeating!.Value);
   }
}