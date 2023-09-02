using Vehicle.Doctor.System.Shared.Enums.Garages;

namespace Vehicle.Doctor.System.Shared.Dto.Garages;

public class GarageSocialLinkDto : IBaseDto
{
    public long Id { get; set; }
    public long GarageId { get; set; }
    public string SocialLink { get; set; } = string.Empty;
    public GarageEnums.SocialLinkType SocialLinkType { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}