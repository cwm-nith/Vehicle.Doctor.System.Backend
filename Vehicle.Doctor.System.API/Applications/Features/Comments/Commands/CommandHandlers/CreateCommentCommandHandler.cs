using MediatR;
using Vehicle.Doctor.System.API.Applications.Entities.Posts;
using Vehicle.Doctor.System.API.Applications.IRepositories.Posts;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Comments.Commands.CommandHandlers;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CommentDto>
{
    private readonly ICommentRepository _commentRepository;

    public CreateCommentCommandHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<CommentDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        var entity = new CommentEntity
        {
            Comment = r.Comment,
            Id = 0,
            CommenterId = request.UserId,
            GarageId = r.GarageId,
            PostId = r.PostId,
            PosterId = r.PosterId,
        };
        var data = await _commentRepository.CreateAsync(entity, cancellationToken);
        return data.ToDto();
    }
}