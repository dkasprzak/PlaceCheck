using PlaceCheck.Infrastructure.Persistence.Configurations;
using PlaceCheck.Worker;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSqlDatabase(builder.Configuration.GetConnectionString("MainDbSql")!);
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
