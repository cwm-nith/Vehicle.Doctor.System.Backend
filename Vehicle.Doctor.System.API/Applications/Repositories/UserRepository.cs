using System.Linq.Expressions;
using Vehicle.Doctor.System.API.Applications.Entities.Users;
using Vehicle.Doctor.System.API.Applications.Exceptions.Users;
using Vehicle.Doctor.System.API.Applications.IRepositories;
using Vehicle.Doctor.System.API.Applications.Utils;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Users;
using Vehicle.Doctor.System.API.Infrastructure.Tables;
using Vehicle.Doctor.System.Common.Pagination;

namespace Vehicle.Doctor.System.API.Applications.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IWriteDbRepository<UserTable> _writeDbRepository;
    private readonly IReadDbRepository<UserTable> _readDbRepository;
    private readonly ITokenRepository _tokenProvider;
    public UserRepository(IWriteDbRepository<UserTable> writeDbRepository,
        IReadDbRepository<UserTable> readDbRepository, ITokenRepository tokenProvider)
    {
        _writeDbRepository = writeDbRepository;
        _readDbRepository = readDbRepository;
        _tokenProvider = tokenProvider;
    }
    public async Task<UserEntity?> GetByIdAsync(long id, CancellationToken cancellation = default)
    {
        var user = await _readDbRepository.FirstOrDefaultAsync(i => i.Id == id, cancellation);
        return user?.ToEntity();
    }

    public async Task<UserEntity?> GetByUserNameAsync(string username, CancellationToken cancellation = default)
    {
        var user = await _readDbRepository.FirstOrDefaultAsync(i => i.UserName == username, cancellation);
        return user?.ToEntity();
    }

    public async Task<UserEntity?> GetByPhoneNumberAsync(string phoneNumber, CancellationToken cancellation = default)
    {
        if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length < 8)
        {
            throw new InvalidPhoneNumberException(phoneNumber);
        }

        phoneNumber = phoneNumber.Trim().Replace("+", "").Replace(" ", "");

        if (!phoneNumber.IsNumber()) throw new InvalidPhoneNumberException(phoneNumber);

        var user = await _readDbRepository.FirstOrDefaultAsync(i => i.PhoneNumber == phoneNumber, cancellation);
        return user?.ToEntity();
    }


    public async Task<PagedResult<UserEntity>> GetUsersAsync(Expression<Func<UserTable, bool>> predicate, IPagedQuery q, CancellationToken cancellation = default)
    {
        var data = await _readDbRepository.BrowseAsync(predicate, q, cancellation);
        return data.Map(i => i.ToEntity());
    }

    public Task<bool> HasUserAsync(CancellationToken cancellation = default)
    {
        return _readDbRepository.ExistsAsync(i => true, cancellation);
    }

    public Task<bool> IsUserExistedAsync(Expression<Func<UserTable, bool>> predicate, CancellationToken cancellation = default)
    {
        return _readDbRepository.ExistsAsync(predicate, cancellation);
    }

    public async Task<UserEntity> CreateUserAsync(UserEntity user, CancellationToken cancellation = default)
    {
        var isUsernameExisted = await IsUserExistedAsync(i => i.UserName == user.UserName || i.PhoneNumber == user.PhoneNumber, cancellation);
        if (isUsernameExisted) throw new UserAlreadyExistedException(user.UserName, user.PhoneNumber);
        var userTable = await _writeDbRepository.AddAsync(user.ToTable(), cancellation);
        user.Id = userTable.Id;
        var token = await _tokenProvider.CreateTokenAsync(user, cancellation);
        var userEntity = userTable.ToEntity(token);
        return userEntity;
    }

    public async Task<UserEntity> UpdateUserAsync(UserEntity user, CancellationToken cancellation = default)
    {
        await _writeDbRepository.UpdateAsync(user.ToTable(), cancellation);
        return user;
    }

    public async Task<bool> DeleteUserAsync(long id, CancellationToken cancellation = default)
    {
        var num = await _writeDbRepository.DeleteAsync(id, cancellation);
        return num > 0;
    }

    public Task<bool> SoftDeleteUserAsync(long id, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateLastLoginAsync(long id, CancellationToken cancellation = default)
    {
        var user = await GetByIdAsync(id, cancellation) ?? throw new UserNotFoundException(id);
        user.LastLogin = DateTime.UtcNow;
        await _writeDbRepository.UpdateAsync(user.ToTable(), cancellation);
    }
}