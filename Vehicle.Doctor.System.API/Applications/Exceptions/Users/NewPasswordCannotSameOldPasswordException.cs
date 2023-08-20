using Vehicle.Doctor.System.API.Applications.Constants;

namespace Vehicle.Doctor.System.API.Applications.Exceptions.Users;

public class NewPasswordCannotSameOldPasswordException : BaseException
{
    public override string Code => HttpErrorCodes.InvCred;

    public NewPasswordCannotSameOldPasswordException() : base("New password must not be the same as old password.")
    {

    }
}