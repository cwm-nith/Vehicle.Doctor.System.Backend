using MediatR;
using Vehicle.Doctor.System.API.Applications.IRepositories.Posts;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;
using Vehicle.Doctor.System.Common.Pagination;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Comments.Queries.QueryHandlers;

public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, PagedResult<CommentDto>>
{
    private readonly ICommentRepository _commentRepository;

    public GetCommentsQueryHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<PagedResult<CommentDto>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
    {
        var data = await _commentRepository.GetAsync(i => i.PostId == request.PostId && i.GarageId == request.GarageId,
             request.Q, cancellationToken);
        return data.Map(i => i.ToDto());
    }
}