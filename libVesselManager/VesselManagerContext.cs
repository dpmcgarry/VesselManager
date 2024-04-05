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

    public VesselManagerContext()
    { }
    public VesselManagerContext(DbContextOptions<VesselManagerContext> options) : base(options)
    { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // This is CRITICAL to not mess up DI in the API but allow the Console to work
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Item>()
            .Property(q => q.Quantity)
            .HasDefaultValue(0);
    }
}