using Vehicle.Doctor.System.API.Applications.Constants;

namespace Vehicle.Doctor.System.API.Applications.Exceptions.Users;

public class InvalidPhoneNumberException : BaseException
{
    public override string Code => HttpErrorCodes.InvPhoneNumber;

    public InvalidPhoneNumberException(string? phone) : base($"Phone number \"{phone}\" is invalid.")
    {
        
    }
}