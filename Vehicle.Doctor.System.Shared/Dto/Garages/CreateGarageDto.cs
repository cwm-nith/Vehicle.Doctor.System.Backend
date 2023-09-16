using System.ComponentModel.DataAnnotations;
using Vehicle.Doctor.System.Shared.Enums.Garages;

namespace Vehicle.Doctor.System.Shared.Dto.Garages;

public class CreateGarageDto : IBaseDto
{
    public string Name { get; set; } = string.Empty;
    public string? Address { get; set; }
    public double Lat { get; set; }
    public double Long { get; set; }
    public string? Description { get; set; }
    public List<string> PhoneNumber { get; set; } = new();
    public List<string> Telegram { get; set; } = new();
    public List<string> WhatsApp { get; set; } = new();
    public List<string> WeChat { get; set; } = new();
    public List<CreateGarageSocialLinkDto>? GarageSocialLinks { get; set; }
}

public class CreateGarageSocialLinkDto : IBaseDto
{
    [Required]
    public string SocialLink { get; set; } = string.Empty;
    /// <summary>
    /// None = 0,
    /// YouTube = 1,
    /// Facebook = 2,
    /// Instagram = 3,
    /// Twitter = 4,
    /// Tamneak = 5,
    /// Threads = 6,
    /// TikTok = 7,
    /// </summary>
    public GarageEnums.SocialLinkType SocialLinkType { get; set; }
}