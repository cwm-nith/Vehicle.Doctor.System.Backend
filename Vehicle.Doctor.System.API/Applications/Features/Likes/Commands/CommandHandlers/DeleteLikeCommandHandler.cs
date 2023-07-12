using MediatR;
using Vehicle.Doctor.System.API.Applications.IRepositories.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Likes.Commands.CommandHandlers;

public class DeleteLikeCommandHandler : IRequestHandler<DeleteLikeCommand, bool>
{
    private readonly ILikeRepository _likeRepository;

    public DeleteLikeCommandHandler(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }

    public Task<bool> Handle(DeleteLikeCommand request, CancellationToken cancellationToken)
    {
        return _likeRepository.DeleteAsync(
            i => i.LikerId == request.UserId && i.GarageId == request.GarageId && i.PostId == request.PostId,
            cancellationToken);
    }
}