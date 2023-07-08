using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Vehicle.Doctor.System.API.Applications.Constants;
using Vehicle.Doctor.System.API.Applications.Entities.Users;
using Vehicle.Doctor.System.API.Applications.Exceptions.Users;
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

    public AuthRepository(IHttpContextAccessor contextAccessor, IPasswordHasher<UserEntity> passwordHasher,
        IUserRepository userRepository, ITokenRepository tokenRepository)
    {
        _contextAccessor = contextAccessor;
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _tokenRepository = tokenRepository;
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
}