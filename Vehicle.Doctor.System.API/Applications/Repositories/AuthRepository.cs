using Microsoft.AspNetCore.Identity;
using System.Threading;
using Vehicle.Doctor.System.API.Applications.Constants;
using Vehicle.Doctor.System.API.Applications.Entities.Users;
using Vehicle.Doctor.System.API.Applications.Exceptions.Users;
using Vehicle.Doctor.System.API.Applications.Features.Users.Commands;
using Vehicle.Doctor.System.API.Applications.IRepositories;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Users;
using Vehicle.Doctor.System.Shared.Dto.Users;

namespace Vehicle.Doctor.System.API.Applications.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<UserEntity> _passwordHasher;
    private readonly ITokenRepository _tokenRepository;
    private readonly ILogger<AuthRepository> _logger;

    public AuthRepository(IHttpContextAccessor contextAccessor, IPasswordHasher<UserEntity> passwordHasher,
        IUserRepository userRepository, ITokenRepository tokenRepository, ILogger<AuthRepository> logger)
    {
        _contextAccessor = contextAccessor;
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _tokenRepository = tokenRepository;
        _logger = logger;
    }

    public long GetUserId()
    {
        var userId = _contextAccessor.HttpContext?.User.Claims
            .FirstOrDefault(i => i.Type == ClaimsConstant.UserId)?.Value ?? "0";
        return long.Parse(userId);
    }

    public async Task<UserDto> LoginAsync(LoginDto dto, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByPhoneNumberAsync(dto.PhoneNumber, cancellationToken) ?? throw new InvalidCredentialException();
        if (!user.ValidatePassword(dto.Password, _passwordHasher)) throw new InvalidCredentialException();
        await _userRepository.UpdateLastLoginAsync(user.Id, cancellationToken);
        var token = await _tokenRepository.CreateTokenAsync(user, cancellationToken);
        user.LastLogin = DateTime.UtcNow;
        return user.ToDto(token);
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordCommand rq, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(rq.UserId, cancellationToken) ?? throw new UserNotFoundException();
        if (!user.ValidatePassword(rq.Dto.OldPassword, _passwordHasher)) throw new InvalidOldPasswordException();
        if (rq.Dto.NewPassword == rq.Dto.OldPassword) throw new NewPasswordCannotSameOldPasswordException();
        try
        {
            user.SetPassword(rq.Dto.NewPassword, _passwordHasher);
            await _userRepository.UpdateUserAsync(user, cancellationToken);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(eventId: new EventId(), exception: e,
                message: "Unable to change user password, please try again later.");
            return false;
        }
    }
}