using Microsoft.EntityFrameworkCore;
using PlaceCheck.Worker.Interfaces;

namespace PlaceCheck.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
                    var places = await dbContext.SearchedPlaces.ToListAsync(stoppingToken);
                    var count = places.Count.ToString();
                    _logger.Log(LogLevel.Information, $"Places found: {count}");
                }
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}
