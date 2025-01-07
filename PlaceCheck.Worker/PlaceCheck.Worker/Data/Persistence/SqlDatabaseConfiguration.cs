using Microsoft.EntityFrameworkCore;
using PlaceCheck.Worker.Data.Persistence;
using PlaceCheck.Worker.Interfaces;

namespace PlaceCheck.Infrastructure.Persistence.Configurations;

public  static class SqlDatabaseConfiguration
{
    public static IServiceCollection AddSqlDatabase(this IServiceCollection services, string connectionString)
    {
        Action<IServiceProvider, DbContextOptionsBuilder> sqlOptions = (serviceProvider, options) =>
            options.UseSqlServer(connectionString, 
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery))
                .UseSnakeCaseNamingConvention();
        
            services.AddDbContext<IApplicationDbContext, MainDbContext>(sqlOptions);
            return services;
    }
}
