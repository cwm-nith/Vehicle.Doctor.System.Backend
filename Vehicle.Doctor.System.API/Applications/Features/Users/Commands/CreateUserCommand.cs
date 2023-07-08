using MediatR;
using Vehicle.Doctor.System.Shared.Dto.Users;

namespace Vehicle.Doctor.System.API.Applications.Features.Users.Commands;

public class CreateUserCommand : IRequest<UserDto>
{
    public CreateUserDto Dto { get; set; }

    public CreateUserCommand(CreateUserDto dto)
    {
        Dto = dto;
    }
}