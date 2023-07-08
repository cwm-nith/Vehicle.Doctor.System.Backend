using MediatR;
using Vehicle.Doctor.System.API.Applications.Exceptions.Users;
using Vehicle.Doctor.System.API.Applications.IRepositories;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Users;
using Vehicle.Doctor.System.Shared.Dto.Users;

namespace Vehicle.Doctor.System.API.Applications.Features.Users.Commands.CommandHandlers;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new UserNotFoundException(request.Id);
        user.Name = request.Name ?? user.Name;
        user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;

        var updatedUser = await _userRepository.UpdateUserAsync(user, cancellationToken);
        return updatedUser.ToDto();
    }
}