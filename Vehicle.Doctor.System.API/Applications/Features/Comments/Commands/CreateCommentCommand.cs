using MediatR;
using Vehicle.Doctor.System.Shared.Dto.Comments;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Comments.Commands;

public class CreateCommentCommand : IRequest<CommentDto>
{

    public CreateCommentCommand(long userId, CreateCommentDto dto)
    {
        UserId = userId;
        Dto = dto;
    }

    public long UserId { get; set; }
    public CreateCommentDto Dto { get; set; }

}