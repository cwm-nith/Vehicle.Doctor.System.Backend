using System.Text.RegularExpressions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Vehicle.Doctor.System.API.Applications.Entities.Users;
using Vehicle.Doctor.System.API.Applications.Exceptions.Users;
using Vehicle.Doctor.System.API.Applications.IRepositories;
using Vehicle.Doctor.System.API.Applications.Utils;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Users;
using Vehicle.Doctor.System.Shared.Dto.Users;

namespace Vehicle.Doctor.System.API.Applications.Features.Users.Commands.CommandHandlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<UserEntity> _passwordHasher;

    public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher<UserEntity> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;

        if (r.Username.Contains(' ')) throw new InvalidUserNameException(r.Username);

        //+85593 256 184
        if (string.IsNullOrEmpty(r.PhoneNumber) || r.PhoneNumber.Length < 8)
        {
            throw new InvalidPhoneNumberException(r.PhoneNumber);
        }

        r.PhoneNumber = r.PhoneNumber.Trim().Replace("+", "").Replace(" ", "");

        if (!r.PhoneNumber.IsNumber()) throw new InvalidPhoneNumberException(r.PhoneNumber);

        var entity = new UserEntity
        {
            LastLogin = DateTime.UtcNow,
            UserName = r.Username,
            Name = r.Name,
            PhoneNumber = r.PhoneNumber,
        };
        entity.SetPassword(r.Password, _passwordHasher);
        var data = await _userRepository.CreateUserAsync(entity, cancellationToken);
        return data.ToDto();
    }
}