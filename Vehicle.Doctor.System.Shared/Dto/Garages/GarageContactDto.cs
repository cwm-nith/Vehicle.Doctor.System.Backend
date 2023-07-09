namespace Vehicle.Doctor.System.Shared.Dto.Garages;

public class GarageContactDto : IBaseDto
{
    public long Id { get; set; }
    public long GarageId { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string? Telegram { get; set; }
    public string? WhatsApp { get; set; }
    public string? WeChat { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public List<GarageSocialLinkDto>? GarageSocialLinks { get; set; }
    public GarageDto? Garage { get; set; }
}