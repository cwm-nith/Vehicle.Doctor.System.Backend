using MediatR;
using Vehicle.Doctor.System.Shared.Dto.Garages;

namespace Vehicle.Doctor.System.API.Applications.Features.Garages.Commands;

public class CreateGarageCommand : IRequest<GarageDto>
{
    public long UserId { get; set; }
    public CreateGarageDto Garage { get; set; }

    public CreateGarageCommand(long userId, CreateGarageDto garage)
    {
        UserId = userId;
        Garage = garage;
    }
}