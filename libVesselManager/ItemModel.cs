using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace libVesselManager;

public class Item
{
    [Key]
    public uint ItemId { get; set; }
    [Required]
    public uint Quantity { get; set; }
    [Required]
    public required System System { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? Component { get; set; }
    public Contact? VendorId { get; set; }
    [Required]
    [Column(TypeName = "varchar(100)")]
    public required string ItemTitle { get; set; }
    public string? Description { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? PartNumber { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? Manufacturer { get; set; }
    public Location? Location { get; set; }
    public double Cost { get; set; }
    public string? Notes { get; set; }
}