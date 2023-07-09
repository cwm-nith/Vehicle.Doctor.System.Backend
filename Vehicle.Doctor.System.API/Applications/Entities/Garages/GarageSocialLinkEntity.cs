using Vehicle.Doctor.System.API.Infrastructure.Tables.Garages;

namespace Vehicle.Doctor.System.API.Applications.Entities.Garages;

public class GarageSocialLinkEntity : IEntity
{
    public long Id { get; set; }
    public long GarageContactId { get; set; }
    public string SocialLink { get; set; } = string.Empty;
    public SocialLinkType SocialLinkType { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public GarageContactEntity? GarageContact { get; set; }
}