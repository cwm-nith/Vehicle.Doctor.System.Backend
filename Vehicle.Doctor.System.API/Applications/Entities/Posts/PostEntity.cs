using Vehicle.Doctor.System.Shared.Enums.Posts;

namespace Vehicle.Doctor.System.API.Applications.Entities.Posts;


public class PostEntity : IEntity
{
    public long Id { get; set; }
    public string? Description { get; set; }
    public PostEnums.PrivacyType PrivacyType { get; set; }
    public string? Urls { get; set; }
    public long PosterId { get; set; }
    public long GarageId { get; set; }
    public DateTime? DeletedAt { get; set; }
    public long? DeletedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public long? UpdatedBy { get; set; }

    public string? NumberOfLikes => Likes?.Count.ToString();
    public string? NumberOfComments => Comments?.Count.ToString();

    public List<LikeEntity>? Likes { get; set; }
    public List<CommentEntity>? Comments { get; set; }
}