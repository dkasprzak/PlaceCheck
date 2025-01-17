using Newtonsoft.Json;

public record PlaceFilter
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool? OutdoorSeating { get; set; }
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool? LiveMusic { get; set; }
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool? MenuForChildren { get; set; }
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool? ServesCocktails { get; set; }
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool? ServesDessert { get; set; }
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool? ServesCoffee { get; set; }
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool? GoodForChildren { get; set; }
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool? AllowsDogs { get; set; }
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool? Restroom { get; set; }
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool? GoodForGroups { get; set; }
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool? GoodForWatchingSports { get; set; }
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool? WheelchairAccessibleParking { get; set; }
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool? WheelchairAccessibleEntrance { get; set; }
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool? WheelchairAccessibleRestroom { get; set; }
    
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool? WheelchairAccessibleSeating { get; set; }
}
