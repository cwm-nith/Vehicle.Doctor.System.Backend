namespace Vehicle.Doctor.System.API.Applications.Entities.Garages;

public class GarageContactEntity : IEntity
{
    public long Id { get; set; }
    public long GarageId { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string? Telegram { get; set; }
    public string? WhatsApp { get; set; }
    public string? WeChat { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public GarageEntity? Garage { get; set; }
}