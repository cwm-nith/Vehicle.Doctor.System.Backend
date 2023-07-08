using MediatR;
using Vehicle.Doctor.System.API.Applications.IRepositories;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Users;
using Vehicle.Doctor.System.Shared.Dto.Users;

namespace Vehicle.Doctor.System.API.Applications.Features.Users.Queries.QueryHandlers;

public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, UserDto?>
{
    private readonly IUserRepository _userRepository;

    public GetUserByNameQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto?> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUserNameAsync(request.Username, cancellationToken);
        return user?.ToDto();
    }
}