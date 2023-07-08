using Microsoft.AspNetCore.Identity;
using Vehicle.Doctor.System.API.Applications.Exceptions.Users;

namespace Vehicle.Doctor.System.API.Applications.Entities.Users;

public class UserEntity : IEntity
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? Token { get; set; }
    public string Password { get; set; } = string.Empty;
    public string? MobileToken { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public long? UpdatedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public long? DeletedBy { get; set; }
    public DateTime? LastLogin { get; set; }
    public void SetPassword(string pass, IPasswordHasher<UserEntity> passwordHasher)
    {
        if (string.IsNullOrEmpty(pass) || passwordHasher is null)
        {
            throw new InvalidPasswordException();
        }
        Password = passwordHasher.HashPassword(this, pass);
    }

    public bool ValidatePassword(string password, IPasswordHasher<UserEntity> passwordHasher)
    {
        return passwordHasher?.VerifyHashedPassword(this, Password, password) != PasswordVerificationResult.Failed;
    }
}