using MediatR;
using Vehicle.Doctor.System.Shared.Dto.Likes;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Likes.Commands;

public class CreateLikeCommand : IRequest<LikeDto>
{
    public long UserId { get; set; }
    public CreateLikeDto Dto { get; set; }

    public CreateLikeCommand(CreateLikeDto dto, long userId)
    {
        Dto = dto;
        UserId = userId;
    }
}