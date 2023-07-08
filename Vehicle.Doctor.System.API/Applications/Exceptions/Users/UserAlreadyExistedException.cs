using Vehicle.Doctor.System.API.Applications.Constants;

namespace Vehicle.Doctor.System.API.Applications.Exceptions.Users;

public class UserAlreadyExistedException : BaseException
{
    public override string Code => HttpErrorCodes.UserAlreadyExisted;

    public UserAlreadyExistedException() : base("User already existed.")
    {
        
    }

    public UserAlreadyExistedException(string username, string phoneNumber)
        : base($"User with username \"{username}\" or phone number \"{phoneNumber}\" already existed.")
    {
        
    }
}