using System.ComponentModel.DataAnnotations.Schema;
using Vehicle.Doctor.System.API.Infrastructure.Tables.BaseTables;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables.Users;

[Table("users")]
public class UserTable : BaseTable, IAuditableTable, ISoftDeleteTable
{
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("username")]
    public string UserName { get; set; } = string.Empty;

    [Column("phone_number")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Column("password")]
    public string Password { get; set; } = string.Empty;

    [Column("mobile_token")]
    public string? MobileToken { get; set; }

    [Column("last_login")]
    public DateTime? LastLogin { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("updated_by")]
    public long? UpdatedBy { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    [Column("deleted_by")]
    public long? DeletedBy { get; set; }
}