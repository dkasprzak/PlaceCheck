namespace PlaceCheck.Domain.Common;

public abstract class AuditableEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset InsertedOn { get; set; }
}
