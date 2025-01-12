using PlaceCheck.Application.Logic.SearchedPlaceFunctions.Common;

namespace PlaceCheck.Application.Logic.SearchedPlaceFunctions.Queries;

public record SearchQuery
{
    public string SearchPhase { get; set; }
    public PlaceFilter PlaceFilters { get; set; }
    public string City { get; set; }
}
