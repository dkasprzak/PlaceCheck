using PlaceCheck.Application;
using PlaceCheck.Infrastructure;
using PlaceCheck.WebApi.Middlewares;
using Serilog;
using Serilog.Sinks.Grafana.Loki;

var APP_NAME = "PlaceCheck.WebApi";

// Log.Logger = new LoggerConfiguration()
//     .Enrich.WithProperty("Application", APP_NAME)
//     .Enrich.WithProperty("MachineName", Environment.MachineName)
//     .Enrich.FromLogContext()
//     .WriteTo.Console()
//     .CreateBootstrapLogger();
//
// Log.Logger = new LoggerConfiguration()
//     .MinimumLevel.Information()
//     .WriteTo.Console()
//     .WriteTo.GrafanaLoki(
//         "http://monitoring_loki:3100",
//         labels: new[] { 
//             new LokiLabel { Key = "container", Value = "backend_pc_backend" },
//             new LokiLabel { Key = "service", Value = "place_check" }
//         })
//     .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

Log.Information("Application Starting");

Log.Logger = new LoggerConfiguration()
    .Enrich.WithProperty("Application", APP_NAME)
    .Enrich.WithProperty("MachineName", Environment.MachineName)
    .Enrich.FromLogContext()
    .MinimumLevel.Debug()
    .WriteTo.Debug()
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
    .WriteTo.GrafanaLoki(
        "http://monitoring_loki:3100", 
        labels: new[] { 
            new LokiLabel { Key = "container", Value = "backend_pc_backend" },
            new LokiLabel { Key = "service", Value = "place_check" }
        })
    .CreateLogger();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.Development.local.json");
}

// builder.Host.UseSerilog((context, services, configuration) => configuration
//     .Enrich.WithProperty("Application", APP_NAME)
//     .Enrich.WithProperty("MachineName", Environment.MachineName)
//     .ReadFrom.Configuration(context.Configuration)
//     .ReadFrom.Services(services)
//     .Enrich.FromLogContext());

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.CustomSchemaIds(x =>
    {
        var name = x.FullName;
        if (name != null)
        {
            name = name.Replace("+", "_");
        }
        return name;
    });
});
var app = builder.Build();

app.UseExceptionResultMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();