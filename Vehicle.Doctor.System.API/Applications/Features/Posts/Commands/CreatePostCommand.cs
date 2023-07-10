using MediatR;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Posts.Commands;

public class CreatePostCommand : IRequest<PostDto>
{
    public long PosterId { get; set; }
    public CreatePostDto Dto { get; set; }

    public CreatePostCommand(long posterId, CreatePostDto dto)
    {
        PosterId = posterId;
        Dto = dto;
    }
}