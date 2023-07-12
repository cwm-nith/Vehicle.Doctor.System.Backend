using MediatR;
using Vehicle.Doctor.System.Shared.Dto.Comments;

namespace Vehicle.Doctor.System.API.Applications.Features.Comments.Commands;

public class DeleteCommentCommand : IRequest<bool>
{
    public long UserId { get; set; }
    public DeleteCommentDto Dto { get; set; }

    public DeleteCommentCommand(long userId, DeleteCommentDto dto)
    {
        UserId = userId;
        Dto = dto;
    }
}