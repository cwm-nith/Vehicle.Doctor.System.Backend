namespace Vehicle.Doctor.System.Shared.Dto.Users;

public class UpdateUserDto : IBaseDto
{
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
}