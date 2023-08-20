using MediatR;
using Vehicle.Doctor.System.API.Applications.IRepositories;

namespace Vehicle.Doctor.System.API.Applications.Features.Users.Commands.CommandHandlers;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
{
    private readonly IAuthRepository _authRepository;

    public ChangePasswordCommandHandler(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var data = await _authRepository.ChangePasswordAsync(request, cancellationToken);
        return data;
    }
}