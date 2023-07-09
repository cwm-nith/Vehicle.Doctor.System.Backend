using MediatR;
using Vehicle.Doctor.System.API.Applications.IRepositories.Garages;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Garages;
using Vehicle.Doctor.System.Common.Pagination;
using Vehicle.Doctor.System.Shared.Dto.Garages;

namespace Vehicle.Doctor.System.API.Applications.Features.Garages.Queries.QueryHandlers;

public class GetGaragesByUserQueryHandler : IRequestHandler<GetGaragesByUserQuery, PagedResult<GarageDto>>
{
    private readonly IGarageRepository _repository;

    public GetGaragesByUserQueryHandler(IGarageRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<GarageDto>> Handle(GetGaragesByUserQuery request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetByUserIdAsync(request.UserId, request.Query, cancellationToken);
        return data.Map(i => i.ToDto());
    }
}