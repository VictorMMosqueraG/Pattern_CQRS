using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Load configuration from the Api/ folder where appsettings files were moved.
var basePath = Path.Combine(Directory.GetCurrentDirectory(), "Api");
builder.Configuration.SetBasePath(basePath);
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

// Use Startup to centralize registration and pipeline configuration
var startup = new PatternCQRS.Api.Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, builder.Environment);

app.Run();
