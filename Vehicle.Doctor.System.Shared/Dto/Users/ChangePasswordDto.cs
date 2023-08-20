namespace Vehicle.Doctor.System.Shared.Dto.Users;

public class ChangePasswordDto
{
    public string OldPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}