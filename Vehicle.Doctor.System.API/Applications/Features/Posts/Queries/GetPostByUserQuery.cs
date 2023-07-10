using MediatR;
using Vehicle.Doctor.System.Common.Pagination;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Posts.Queries;

public class GetPostByUserQuery : IRequest<PagedResult<PostDto>>
{
    public long UserId { get; set; }
    public PagedQuery Q { get; set; }

    public GetPostByUserQuery(long userId, PagedQuery q)
    {
        UserId = userId;
        Q = q;
    }
}