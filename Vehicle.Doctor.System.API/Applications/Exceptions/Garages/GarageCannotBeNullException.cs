using Vehicle.Doctor.System.API.Applications.Constants;

namespace Vehicle.Doctor.System.API.Applications.Exceptions.Garages;

public class GarageCannotBeNullException : BaseException
{
    public override string Code => HttpErrorCodes.GarageCannotBeNull;

    public GarageCannotBeNullException() : base("Garage update cannot be null.")
    {
        
    }
}