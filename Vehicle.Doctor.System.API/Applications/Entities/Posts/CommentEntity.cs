namespace Vehicle.Doctor.System.API.Applications.Entities.Posts;

public class CommentEntity : BasePostActivityEntity
{
    public long CommenterId { get; set; }
    public string Comment { get; set; } = string.Empty;
}