using System.ComponentModel.DataAnnotations;

namespace libVesselManager;

public class Contact
{
    [Key]
    public uint ContactId { get; set; }
    [Required]
    public string? Name { get; set; }
    public string? Company { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? Website { get; set; }
}