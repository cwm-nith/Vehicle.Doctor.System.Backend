using System.Linq.Expressions;
using Microsoft.Extensions.Caching.Distributed;
using Vehicle.Doctor.System.API.Applications.Entities.Users;
using Vehicle.Doctor.System.API.Applications.Exceptions.Users;
using Vehicle.Doctor.System.API.Applications.Helpers;
using Vehicle.Doctor.System.API.Applications.IRepositories;
using Vehicle.Doctor.System.API.Applications.Utils;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Users;
using Vehicle.Doctor.System.API.Infrastructure.Tables;
using Vehicle.Doctor.System.Common.Pagination;

namespace Vehicle.Doctor.System.API.Applications.Repositories;

public class UserRepository : IUserRepository
{
    public const string CacheKey = "VDS:USERS";

    private readonly IWriteDbRepository<UserTable> _writeDbRepository;
    private readonly IReadDbRepository<UserTable> _readDbRepository;
    private readonly ITokenRepository _tokenProvider;
    private readonly IDistributedCache _distributedCache;
    public UserRepository(IWriteDbRepository<UserTable> writeDbRepository,
        IReadDbRepository<UserTable> readDbRepository, ITokenRepository tokenProvider, IDistributedCache distributedCache)
    {
        _writeDbRepository = writeDbRepository;
        _readDbRepository = readDbRepository;
        _tokenProvider = tokenProvider;
        _distributedCache = distributedCache;
    }
    public async Task<UserEntity?> GetByIdAsync(long id, CancellationToken cancellation = default)
    {
        var key = GenKeyCache(id);
        var userEntity = await _distributedCache.GetAsync<UserEntity>(key, cancellation);
        if(userEntity is not null) return userEntity;
        var user = await _readDbRepository.FirstOrDefaultAsync(i => i.Id == id, cancellation);
        userEntity = user?.ToEntity();
        await _distributedCache.SetAsync(key, userEntity, cancellationToken: cancellation);
        return userEntity;
    }

    public async Task<UserEntity?> GetByUserNameAsync(string username, CancellationToken cancellation = default)
    {
        var key = GenKeyCache(username);
        var userEntity = await _distributedCache.GetAsync<UserEntity>(key, cancellation);
        if (userEntity is not null) return userEntity;
        var user = await _readDbRepository.FirstOrDefaultAsync(i => i.UserName == username, cancellation);
        userEntity = user?.ToEntity();
        await _distributedCache.SetAsync(key, userEntity, cancellationToken: cancellation);
        return userEntity;
    }

    public async Task<UserEntity?> GetByPhoneNumberAsync(string phoneNumber, CancellationToken cancellation = default)
    {

        phoneNumber = RegexExtension.ValidatePhoneNumber(phoneNumber);
        var key = GenKeyCache(phoneNumber);
        var userEntity = await _distributedCache.GetAsync<UserEntity>(key, cancellation);
        if (userEntity is not null) return userEntity;
        var user = await _readDbRepository.FirstOrDefaultAsync(i => i.PhoneNumber == phoneNumber, cancellation);
        userEntity = user?.ToEntity();
        await _distributedCache.SetAsync(key, userEntity, cancellationToken: cancellation);
        return userEntity;
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

        var tasks = new List<Task>
        {
            _distributedCache.Invalidate(GenKeyCache(user.PhoneNumber), cancellation),
            _writeDbRepository.UpdateAsync(user.ToTable(), cancellation),
            _distributedCache.Invalidate(GenKeyCache(user.Id), cancellation),
            _distributedCache.Invalidate(GenKeyCache(user.UserName), cancellation)
        };
        await Task.WhenAll(tasks);
        return user;
    }

    public async Task<bool> DeleteUserAsync(long id, CancellationToken cancellation = default)
    {
        var user = await GetByIdAsync(id, cancellation) ?? throw new UserNotFoundException(id);
        var num = await _writeDbRepository.DeleteAsync(user.Id, cancellation);
        var tasks = new List<Task>
        {
            _distributedCache.Invalidate(GenKeyCache(user.PhoneNumber), cancellation),
            _distributedCache.Invalidate(GenKeyCache(user.Id), cancellation),
            _distributedCache.Invalidate(GenKeyCache(user.UserName), cancellation)
        };
        await Task.WhenAll(tasks);
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

        var tasks = new List<Task>
        {
            _distributedCache.Invalidate(GenKeyCache(user.PhoneNumber), cancellation),
            _writeDbRepository.UpdateAsync(user.ToTable(), cancellation),
            _distributedCache.Invalidate(GenKeyCache(user.Id), cancellation),
            _distributedCache.Invalidate(GenKeyCache(user.UserName), cancellation)
        };
        await Task.WhenAll(tasks);
    }

    private static string GenKeyCache(long id)
    {
        return $"{CacheKey}:{id}";
    }

    private static string GenKeyCache(string username)
    {
        return $"{CacheKey}:{username}";
    }
}