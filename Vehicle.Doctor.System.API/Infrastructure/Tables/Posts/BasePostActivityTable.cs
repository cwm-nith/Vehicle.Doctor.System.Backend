using System.ComponentModel.DataAnnotations.Schema;
using Vehicle.Doctor.System.API.Infrastructure.Tables.BaseTables;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;

public class BasePostActivityTable : BaseTable, ISoftDeleteTable, IAuditableTable
{
    [Column("post_id")]
    public long PostId { get; set; }

    [Column("poster_id")]
    public long PosterId { get; set; }

    [Column("garage_id")]
    public long GarageId { get; set; }

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
}