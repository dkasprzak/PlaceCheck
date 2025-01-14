namespace PlaceCheck.Worker.Data.Entities;

public class SearchedPlace
{
    public Guid Id { get; set; }
    public string SearchPhase { get; set; }
    public string City { get; set; }
    public DateTimeOffset InsertedOn { get; set; }
}
