using Vehicle.Doctor.System.API.Applications.Constants;

namespace Vehicle.Doctor.System.API.Applications.Exceptions.Users;

public class InvalidCredentialException : BaseException
{
    public override string Code => HttpErrorCodes.InvCred;

    public InvalidCredentialException() : base("Username or Password is invalid!")
    {

    }
}