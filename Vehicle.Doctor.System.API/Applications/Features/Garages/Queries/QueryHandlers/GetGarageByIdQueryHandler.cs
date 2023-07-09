using MediatR;
using Vehicle.Doctor.System.API.Applications.Exceptions.Garages;
using Vehicle.Doctor.System.API.Applications.IRepositories.Garages;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Garages;
using Vehicle.Doctor.System.Shared.Dto.Garages;

namespace Vehicle.Doctor.System.API.Applications.Features.Garages.Queries.QueryHandlers;

public class GetGarageByIdQueryHandler : IRequestHandler<GetGarageByIdQuery, GarageDto>
{
    private readonly IGarageRepository _repository;

    public GetGarageByIdQueryHandler(IGarageRepository repository)
    {
        _repository = repository;
    }

    public async Task<GarageDto> Handle(GetGarageByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetByIdUserIdAsync(request.UserId, request.Id, cancellationToken) ??
                   throw new GarageNotFoundException();
        return data.ToDto();
    }
}