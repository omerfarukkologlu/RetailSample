using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("configuration.json");

builder.Services.AddOcelot();

var app = builder.Build();

app.UseOcelot();

app.MapControllers();

app.Run();
