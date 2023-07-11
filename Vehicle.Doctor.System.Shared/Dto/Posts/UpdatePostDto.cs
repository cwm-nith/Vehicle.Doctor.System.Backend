using Vehicle.Doctor.System.Shared.Enums.Posts;

namespace Vehicle.Doctor.System.Shared.Dto.Posts;

public class UpdatePostDto
{
    public long Id { get; set; }
    public string? Description { get; set; }
    public PostEnums.PrivacyType PrivacyType { get; set; }
    public string? Urls { get; set;}
    public long GarageId { get; set; }
}