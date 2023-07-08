using Vehicle.Doctor.System.API.Applications.Constants;

namespace Vehicle.Doctor.System.API.Applications.Exceptions.Users;

public class UserNotFoundException : BaseException
{
    public override string Code => HttpErrorCodes.UserNotFound;

    public UserNotFoundException(long id) : base($"User with id \"{id}\" not found!")
    {
        
    }

    public UserNotFoundException(string username, bool isEmail = false) : base(!isEmail
        ? $"User with username \"{username}\" not found!"
        : $"User with email \"{username}\" not found!")
    {

    }

    public UserNotFoundException() : base()
    {

    }
}