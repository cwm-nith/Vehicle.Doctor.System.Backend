using MediatR;
using Vehicle.Doctor.System.API.Applications.IRepositories.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Comments.Commands.CommandHandlers;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, bool>
{
    private readonly ICommentRepository _commentRepository;

    public DeleteCommentCommandHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        if (r.IsOwner)
        {
            return _commentRepository.DeleteAsync(
                i => r.GarageId == i.GarageId && i.PosterId == r.UserId && i.PostId == r.PostId && i.Id == r.Id, cancellationToken);
        }

        return _commentRepository.DeleteAsync(
            i => r.GarageId == i.GarageId && i.CommenterId == request.UserId && i.PostId == r.PostId && i.Id == r.Id, cancellationToken);
    }
}