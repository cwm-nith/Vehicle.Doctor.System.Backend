namespace Vehicle.Doctor.System.Shared.Dto.Comments;

public class DeleteCommentDto : IBaseDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public bool IsOwner { get; set; }
    public long PostId { get; set; }
    public long GarageId { get; set; }
}