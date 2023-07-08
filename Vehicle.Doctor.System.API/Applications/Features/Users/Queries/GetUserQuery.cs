using MediatR;
using Vehicle.Doctor.System.Common.Pagination;
using Vehicle.Doctor.System.Shared.Dto.Users;

namespace Vehicle.Doctor.System.API.Applications.Features.Users.Queries;

public class GetUserQuery : PagedQuery, IRequest<PagedResult<UserDto>>
{
}