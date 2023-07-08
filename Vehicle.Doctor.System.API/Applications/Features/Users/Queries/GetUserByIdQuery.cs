using MediatR;
using Vehicle.Doctor.System.Shared.Dto.Users;

namespace Vehicle.Doctor.System.API.Applications.Features.Users.Queries;

public class GetUserByIdQuery : IRequest<UserDto?>
{
    public long Id { get; set; }

    public GetUserByIdQuery(long id)
    {
        Id = id;
    }
}