using MediatR;
using Vehicle.Doctor.System.Shared.Dto.Garages;

namespace Vehicle.Doctor.System.API.Applications.Features.Garages.Commands;

public class UpdateGarageCommand : IRequest<GarageDto>
{
    public GarageDto UpdateGarage { get; set; }

    public UpdateGarageCommand(GarageDto updateGarage)
    {
        UpdateGarage = updateGarage;
    }
}