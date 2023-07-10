namespace Vehicle.Doctor.System.API.Applications.Entities.Posts;

public class BasePostActivityEntity
{
    public long Id { get; set; }
    public long PostId { get; set; }
    public long PosterId { get; set; }
    public long GarageId { get; set; }
    public DateTime? DeletedAt { get; set; }
    public long? DeletedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public long? UpdatedBy { get; set; }
}