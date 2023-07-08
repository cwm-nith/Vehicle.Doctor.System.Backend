using System.Linq.Expressions;
using Vehicle.Doctor.System.API.Applications.Entities.Users;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Users;
using Vehicle.Doctor.System.Common.Pagination;

namespace Vehicle.Doctor.System.API.Applications.IRepositories;

public interface IUserRepository
{
    Task<UserEntity?> GetByIdAsync(long id, CancellationToken cancellation = default);
    Task<UserEntity?> GetByUserNameAsync(string username, CancellationToken cancellation = default);
    Task<UserEntity?> GetByPhoneNumberAsync(string phoneNumber, CancellationToken cancellation = default);
    Task<PagedResult<UserEntity>> GetUsersAsync(Expression<Func<UserTable, bool>> predicate, IPagedQuery q, CancellationToken cancellation = default);
    Task<bool> HasUserAsync(CancellationToken cancellation = default);
    Task<bool> IsUserExistedAsync(Expression<Func<UserTable, bool>> predicate, CancellationToken cancellation = default);

    Task<UserEntity> CreateUserAsync(UserEntity user, CancellationToken cancellation = default);
    Task<UserEntity> UpdateUserAsync(UserEntity user, CancellationToken cancellation = default);
    Task<bool> DeleteUserAsync(long id, CancellationToken cancellation = default);
    Task<bool> SoftDeleteUserAsync(long id, CancellationToken cancellation = default);

    Task UpdateLastLoginAsync(long id, CancellationToken cancellation = default);
}