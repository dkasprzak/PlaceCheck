using PlaceCheck.Domain.Common;

namespace PlaceCheck.Domain.Entities;

public class SearchedPlace : AuditableEntity
{
    public Guid Id { get; set; }
    public string SearchPhase { get; set; }
    public DateTimeOffset InsertedOn { get; set; }
}
