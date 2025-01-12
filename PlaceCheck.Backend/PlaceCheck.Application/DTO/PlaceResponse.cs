namespace PlaceCheck.Application.DTO;

public record PlaceResponse
{
    public string Id { get; set; }
    public DisplyName DisplayName { get; set; }
    public double Rating { get; set; }
    // Miejsce oferuje miejsca do siedzenia na świeżym powietrzu.
    public bool OutdoorSeating { get; set; }   
    // Miejsce oferuje muzykę na żywo.
    public bool LiveMusic { get; set; }
    // Miejsce ma menu dla dzieci.
    public bool MenuForChildren { get; set; }
    // Miejsce serwuje koktajle.
    public bool ServesCocktails { get; set; }
    // Miejsce serwuje desery.
    public bool ServesDessert { get; set; }
    // Miejsce serwuje kawę.
    public bool ServesCoffee { get; set; }
    // Miejsce jest dobre dla dzieci.
    public bool GoodForChildren { get; set; }
    // Miejsce, w którym można wejść z psem.
    public bool AllowsDogs { get; set; }
    // Miejsce ma toaletę.
    public bool Restroom { get; set; }
    // Miejsce dostosowane do grup.
    public bool GoodForGroups { get; set; }
    // Miejsce nadaje się do oglądania sportu.
    public bool GoodForWatchingSports { get; set; }
    // Miejsce oferuje parking dla osób na wózkach.
    public bool WheelchairAccessibleParking { get; set; }
    // Wejście do obiektu jest przystosowane dla osób na wózku.
    public bool WheelchairAccessibleEntrance { get; set; }
    // Toaleta jest dostępna dla osób na wózkach.
    public bool WheelchairAccessibleRestroom { get; set; }
    // Miejsce ma miejsca dla osób na wózkach.
    public bool WheelchairAccessibleSeating { get; set; }
    
    public record DisplyName(string Text);
}

public record PlaceResult
{
    public List<PlaceResponse> Places { get; set; } = new();
}

