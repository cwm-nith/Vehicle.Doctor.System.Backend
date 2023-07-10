using System.ComponentModel.DataAnnotations;

namespace Vehicle.Doctor.System.Shared.Dto.Users;

public class LoginDto : IBaseDto
{
    [Required]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}