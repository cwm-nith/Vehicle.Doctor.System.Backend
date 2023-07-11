using MediatR;
using Vehicle.Doctor.System.API.Applications.Exceptions.Posts;
using Vehicle.Doctor.System.API.Applications.IRepositories.Posts;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Posts.Queries.QueryHandlers;

public class GetPostWithFilteringQueryHandler : IRequestHandler<GetPostWithFilteringQuery, PostDto>
{
    private readonly IPostRepository _postRepository;

    public GetPostWithFilteringQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<PostDto> Handle(GetPostWithFilteringQuery request, CancellationToken cancellationToken)
    {
        var data = await _postRepository.GetSinglePostAsync(
            i => i.Id == request.Id && i.GarageId == request.GarageId && i.PosterId == request.UserId,
            cancellationToken) ?? throw new PostNotFoundException(request.Id, request.UserId, request.GarageId);
        return data.ToDto();
    }
}