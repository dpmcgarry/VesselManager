using Microsoft.EntityFrameworkCore;
namespace libVesselManager;

public class VesselManagerContext : DbContext
{
    public static string? ConnectionString {get; set;}
    public DbSet<Contact> Contacts {get; set;}
    public DbSet<Room> Rooms {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}