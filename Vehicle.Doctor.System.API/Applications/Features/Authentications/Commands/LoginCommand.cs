using MediatR;
using Vehicle.Doctor.System.Shared.Dto.Users;

namespace Vehicle.Doctor.System.API.Applications.Features.Authentications.Commands;

public class LoginCommand : IRequest<UserDto>
{
    public LoginDto Dto { get; set; }

    public LoginCommand(LoginDto dto)
    {
        Dto = dto;
    }
}