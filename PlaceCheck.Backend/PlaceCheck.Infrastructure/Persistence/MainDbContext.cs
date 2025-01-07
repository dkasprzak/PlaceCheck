using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PlaceCheck.Application.Interfaces;
using PlaceCheck.Domain.Entities;

namespace PlaceCheck.Infrastructure.Persistence;

public class MainDbContext : DbContext, IApplicationDbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> options): base(options)
    {}
    
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
