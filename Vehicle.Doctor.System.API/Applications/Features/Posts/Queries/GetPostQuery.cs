using MediatR;
using Vehicle.Doctor.System.Common.Pagination;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Posts.Queries;

public class GetPostQuery : IRequest<PagedResult<PostDto>>
{
    public PagedQuery Q { get; set; }

    public GetPostQuery(PagedQuery q)
    {
        Q = q;
    }
}