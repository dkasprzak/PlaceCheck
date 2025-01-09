using Microsoft.EntityFrameworkCore;
using PlaceCheck.Worker.Interfaces;

namespace PlaceCheck.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IPdfGeneratorService _pdfGeneratorService;

    public Worker(ILogger<Worker> logger, IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopeFactory.CreateScope();
            var pdfService = scope.ServiceProvider.GetRequiredService<IPdfGeneratorService>();
            await pdfService.GeneratePdf(DateTime.Today);
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
