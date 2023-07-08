using Vehicle.Doctor.System.Shared.Dto.Users;

namespace Vehicle.Doctor.System.API.Applications.IRepositories;

public interface IAuthRepository
{
    long GetUserId();
    Task<UserDto> LoginAsync(LoginDto dto, CancellationToken cancellationToken = default);
}