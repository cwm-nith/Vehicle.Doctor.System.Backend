using Vehicle.Doctor.System.Shared.Enums.Posts;

namespace Vehicle.Doctor.System.Shared.Dto.Posts;

public class PostDto : IBaseDto
{
    public long Id { get; set; }
    public string? Description { get; set; }
    public PostEnums.PrivacyType PrivacyType { get; set; }
    public string? Urls { get; set; }
    public long PosterId { get; set; }
    public long GarageId { get; set; }
    public string? NumberOfLikes { get; set; }
    public string? NumberOfComments { get; set; }
    public DateTime? DeletedAt { get; set; }
    public long? DeletedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public long? UpdatedBy { get; set; }

    public List<LikeDto>? Likes { get; set; }
    public List<CommentDto>? Comments { get; set; }
}


public class BasePostActivityDto
{
    public long Id { get; set; }
    public long PostId { get; set; }
    public long PosterId { get; set; }
    public long GarageId { get; set; }
    public DateTime? DeletedAt { get; set; }
    public long? DeletedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public long? UpdatedBy { get; set; }
}

public class LikeDto : BasePostActivityDto, IBaseDto
{
    public long LikerId { get; set; }
}

public class CommentDto : BasePostActivityDto, IBaseDto
{
    public long CommenterId { get; set; }
}