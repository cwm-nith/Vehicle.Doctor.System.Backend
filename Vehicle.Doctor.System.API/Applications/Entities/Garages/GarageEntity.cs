using Vehicle.Doctor.System.API.Applications.Entities.Users;

namespace Vehicle.Doctor.System.API.Applications.Entities.Garages;

public class GarageEntity : IEntity
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Address { get; set; }
    public double Lat { get; set; }
    public double Long { get; set; }
    public string? Description { get; set; }
    public long UserId { get; set; }
    public DateTime? DeletedAt { get; set; }
    public long? DeletedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public long? UpdatedBy { get; set; }

    public UserEntity? User { get; set; }

    public List<GarageContactEntity>? GarageContacts { get; set; }
}