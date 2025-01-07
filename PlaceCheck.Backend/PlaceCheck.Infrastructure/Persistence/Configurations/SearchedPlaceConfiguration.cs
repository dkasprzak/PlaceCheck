using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlaceCheck.Domain.Entities;

namespace PlaceCheck.Infrastructure.Persistence.Configurations;

public class SearchedPlaceConfiguration : IEntityTypeConfiguration<SearchedPlace>
{
    public void Configure(EntityTypeBuilder<SearchedPlace> builder)
    { 
    }
}
