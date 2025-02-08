using PlaceCheck.Infrastructure.Persistence.Configurations;
using PlaceCheck.Worker;
using PlaceCheck.Worker.Configuration;
using PlaceCheck.Worker.Interfaces;
using PlaceCheck.Worker.Services;
using Serilog;
using Serilog.Sinks.Grafana.Loki;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.GrafanaLoki(
        "http://monitoring_loki:3100",
        labels: new[] { 
            new LokiLabel { Key = "app", Value = "pc_worker" },
            new LokiLabel { Key = "environment", Value = "production" }
        })
    .CreateLogger();

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSqlDatabase(builder.Configuration.GetConnectionString("MainDbSql")!);
builder.Services.Configure<DirectoriesSettings>(builder.Configuration.GetSection("Directories"));
builder.Services.AddScoped<IPdfGeneratorService, PdfGeneratorService>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
