using MediatR;
using Vehicle.Doctor.System.API.Applications.IRepositories.Posts;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;
using Vehicle.Doctor.System.Common.Pagination;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Posts.Queries.QueryHandlers;

public class GetPostByUserQueryHandler : IRequestHandler<GetPostByUserQuery, PagedResult<PostDto>>
{
    private readonly IPostRepository _postRepository;

    public GetPostByUserQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<PagedResult<PostDto>> Handle(GetPostByUserQuery request, CancellationToken cancellationToken)
    {
        var data = await _postRepository.GetByUserAsync(request, cancellationToken);
        return data.Map(i => i.ToDto());
    }
}