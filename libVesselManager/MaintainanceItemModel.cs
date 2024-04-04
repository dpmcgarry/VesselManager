using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace libVesselManager;

public class MaintainanceItem
{
    [Key]
    public uint MaintainanceItemId { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public required MaintainanceType Type { get; set; }
    [Required]
    public required System System { get; set; }

    public bool IsPerodic { get; set; }
    public bool IsTracked { get; set; }
    public string? Description { get; set; }
    public double Hours { get; set; }
    [Required]
    public required Contact Technician { get; set; }
    public double Cost { get; set; }
    public string? Notes { get; set; }
}