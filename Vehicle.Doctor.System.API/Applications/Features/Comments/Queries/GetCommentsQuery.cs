using MediatR;
using Vehicle.Doctor.System.Common.Pagination;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Comments.Queries;

public class GetCommentsQuery : IRequest<PagedResult<CommentDto>>
{
    public long PostId { get; set; }
    public long GarageId { get; set; }
    public PagedQuery Q { get; set; }

    public GetCommentsQuery(long postId, long garageId, PagedQuery q)
    {
        PostId = postId;
        GarageId = garageId;
        Q = q;
    }
}