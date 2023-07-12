using MediatR;

namespace Vehicle.Doctor.System.API.Applications.Features.Comments.Queries;

public class GetCommentCountQuery : IRequest<int>
{
    public long PostId { get; set; }
    public long GarageId { get; set; }

    public GetCommentCountQuery(long postId, long garageId)
    {
        PostId = postId;
        GarageId = garageId;
    }
}