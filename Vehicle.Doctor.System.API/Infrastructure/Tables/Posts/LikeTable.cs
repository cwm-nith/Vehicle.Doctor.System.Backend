using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;

[Table("likes")]
public class LikeTable : BasePostActivityTable
{
    [Column("liker_id")] 
    public long LikerId { get; set; }

    public PostTable? Post { get; set; }
}