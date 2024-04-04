using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace libVesselManager;

[Index(nameof(SystemName), IsUnique = true)]
public class System : IEquatable<System>
{
    [Key]
    public uint SystemId { get; set; }
    [Required]
    [Column(TypeName = "varchar(100)")]
    public required string SystemName { get; set; }

    public override string ToString()
    {
        return "ID: " + SystemId + "   Name: " + SystemName;
    }
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;

        System? objAsSystem = obj as System;
        if (objAsSystem is null) return false;
        else return Equals(objAsSystem);
    }
    public override int GetHashCode()
    {
        return (int)SystemId;
    }
    public bool Equals(System? other)
    {
        if (other is null) return false;
        return (this.SystemId.Equals(other.SystemId) && this.SystemName.Equals(other.SystemName));
    }

    public static bool operator ==(System? a, System? b)
    {
        if (a is null && b is null) return true;
        if (a is null) return false;
        return a.Equals(b);
    }
    public static bool operator !=(System? a, System? b)
    {
        if (a is null && b is null) return true;
        if (a is null) return false;
        return !a.Equals(b);
    }
}