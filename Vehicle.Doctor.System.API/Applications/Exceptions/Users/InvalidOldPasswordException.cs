using Vehicle.Doctor.System.API.Applications.Constants;

namespace Vehicle.Doctor.System.API.Applications.Exceptions.Users;

public class InvalidOldPasswordException : BaseException
{
    public override string Code => HttpErrorCodes.InvCred;

    public InvalidOldPasswordException() : base("Your old password is correct!")
    {

    }
}