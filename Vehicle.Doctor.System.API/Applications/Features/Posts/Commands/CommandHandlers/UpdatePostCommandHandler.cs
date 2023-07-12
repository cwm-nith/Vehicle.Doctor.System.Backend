using MediatR;
using Vehicle.Doctor.System.API.Applications.Exceptions.Posts;
using Vehicle.Doctor.System.API.Applications.IRepositories.Posts;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;
using Vehicle.Doctor.System.Shared.Dto.Posts;
using Vehicle.Doctor.System.Shared.Enums.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Posts.Commands.CommandHandlers;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, PostDto>
{
    private readonly IPostRepository _repository;

    public UpdatePostCommandHandler(IPostRepository repository)
    {
        _repository = repository;
    }

    public async Task<PostDto> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        var post = await _repository.GetSinglePostAsync(
            i => i.Id == r.Id && i.GarageId == r.GarageId 
                              && i.PosterId == request.UserId, cancellationToken) 
                   ?? throw new PostNotFoundException(r.Id, request.UserId, r.GarageId);

        post.Description = r.Description ?? post.Description;
        post.Urls = r.Urls ?? post.Urls;
        post.PrivacyType = r.PrivacyType != PostEnums.PrivacyType.None ? r.PrivacyType : post.PrivacyType;
        var data = await _repository.UpdateAsync(post, cancellationToken);
        return data.ToDto();
    }
}