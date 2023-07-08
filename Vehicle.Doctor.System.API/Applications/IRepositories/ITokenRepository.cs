using Vehicle.Doctor.System.API.Applications.Entities.Users;

namespace Vehicle.Doctor.System.API.Applications.IRepositories;

public interface ITokenRepository
{
    Task<string> CreateTokenAsync(UserEntity user, CancellationToken cancellationToken = default);
    bool ValidateToken(string token);
}