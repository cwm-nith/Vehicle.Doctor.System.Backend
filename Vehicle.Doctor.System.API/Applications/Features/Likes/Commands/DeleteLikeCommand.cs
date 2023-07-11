using MediatR;

namespace Vehicle.Doctor.System.API.Applications.Features.Likes.Commands;

public class DeleteLikeCommand : IRequest<bool>
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long PostId { get; set; }
    public long GarageId { get; set; }

    public DeleteLikeCommand(long id, long userId, long postId, long garageId)
    {
        Id = id;
        UserId = userId;
        PostId = postId;
        GarageId = garageId;
    }
}