using MediatR;
using Vehicle.Doctor.System.API.Applications.Exceptions.Garages;
using Vehicle.Doctor.System.API.Applications.IRepositories.Garages;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Garages;
using Vehicle.Doctor.System.Shared.Dto.Garages;

namespace Vehicle.Doctor.System.API.Applications.Features.Garages.Commands.CommandHandlers;

public class UpdateGarageCommandHandler : IRequestHandler<UpdateGarageCommand, GarageDto>
{
    private readonly IGarageRepository _repository;

    public UpdateGarageCommandHandler(IGarageRepository repository)
    {
        _repository = repository;
    }

    public async Task<GarageDto> Handle(UpdateGarageCommand request, CancellationToken cancellationToken)
    {
        var r = request.UpdateGarage.ToEntity() ?? throw new GarageCannotBeNullException();
        var data = await _repository.UpdateAsync(r, cancellationToken);
        return data.ToDto();
    }
}