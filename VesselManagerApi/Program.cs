using Serilog;
using VesselManagerApi;
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting web application");
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog();
    var app = builder.Build();
    app.MapGet("/api", () => "Hello World!");
    app.MapGet("/api/foo", EnumEndpoints.GetAllTodos);
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}


