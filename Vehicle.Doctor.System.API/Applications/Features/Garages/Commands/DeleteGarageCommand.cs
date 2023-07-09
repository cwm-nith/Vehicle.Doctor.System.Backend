using MediatR;

namespace Vehicle.Doctor.System.API.Applications.Features.Garages.Commands;

public class DeleteGarageCommand : IRequest<bool>
{
    public long Id { get; set; }
    public long UserId { get; set; }

    public DeleteGarageCommand(long id, long userId)
    {
        Id = id;
        UserId = userId;
    }
}