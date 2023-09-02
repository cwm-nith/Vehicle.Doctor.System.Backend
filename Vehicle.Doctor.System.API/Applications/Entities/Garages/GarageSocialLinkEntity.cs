using Vehicle.Doctor.System.Shared.Enums.Garages;

namespace Vehicle.Doctor.System.API.Applications.Entities.Garages;

public class GarageSocialLinkEntity : IEntity
{
    public long Id { get; set; }
    public long GarageId { get; set; }
    public string SocialLink { get; set; } = string.Empty;
    public GarageEnums.SocialLinkType SocialLinkType { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public GarageEntity? Garage { get; set; }
}