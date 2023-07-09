using System.ComponentModel.DataAnnotations;

namespace Vehicle.Doctor.System.Shared.Dto.Users;

public class CreateUserDto : IBaseDto
{
    [Required(ErrorMessage = "Name cannot be empty or null.")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Username cannot be empty or null.")]
    public string Username { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password cannot be empty or null.")]
    public string Password { get; set; } = string.Empty;
    [Required(ErrorMessage = "PhoneNumber cannot be empty or null.")]
    public string PhoneNumber { get; set; } = string.Empty;
}