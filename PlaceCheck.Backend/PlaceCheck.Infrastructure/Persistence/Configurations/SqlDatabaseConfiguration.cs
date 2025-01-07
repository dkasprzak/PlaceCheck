using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlaceCheck.Application.Interfaces;

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
