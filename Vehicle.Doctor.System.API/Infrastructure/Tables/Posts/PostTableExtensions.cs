using Vehicle.Doctor.System.API.Applications.Entities.Posts;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;

public static class PostTableExtensions
{
    public static PostDto ToDto(this PostEntity t) =>
        new()
        {
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            DeletedAt = t.DeletedAt,
            DeletedBy = t.DeletedBy,
            UpdatedBy = t.UpdatedBy,
            Id = t.Id,
            Description = t.Description,
            GarageId = t.GarageId,
            Likes = t.Likes?.Select(i => i.ToDto()).ToList(),
            NumberOfLikes = t.NumberOfLikes,
            Comments = t.Comments?.Select(i => i.ToDto()).ToList(),
            PosterId = t.PosterId,
            NumberOfComments = t.NumberOfComments,
            PrivacyType = t.PrivacyType,
            Urls = t.Urls,
        };

    public static PostEntity ToEntity(this PostTable t) =>
        new()
        {

            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            DeletedAt = t.DeletedAt,
            DeletedBy = t.DeletedBy,
            UpdatedBy = t.UpdatedBy,
            Id = t.Id,
            Description = t.Description,
            GarageId = t.GarageId,
            Likes = t.Likes?.Select(i => i.ToEntity()).ToList(),
            Comments = t.Comments?.Select(i => i.ToEntity()).ToList(),
            PosterId = t.PosterId,
            PrivacyType = t.PrivacyType,
            Urls = t.Urls,
        };

    public static PostEntity ToEntity(this PostDto t) =>
        new()
        {
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            DeletedAt = t.DeletedAt,
            DeletedBy = t.DeletedBy,
            UpdatedBy = t.UpdatedBy,
            Id = t.Id,
            Description = t.Description,
            GarageId = t.GarageId,
            Likes = t.Likes?.Select(i => i.ToEntity()).ToList(),
            Comments = t.Comments?.Select(i => i.ToEntity()).ToList(),
            PosterId = t.PosterId,
            PrivacyType = t.PrivacyType,
            Urls = t.Urls,
        };

    public static PostTable ToTable(this PostEntity t) =>
        new()
        {
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            DeletedAt = t.DeletedAt,
            DeletedBy = t.DeletedBy,
            UpdatedBy = t.UpdatedBy,
            Id = t.Id,
            Description = t.Description,
            GarageId = t.GarageId,
            Likes = t.Likes?.Select(i => i.ToTable()).ToList(),
            Comments = t.Comments?.Select(i => i.ToTable()).ToList(),
            PosterId = t.PosterId,
            PrivacyType = t.PrivacyType,
            Urls = t.Urls,
        };
}

public static class LikeTableExtensions
{
    public static LikeDto ToDto(this LikeEntity t) =>
        new()
        {
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            DeletedAt = t.DeletedAt,
            DeletedBy = t.DeletedBy,
            UpdatedBy = t.UpdatedBy,
            Id = t.Id,
            GarageId = t.GarageId,
            PostId = t.PostId,
            LikerId = t.LikerId,
            PosterId = t.PosterId,
        };

    public static LikeEntity ToEntity(this LikeTable t) =>
        new()
        {

            Id = t.Id,
            CreatedAt = t.CreatedAt,
            DeletedAt = t.DeletedAt,
            UpdatedAt = t.UpdatedAt,
            DeletedBy = t.DeletedBy,
            UpdatedBy = t.UpdatedBy,
            GarageId = t.GarageId,
            PostId = t.PostId,
            LikerId = t.LikerId,
            PosterId = t.PosterId,
        };

    public static LikeEntity ToEntity(this LikeDto t) =>
        new()
        {

            Id = t.Id,
            CreatedAt = t.CreatedAt,
            DeletedAt = t.DeletedAt,
            UpdatedAt = t.UpdatedAt,
            DeletedBy = t.DeletedBy,
            UpdatedBy = t.UpdatedBy,
            GarageId = t.GarageId,
            PostId = t.PostId,
            LikerId = t.LikerId,
            PosterId = t.PosterId,
        };

    public static LikeTable ToTable(this LikeEntity t) =>
        new()
        {
            Id = t.Id,
            CreatedAt = t.CreatedAt,
            DeletedAt = t.DeletedAt,
            UpdatedAt = t.UpdatedAt,
            DeletedBy = t.DeletedBy,
            UpdatedBy = t.UpdatedBy,
            GarageId = t.GarageId,
            PostId = t.PostId,
            LikerId = t.LikerId,
            PosterId = t.PosterId,
        };
}

public static class CommentTableExtensions
{
    public static CommentDto ToDto(this CommentEntity t) =>
        new()
        {
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            DeletedAt = t.DeletedAt,
            DeletedBy = t.DeletedBy,
            UpdatedBy = t.UpdatedBy,
            Id = t.Id,
            GarageId = t.GarageId,
            PostId = t.PostId,
            PosterId = t.PosterId,
            CommenterId = t.CommenterId,
        };

    public static CommentEntity ToEntity(this CommentTable t) =>
        new()
        {

            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            DeletedAt = t.DeletedAt,
            DeletedBy = t.DeletedBy,
            UpdatedBy = t.UpdatedBy,
            Id = t.Id,
            GarageId = t.GarageId,
            PostId = t.PostId,
            PosterId = t.PosterId,
            CommenterId = t.CommenterId,
        };

    public static CommentEntity ToEntity(this CommentDto t) =>
        new()
        {

            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            DeletedAt = t.DeletedAt,
            DeletedBy = t.DeletedBy,
            UpdatedBy = t.UpdatedBy,
            Id = t.Id,
            GarageId = t.GarageId,
            PostId = t.PostId,
            PosterId = t.PosterId,
            CommenterId = t.CommenterId,
        };

    public static CommentTable ToTable(this CommentEntity t) =>
        new()
        {
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            DeletedAt = t.DeletedAt,
            DeletedBy = t.DeletedBy,
            UpdatedBy = t.UpdatedBy,
            Id = t.Id,
            GarageId = t.GarageId,
            PostId = t.PostId,
            PosterId = t.PosterId,
            CommenterId = t.CommenterId,
        };
}