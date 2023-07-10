namespace Vehicle.Doctor.System.API.Applications.Constants;

public class HttpErrorCodes
{
    public const string Unauthorized = "API_UNAUTH";
    public const string UserNotFound = "USER_NOT_FOUND";
    public const string InvPassword = "INVALID_PASSWORD";
    public const string FailGenToken = "FAILED_GENERATE_TOKEN";
    public const string InvCred = "INVALID_CRED";
    public const string InvPhoneNumber = "INVALID_PHONE_NUMBER";
    public const string InvUserName = "INVALID_USERNAME";
    public const string UserAlreadyExisted = "USER_ALREADY_EXISTED";

    public const string GarageNotFound = "GARAGE_NOT_FOUND";
    public const string GarageCannotBeNull = "GARAGE_CANNOT_BE_NULL";

    protected HttpErrorCodes()
    {
    }
}