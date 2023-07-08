using MediatR;
using Vehicle.Doctor.System.API.Applications.IRepositories;
using Vehicle.Doctor.System.Shared.Dto.Users;

namespace Vehicle.Doctor.System.API.Applications.Features.Authentications.Commands.CommandHandlers;

public class LoginCommandHandler : IRequestHandler<LoginCommand, UserDto>
{
    private readonly IAuthRepository _authRepository;

    public LoginCommandHandler(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<UserDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _authRepository.LoginAsync(request.Dto, cancellationToken);
        return user;
    }
}