using MediatR;
using Vehicle.Doctor.System.Common.Pagination;
using Vehicle.Doctor.System.Shared.Dto.Garages;

namespace Vehicle.Doctor.System.API.Applications.Features.Garages.Queries;

public class GetGaragesByUserQuery : IRequest<PagedResult<GarageDto>>
{
    public long UserId { get; set; }
    public PagedQuery Query { get; set; }
    public GetGaragesByUserQuery(long userId, PagedQuery q)
    {
        UserId = userId;
        Query = q;
    }
}