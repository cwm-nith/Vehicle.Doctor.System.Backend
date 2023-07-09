using MediatR;
using Vehicle.Doctor.System.Common.Pagination;
using Vehicle.Doctor.System.Shared.Dto.Garages;

namespace Vehicle.Doctor.System.API.Applications.Features.Garages.Queries;

public class GetGaragesQuery : IRequest<PagedResult<GarageDto>>
{
    public PagedQuery Query { get; set; }
    public GetGaragesQuery(PagedQuery q)
    {
        Query = q;
    }
}