using Vehicle.Doctor.System.API.Applications.Constants;

namespace Vehicle.Doctor.System.API.Applications.Exceptions.Users;

public class InvalidUserNameException : BaseException
{
    public override string Code => HttpErrorCodes.InvUserName;

    public InvalidUserNameException(string username) : base($"Username \"{username}\" cannot contain whitespace.")
    {
        
    }
}