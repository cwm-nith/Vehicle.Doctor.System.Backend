using MediatR;

namespace Vehicle.Doctor.System.API.Applications.Features.Users.Commands;

public class DeleteUserCommand : IRequest<bool>
{
    public long Id { get; set; }

    public DeleteUserCommand(long id)
    {
        Id = id;
    }
}