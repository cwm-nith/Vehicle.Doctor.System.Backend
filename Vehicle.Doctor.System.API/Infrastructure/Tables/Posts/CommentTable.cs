using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;

[Table("comments")]
public class CommentTable : BasePostActivityTable
{
    [Column("commenter_id")] 
    public long CommenterId { get; set; }

    public PostTable? Post { get; set; }
}