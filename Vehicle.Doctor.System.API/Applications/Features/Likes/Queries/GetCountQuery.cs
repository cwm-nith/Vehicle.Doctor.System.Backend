using MediatR;

namespace Vehicle.Doctor.System.API.Applications.Features.Likes.Queries;

public class GetCountQuery : IRequest<int>
{
    public long PostId { get; set; }
    public long GarageId { get; set; }

    public GetCountQuery(long postId, long garageId)
    {
        PostId = postId;
        GarageId = garageId;
    }
}