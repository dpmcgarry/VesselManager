using Microsoft.EntityFrameworkCore;
namespace libVesselManager;

public class VesselManagerContext : DbContext
{
    public static string? ConnectionString { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<MaintainanceType> MaintainanceTypes { get; set; }
    public DbSet<System> Systems { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<MaintainanceItem> MaintainanceItems { get; set; }
    public DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Item>()
            .Property(q => q.Quantity)
            .HasDefaultValue(0);
    }
}