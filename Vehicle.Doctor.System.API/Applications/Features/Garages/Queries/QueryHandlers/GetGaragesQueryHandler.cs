using MediatR;
using Vehicle.Doctor.System.API.Applications.IRepositories.Garages;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Garages;
using Vehicle.Doctor.System.Common.Pagination;
using Vehicle.Doctor.System.Shared.Dto.Garages;

namespace Vehicle.Doctor.System.API.Applications.Features.Garages.Queries.QueryHandlers;

public class GetGaragesQueryHandler : IRequestHandler<GetGaragesQuery, PagedResult<GarageDto>>
{
    private readonly IGarageRepository _repository;

    public GetGaragesQueryHandler(IGarageRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<GarageDto>> Handle(GetGaragesQuery request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetAsync(request.Query, cancellationToken);
        return data.Map(i => i.ToDto());
    }
}