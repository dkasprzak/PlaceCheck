using Microsoft.EntityFrameworkCore;
using PlaceCheck.Worker.Data.Entities;

namespace PlaceCheck.Worker.Interfaces;

public interface IApplicationDbContext
{
    DbSet<SearchedPlace> SearchedPlaces { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
