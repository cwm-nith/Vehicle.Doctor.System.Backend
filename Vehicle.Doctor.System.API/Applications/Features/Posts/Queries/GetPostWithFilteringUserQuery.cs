using MediatR;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Posts.Queries;

public class GetPostWithFilteringUserQuery : IRequest<PostDto>
{
    public long Id { get; set; }
    public long UserId { get; set; }

    public GetPostWithFilteringUserQuery(long id, long userId)
    {
        Id = id;
        UserId = userId;
    }
}