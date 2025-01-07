using Microsoft.EntityFrameworkCore;
using PlaceCheck.Worker.Data.Entities;
using PlaceCheck.Worker.Interfaces;

namespace PlaceCheck.Worker.Data.Persistence;

public class MainDbContext : DbContext, IApplicationDbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) {}
    
    public DbSet<SearchedPlace> SearchedPlaces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainDbContext).Assembly);
    }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HavePrecision(18, 4);
        base.ConfigureConventions(configurationBuilder);
    }
}
