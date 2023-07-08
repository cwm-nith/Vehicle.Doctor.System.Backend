using Vehicle.Doctor.System.API.Applications.Constants;

namespace Vehicle.Doctor.System.API.Applications.Exceptions.Users;

public class FailedToCreateTokenException : BaseException
{
    public FailedToCreateTokenException(string message) : base(message)
    {
    }

    public FailedToCreateTokenException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public FailedToCreateTokenException() : base("Failed to generate token")
    {
    }

    public override string Code => HttpErrorCodes.FailGenToken;
}