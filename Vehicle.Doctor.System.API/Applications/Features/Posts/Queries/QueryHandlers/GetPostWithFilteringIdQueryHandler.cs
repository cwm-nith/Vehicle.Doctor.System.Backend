using MediatR;
using Vehicle.Doctor.System.API.Applications.Exceptions.Posts;
using Vehicle.Doctor.System.API.Applications.IRepositories.Posts;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Posts.Queries.QueryHandlers;

public class GetPostWithFilteringIdQueryHandler : IRequestHandler<GetPostWithFilteringIdQuery, PostDto>
{
    private readonly IPostRepository _postRepository;

    public GetPostWithFilteringIdQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<PostDto> Handle(GetPostWithFilteringIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _postRepository.GetSinglePostAsync(i => i.Id == request.Id,cancellationToken) 
                   ?? throw new PostNotFoundException();
        return data.ToDto();
    }
}