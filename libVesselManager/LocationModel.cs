using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace libVesselManager;

public class Location
{
    [Key]
    public uint LocationId { get; set; }
    [Required]
    public required Room Room { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? LocationName { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? BinId { get; set; }
}