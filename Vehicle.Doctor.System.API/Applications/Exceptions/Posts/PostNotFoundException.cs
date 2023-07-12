using Vehicle.Doctor.System.API.Applications.Constants;

namespace Vehicle.Doctor.System.API.Applications.Exceptions.Posts;

public class PostNotFoundException : BaseException
{
    public override string Code => HttpErrorCodes.PostNotFound;

    public PostNotFoundException() : base("Post not found.")
    {
        
    }

    public PostNotFoundException(long postId, long posterId)
        : base($"Post not found with filtering PostId[{postId}] & PosterId[{posterId}].")
    {

    }

    public PostNotFoundException(long postId, long posterId, long garageId) 
        : base($"Post not found with filtering PostId[{postId}], PosterId[{posterId}] & GarageId[{garageId}].")
    {
        
    }
}