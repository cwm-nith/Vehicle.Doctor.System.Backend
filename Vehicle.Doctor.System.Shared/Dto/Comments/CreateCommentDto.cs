namespace Vehicle.Doctor.System.Shared.Dto.Comments;

public class CreateCommentDto : IBaseDto
{
    public long PostId { get; set; }
    public long PosterId { get; set; }
    public long GarageId { get; set; }
    public string Comment { get; set; } = string.Empty;
}