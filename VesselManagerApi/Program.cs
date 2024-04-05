using Serilog;
using Microsoft.OpenApi.Models;
using VesselManagerApi;
using libVesselManager;
using MySqlConnector;
using Microsoft.EntityFrameworkCore;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting web application");
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog();
    var connStrBuilder = new MySqlConnectionStringBuilder
    {
        UserID = builder.Configuration["vesselmanagerdev:user"],
        Server = builder.Configuration["vesselmanagerdev:server"],
        Database = builder.Configuration["vesselmanagerdev:database"],
        Password = builder.Configuration["vesselmanagerdev:password"]
    };
    var connstr = connStrBuilder.ConnectionString;
    Log.Information(connstr);
    builder.Services.AddDbContext<VesselManagerContext>(options =>
        options.UseMySql(connstr, ServerVersion.AutoDetect(connstr))
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
    );

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "VesselManager API", Description = "Manage Inventory and Maintainance of your Vessel", Version = "v1.0" });
    });
    var app = builder.Build();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "VesselManager API v1.0");
    });

    app.MapGet("/", () => "Hello World!");
    app.MapGet("/api/foo", EnumEndpoints.GetAllTodos);
    app.MapGet("/rooms", RoomHandler.GetAllRooms);
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


