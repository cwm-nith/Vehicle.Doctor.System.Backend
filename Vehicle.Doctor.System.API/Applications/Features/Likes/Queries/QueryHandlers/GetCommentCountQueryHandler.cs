using MediatR;
using Vehicle.Doctor.System.API.Applications.Features.Comments.Queries;
using Vehicle.Doctor.System.API.Applications.IRepositories.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Likes.Queries.QueryHandlers;

public class GetCommentCountQueryHandler : IRequestHandler<GetCommentCountQuery, int>
{
    private readonly ICommentRepository _commentRepository;

    public GetCommentCountQueryHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public Task<int> Handle(GetCommentCountQuery request, CancellationToken cancellationToken)
    {
        return _commentRepository.GetCountAsync(i => i.PostId == request.PostId && i.GarageId == request.GarageId,
            cancellationToken);
    }
}