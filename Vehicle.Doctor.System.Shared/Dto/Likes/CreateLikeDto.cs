namespace Vehicle.Doctor.System.Shared.Dto.Likes;

public class CreateLikeDto : IBaseDto
{
    public long LikerId { get; set; }
    public long PosterId { get; set; }
    public long GarageId { get; set; }
}