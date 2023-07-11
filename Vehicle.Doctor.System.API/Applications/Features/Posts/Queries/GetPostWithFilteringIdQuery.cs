using MediatR;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Posts.Queries;

public class GetPostWithFilteringIdQuery : IRequest<PostDto>
{
    public long Id { get; set; }

    public GetPostWithFilteringIdQuery(long id)
    {
        Id = id;
    }
}