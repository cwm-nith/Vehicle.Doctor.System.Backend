using MediatR;
using Vehicle.Doctor.System.Shared.Dto.Garages;

namespace Vehicle.Doctor.System.API.Applications.Features.Garages.Queries;

public class GetGarageByIdQuery : IRequest<GarageDto>
{
    public long Id { get; set; }
    public long UserId { get; set; }

    public GetGarageByIdQuery(long id, long userId)
    {
        Id = id;
        UserId = userId;
    }
}