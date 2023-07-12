using MediatR;
using Vehicle.Doctor.System.API.Applications.IRepositories.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Likes.Queries.QueryHandlers;

public class GetCountQueryHandler : IRequestHandler<GetCountQuery, int>
{
    private readonly ILikeRepository _likeRepository;

    public GetCountQueryHandler(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }

    public Task<int> Handle(GetCountQuery request, CancellationToken cancellationToken)
    {
        return _likeRepository.GetCountAsync(l => l.PostId == request.PostId
            && l.GarageId == request.GarageId, cancellationToken);
    }
}