using System.ComponentModel.DataAnnotations;
namespace libVesselManager;

public class Room
{
    [Key]
    public uint RoomId {get; set;}
    [Required]
    public string RoomName {get; set;}
}