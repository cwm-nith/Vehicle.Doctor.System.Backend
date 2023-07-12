using MediatR;
using Vehicle.Doctor.System.Shared.Dto.Posts;

namespace Vehicle.Doctor.System.API.Applications.Features.Posts.Queries;

public class GetPostWithFilteringQuery : IRequest<PostDto>
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long GarageId { get; set; }

    public GetPostWithFilteringQuery(long id, long userId, long garageId)
    {
        Id = id;
        UserId = userId;
        GarageId = garageId;
    }
}