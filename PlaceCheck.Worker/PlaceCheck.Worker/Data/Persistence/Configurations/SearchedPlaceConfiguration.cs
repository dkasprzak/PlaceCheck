using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlaceCheck.Worker.Data.Entities;

namespace PlaceCheck.Worker.Data.Persistence.Configurations;

public class SearchedPlaceConfiguration : IEntityTypeConfiguration<SearchedPlace>
{
    public void Configure(EntityTypeBuilder<SearchedPlace> builder)
    {
    }
}
