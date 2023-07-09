using System.ComponentModel.DataAnnotations.Schema;
using Vehicle.Doctor.System.API.Infrastructure.Tables.BaseTables;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Users;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables.Garages;

[Table("garages")]
public class GarageTable : BaseTable, ISoftDeleteTable, IAuditableTable
{
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("address")] 
    public string? Address { get; set; }

    [Column("lat")]
    public double Lat { get; set; }

    [Column("long")]
    public double Long { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("user_id")] 
    public long UserId { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("deleted_by")]
    public long? DeletedBy { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("updated_by")]
    public long? UpdatedBy { get; set; }

    public UserTable? User { get; set; }

    public List<GarageContactTable>? GarageContacts { get; set; }
}