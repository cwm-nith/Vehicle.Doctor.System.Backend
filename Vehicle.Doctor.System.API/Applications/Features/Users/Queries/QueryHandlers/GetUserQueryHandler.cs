using MediatR;
using Vehicle.Doctor.System.API.Applications.IRepositories;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Users;
using Vehicle.Doctor.System.Common.Pagination;
using Vehicle.Doctor.System.Shared.Dto.Users;

namespace Vehicle.Doctor.System.API.Applications.Features.Users.Queries.QueryHandlers;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, PagedResult<UserDto>>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<PagedResult<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetUsersAsync(i => true, request, cancellationToken);
        return users.Map(i => i.ToDto());
    }
}