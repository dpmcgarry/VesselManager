using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace libVesselManager;

[Index(nameof(MaintainanceTypeName), IsUnique = true)]
public class MaintainanceType : IEquatable<MaintainanceType>
{
    [Key]
    public uint MaintainanceTypeId { get; set; }
    [Required]
    [Column(TypeName = "varchar(200)")]
    public required string MaintainanceTypeName { get; set; }

    public override string ToString()
    {
        return "ID: " + MaintainanceTypeId + "   Name: " + MaintainanceTypeName;
    }
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;

        MaintainanceType? objAsMaintType = obj as MaintainanceType;
        if (objAsMaintType is null) return false;
        else return Equals(objAsMaintType);
    }
    public override int GetHashCode()
    {
        return (int)MaintainanceTypeId;
    }
    public bool Equals(MaintainanceType? other)
    {
        if (other is null) return false;
        return (this.MaintainanceTypeId.Equals(other.MaintainanceTypeId) && this.MaintainanceTypeName.Equals(other.MaintainanceTypeName));
    }

    public static bool operator ==(MaintainanceType? a, MaintainanceType? b)
    {
        if (a is null && b is null) return true;
        if (a is null) return false;
        return a.Equals(b);
    }
    public static bool operator !=(MaintainanceType? a, MaintainanceType? b)
    {
        if (a is null && b is null) return true;
        if (a is null) return false;
        return !a.Equals(b);
    }

}