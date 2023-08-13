using Microsoft.EntityFrameworkCore;
using Vehicle.Doctor.System.API.Applications.Entities.Garages;
using Vehicle.Doctor.System.API.Applications.Exceptions.Garages;
using Vehicle.Doctor.System.API.Applications.Helpers;
using Vehicle.Doctor.System.API.Applications.IRepositories.Garages;
using Vehicle.Doctor.System.API.Infrastructure.Tables;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Garages;
using Vehicle.Doctor.System.Common.Pagination;

namespace Vehicle.Doctor.System.API.Applications.Repositories.Garages;

public class GarageRepository : IGarageRepository
{
    private const string CacheKey = "GARAGES";
    private readonly IWriteDbRepository<GarageTable> _writeDbRepository;
    private readonly IReadDbRepository<GarageTable> _readDbRepository;
    private readonly CacheHelper _distributedCache;

    public GarageRepository(IWriteDbRepository<GarageTable> writeDbRepository,
        IReadDbRepository<GarageTable> readDbRepository, CacheHelper distributedCache)
    {
        _writeDbRepository = writeDbRepository;
        _readDbRepository = readDbRepository;
        _distributedCache = distributedCache;
    }

    public async Task<GarageEntity> CreateAsync(GarageEntity garage, CancellationToken cancellationToken = default)
    {
        var t = garage.ToTable();
        var data = await _writeDbRepository
            .AddAsync(t, cancellationToken);
        return data.ToEntity();
    }

    public async Task<GarageEntity> UpdateAsync(GarageEntity garage, CancellationToken cancellationToken = default)
    {
        var key = $"{CacheKey}:{garage.Id}";
        var tasks = new List<Task>()
        {
            _distributedCache.InvalidateAsync(key, cancellationToken),
            _writeDbRepository.UpdateAsync(garage.ToTable(), cancellationToken)
        };
        await Task.WhenAll(tasks);
        return garage;
    }

    public async Task<bool> DeleteAsync(long id, long userId, CancellationToken cancellationToken = default)
    {
        var key = $"{CacheKey}:{id}";
        var garage = await GetByIdUserIdAsync(userId, id, cancellationToken) ?? throw new GarageNotFoundException();
        await _distributedCache.InvalidateAsync(key, cancellationToken);
        var num = await _writeDbRepository.DeleteAsync(garage.Id, cancellationToken);
        return num > 0;
    }

    public async Task<GarageEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var key = $"{CacheKey}:{id}";
        var garageEntity = await _distributedCache.GetAsync<GarageEntity>(key, cancellationToken);
        if (garageEntity is not null) return garageEntity;
        var garage = await _readDbRepository.Context.Garages!
            .Include(i => i.GarageContacts)!
            .ThenInclude(i => i.GarageSocialLinks)
            .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
        garageEntity = garage?.ToEntity();
        await _distributedCache.SetAsync(key, garageEntity, cancellationToken: cancellationToken);
        return garageEntity;
    }

    public async Task<GarageEntity?> GetByIdUserIdAsync(long userId, long id, CancellationToken cancellationToken = default)
    {
        var key = $"{CacheKey}:{id}";
        var garageEntity = await _distributedCache.GetAsync<GarageEntity>(key, cancellationToken);
        if (garageEntity is not null) return garageEntity;
        var garage = await _readDbRepository.Context.Garages!
            .Include(i => i.GarageContacts)!
            .ThenInclude(i => i.GarageSocialLinks)
            .FirstOrDefaultAsync(i => i.UserId == userId && i.Id == id, cancellationToken);
        garageEntity = garage?.ToEntity();
        await _distributedCache.SetAsync(key, garageEntity, cancellationToken: cancellationToken);
        return garageEntity;
    }

    public async Task<PagedResult<GarageEntity>> GetByUserIdAsync(long userId, PagedQuery q, CancellationToken cancellationToken = default)
    {
        var garages = await _readDbRepository.Context.Garages!
            .Include(i => i.GarageContacts)!
            .ThenInclude(i => i.GarageSocialLinks)
            .Where(i => i.UserId == userId).PaginateAsync(q, cancellationToken);
        return garages.Map(i => i.ToEntity());
    }

    public async Task<PagedResult<GarageEntity>> GetAsync(PagedQuery q, CancellationToken cancellationToken = default)
    {
        var garages = await _readDbRepository.Context.Garages!
            .Include(i => i.GarageContacts)!
            .ThenInclude(i => i.GarageSocialLinks)
            .Where(i => true).PaginateAsync(q, cancellationToken);
        return garages.Map(i => i.ToEntity());
    }
}