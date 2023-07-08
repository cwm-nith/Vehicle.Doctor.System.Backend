using Vehicle.Doctor.System.API.Applications.Entities.Users;
using Vehicle.Doctor.System.Shared.Dto.Users;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables.Users;

public static class UserExtensions
{
    public static UserDto ToDto(this UserEntity t, string? token = null) =>
        new()
        {
            Token = t.Token ?? token,
            CreatedAt = t.CreatedAt,
            Id = t.Id,
            LastLogin = t.LastLogin,
            Name = t.Name,
            UpdatedAt = t.UpdatedAt,
            Username = t.UserName,
            PhoneNumber = t.PhoneNumber,
            DeletedAt = t.DeletedAt,
            DeletedBy = t.DeletedBy,
            MobileToken = t.MobileToken,
            UpdatedBy = t.UpdatedBy,
        };

    public static UserEntity ToEntity(this UserTable t, string? token = null) =>
        new()
        {

            Id = t.Id,
            Password = t.Password,
            Token = token,
            CreatedAt = t.CreatedAt,
            DeletedAt = t.DeletedAt,
            UserName = t.UserName,
            PhoneNumber = t.PhoneNumber,
            UpdatedAt = t.UpdatedAt,
            DeletedBy = t.DeletedBy,
            MobileToken = t.MobileToken,
            UpdatedBy = t.UpdatedBy,
            LastLogin = t.LastLogin,
            Name = t.Name,
        };

    public static UserEntity ToEntity(this UserDto t, string? token = null) =>
        new()
        {
            Id = t.Id,
            Token = t.Token ?? token,
            CreatedAt = t.CreatedAt,
            DeletedAt = t.DeletedAt,
            LastLogin = t.LastLogin,
            Name = t.Name,
            PhoneNumber = t.PhoneNumber,
            UpdatedAt = t.UpdatedAt,
            DeletedBy = t.DeletedBy,
            MobileToken = t.MobileToken,
            UpdatedBy = t.UpdatedBy,
            UserName = t.Username
        };

    public static UserTable ToTable(this UserEntity t) =>
        new()
        {
            Id = t.Id,
            LastLogin = t.LastLogin,
            Name = t.Name,
            PhoneNumber = t.PhoneNumber,
            CreatedAt = t.CreatedAt,
            DeletedAt = t.DeletedAt,
            Password = t.Password,
            UpdatedAt = t.UpdatedAt,
            UpdatedBy = t.UpdatedBy,
            MobileToken = t.MobileToken,
            UserName = t.UserName,
            DeletedBy = t.DeletedBy,
        };
}