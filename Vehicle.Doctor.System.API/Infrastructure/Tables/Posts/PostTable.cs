using System.ComponentModel.DataAnnotations.Schema;
using Vehicle.Doctor.System.API.Infrastructure.Tables.BaseTables;
using Vehicle.Doctor.System.Shared.Enums.Posts;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;

[Table("posts")]
public class PostTable : BaseTable, ISoftDeleteTable, IAuditableTable
{
    [Column("description")]
    public string? Description { get; set; }

    [Column("privacy_type")]
    public PostEnums.PrivacyType PrivacyType { get; set; }

    [Column("urls")]
    public string? Urls { get; set; }

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

    public List<LikeTable>? Likes { get; set; }
    public List<CommentTable>? Comments { get; set; }
}