using MediatR;
using Vehicle.Doctor.System.API.Applications.IRepositories;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Users;
using Vehicle.Doctor.System.Shared.Dto.Users;

namespace Vehicle.Doctor.System.API.Applications.Features.Users.Queries.QueryHandlers;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto?>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        return user?.ToDto();
    }
}