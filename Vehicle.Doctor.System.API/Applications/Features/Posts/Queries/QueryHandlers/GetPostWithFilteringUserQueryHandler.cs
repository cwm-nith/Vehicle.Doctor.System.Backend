using MediatR;
using Vehicle.Doctor.System.API.Applications.Exceptions.Posts;
using Vehicle.Doctor.System.API.Applications.IRepositories.Posts;
using Vehicle.Doctor.System.API.Applications.Repositories.Posts;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Posts.Queries.QueryHandlers;

public class GetPostWithFilteringUserQueryHandler : IRequestHandler<GetPostWithFilteringUserQuery, PostDto>
{
    private readonly IPostRepository _repository;

    public GetPostWithFilteringUserQueryHandler(IPostRepository repository)
    {
        _repository = repository;
    }

    public async Task<PostDto> Handle(GetPostWithFilteringUserQuery request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetSinglePostAsync(i => i.Id == request.Id && i.PosterId == request.UserId, cancellationToken)
                   ?? throw new PostNotFoundException(request.Id, request.UserId);
        return data.ToDto();
    }
}