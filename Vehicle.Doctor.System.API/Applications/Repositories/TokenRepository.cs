using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vehicle.Doctor.System.API.Applications.Configurations;
using Vehicle.Doctor.System.API.Applications.Entities.Users;
using Vehicle.Doctor.System.API.Applications.IRepositories;

namespace Vehicle.Doctor.System.API.Applications.Repositories;

public class TokenRepository : ITokenRepository
{
    private readonly ApplicationSetting _appSettings;

    public TokenRepository(ApplicationSetting appSettings)
    {
        _appSettings = appSettings;
    }

    public async Task<string> CreateTokenAsync(UserEntity user, CancellationToken cancellationToken = default)
    {

        var key = Encoding.UTF8.GetBytes(_appSettings.Jwt.SigningKey);

        var expiryInMinutes = _appSettings.Jwt.ExpiryInMinutes;

        List<Claim> claims = new()
        {
            new Claim("userId", user.Id.ToString()),
            new Claim("username", user.UserName),
            new Claim("phoneNumber", user.PhoneNumber),
            new Claim("issueAt", DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Name),
        };
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(expiryInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _appSettings.Jwt.Site,
            Audience = _appSettings.Jwt.Site,

        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return await Task.FromResult(tokenHandler.WriteToken(token));
    }

    public bool ValidateToken(string token)
    {
        throw new NotImplementedException();
    }
}