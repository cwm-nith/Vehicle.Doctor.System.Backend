using Vehicle.Doctor.System.API.Applications.Constants;

namespace Vehicle.Doctor.System.API.Applications.Exceptions.Users;

public class InvalidPasswordException : BaseException
{
    public InvalidPasswordException(string message) : base(message)
    {
    }

    public InvalidPasswordException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public InvalidPasswordException()
    {
    }

    public override string Code => HttpErrorCodes.InvPassword;
}