using Microsoft.EntityFrameworkCore;
using PlaceCheck.Domain.Entities;

namespace PlaceCheck.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<SearchedPlace> SearchedPlaces { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
