using MediatR;
using Vehicle.Doctor.System.Shared.Dto.Users;

namespace Vehicle.Doctor.System.API.Applications.Features.Users.Queries;

public class GetUserByNameQuery : IRequest<UserDto?>
{
    public string Username { get; set; }

    public GetUserByNameQuery(string username)
    {
        Username = username;
    }
}