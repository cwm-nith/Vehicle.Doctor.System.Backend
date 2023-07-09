using Vehicle.Doctor.System.API.Applications.Constants;

namespace Vehicle.Doctor.System.API.Applications.Exceptions.Garages;

public class GarageNotFoundException : BaseException
{
    public override string Code => HttpErrorCodes.GarageNotFound;

    public GarageNotFoundException() : base("Garage is not found.")
    {
        
    }
}