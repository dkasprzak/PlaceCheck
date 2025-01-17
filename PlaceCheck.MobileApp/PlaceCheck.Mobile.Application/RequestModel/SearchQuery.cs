public class SearchQuery
{
    public SearchQuery()
    {
        SearchPhase = string.Empty;
        City = string.Empty;
        PlaceFilters = new PlaceFilter();
    }

    public string SearchPhase { get; set; }
    public string City { get; set; }
    public PlaceFilter PlaceFilters { get; set; }
}
