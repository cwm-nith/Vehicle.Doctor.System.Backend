using MediatR;
using Vehicle.Doctor.System.API.Applications.IRepositories;

namespace Vehicle.Doctor.System.API.Applications.Features.Users.Commands.CommandHandlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return _userRepository.DeleteUserAsync(request.Id, cancellationToken);
    }
}