namespace PlaceCheck.Application.Logic.SearchedPlaceFunctions.Common;

public record PlaceFilter
{
    public bool? OutdoorSeating { get; set; }
    public bool? LiveMusic { get; set; }
    public bool? MenuForChildren { get; set; } 
    public bool? ServesCocktails { get; set; }
    public bool? ServesDessert { get; set; }
    public bool? ServesCoffee { get; set; }
    public bool? GoodForChildren { get; set; }
    public bool? AllowsDogs { get; set; }
    public bool? Restroom { get; set; }
    public bool? GoodForGroups { get; set; }
    public bool? GoodForWatchingSports { get; set; }
    public bool? WheelchairAccessibleParking { get; set; }
    public bool? WheelchairAccessibleEntrance { get; set; }
    public bool? WheelchairAccessibleRestroom { get; set; }
    public bool? WheelchairAccessibleSeating { get; set; }
}
