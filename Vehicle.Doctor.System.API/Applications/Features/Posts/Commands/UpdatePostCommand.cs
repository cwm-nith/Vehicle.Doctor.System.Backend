using MediatR;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Posts.Commands;

public class UpdatePostCommand : IRequest<PostDto>
{
    public long UserId { get; set; }
    public UpdatePostDto Dto { get; set; }

    public UpdatePostCommand(UpdatePostDto dto, long userId)
    {
        Dto = dto;
        UserId = userId;
    }
}