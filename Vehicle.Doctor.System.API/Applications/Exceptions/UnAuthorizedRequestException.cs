using Vehicle.Doctor.System.API.Applications.Constants;

namespace Vehicle.Doctor.System.API.Applications.Exceptions;

public class UnAuthorizedRequestException : BaseException
{
    public UnAuthorizedRequestException() : base("Attempted to perform an unauthorized operation.") { }

    public UnAuthorizedRequestException(string message) : base(message)
    {
    }

    public UnAuthorizedRequestException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public override string Code => HttpErrorCodes.Unauthorized;
}