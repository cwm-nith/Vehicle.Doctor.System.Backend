using MediatR;
using Vehicle.Doctor.System.Shared.Dto.Users;

namespace Vehicle.Doctor.System.API.Applications.Features.Users.Commands;

public class ChangePasswordCommand : IRequest<bool>
{
    public long UserId { get; set; }
    public ChangePasswordDto Dto { get; set; }

    public ChangePasswordCommand(ChangePasswordDto dto, long userId)
    {
        Dto = dto;
        UserId = userId;
    }
}