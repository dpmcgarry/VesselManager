using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace libVesselManager;

[Index(nameof(RoomName), IsUnique = true)]
public class Room : IEquatable<Room>
{
    [Key]
    public uint RoomId { get; set; }
    [Required]
    [Column(TypeName = "varchar(100)")]
    public required string RoomName { get; set; }

    public override string ToString()
    {
        return "ID: " + RoomId + "   Name: " + RoomName;
    }
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;

        Room? objAsRoom = obj as Room;
        if (objAsRoom is null) return false;
        else return Equals(objAsRoom);
    }
    public override int GetHashCode()
    {
        return (int)RoomId;
    }
    public bool Equals(Room? other)
    {
        if (other is null) return false;
        return (this.RoomId.Equals(other.RoomId) && this.RoomName.Equals(other.RoomName));
    }

    public static bool operator ==(Room? a, Room? b)
    {
        if (a is null && b is null) return true;
        if (a is null) return false;
        return a.Equals(b);
    }
    public static bool operator !=(Room? a, Room? b)
    {
        if (a is null && b is null) return true;
        if (a is null) return false;
        return !a.Equals(b);
    }
}