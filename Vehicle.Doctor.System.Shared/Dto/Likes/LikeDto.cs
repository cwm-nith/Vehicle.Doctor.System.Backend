namespace Vehicle.Doctor.System.Shared.Dto.Likes;

public class LikeDto : IBaseDto
{
    public long Id { get; set; }
    public long LikerId { get; set; }
    public long PostId { get; set; }
    public long PosterId { get; set; }
    public long GarageId { get; set; }

}