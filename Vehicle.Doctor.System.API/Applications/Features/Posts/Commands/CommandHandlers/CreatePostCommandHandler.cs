using MediatR;
using Vehicle.Doctor.System.API.Applications.Entities.Posts;
using Vehicle.Doctor.System.API.Applications.IRepositories.Posts;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Posts.Commands.CommandHandlers;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, PostDto>
{
    private readonly IPostRepository _repository;

    public CreatePostCommandHandler(IPostRepository repository)
    {
        _repository = repository;
    }

    public async Task<PostDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        var entity = new PostEntity()
        {
            Urls = r.Urls,
            Description = r.Description,
            GarageId = r.GarageId,
            PosterId = request.PosterId,
            PrivacyType = r.PrivacyType,
        };
        var data = await _repository.CreateAsync(entity, cancellationToken);
        return data.ToDto();
    }
}