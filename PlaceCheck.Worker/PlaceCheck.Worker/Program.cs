using PlaceCheck.Infrastructure.Persistence.Configurations;
using PlaceCheck.Worker;
using PlaceCheck.Worker.Configuration;
using PlaceCheck.Worker.Interfaces;
using PlaceCheck.Worker.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSqlDatabase(builder.Configuration.GetConnectionString("MainDbSql")!);
builder.Services.Configure<DirectoriesSettings>(builder.Configuration.GetSection("Directories"));
builder.Services.AddScoped<IPdfGeneratorService, PdfGeneratorService>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
