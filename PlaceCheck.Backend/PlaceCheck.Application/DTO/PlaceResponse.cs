namespace PlaceCheck.Application.DTO;

public record PlaceResponse
{
    public string Id { get; set; }
    public DisplyName DisplayName { get; set; }
    public bool AllowsDogs { get; set; }
    
    public record DisplyName(string Text);
}

public record PlaceResult
{
    public List<PlaceResponse> Places { get; set; } = new();
}

