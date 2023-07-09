using Vehicle.Doctor.System.API.Applications.Entities.Garages;
using Vehicle.Doctor.System.API.Applications.IRepositories.Garages;
using Vehicle.Doctor.System.API.Infrastructure.Tables;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Garages;
using Vehicle.Doctor.System.Common.Pagination;

namespace Vehicle.Doctor.System.API.Applications.Repositories.Garages;

public class GarageRepository : IGarageRepository
{
    private readonly IWriteDbRepository<GarageTable> _writeDbRepository;

    public GarageRepository(IWriteDbRepository<GarageTable> writeDbRepository)
    {
        _writeDbRepository = writeDbRepository;
    }

    public async Task<GarageEntity> CreateAsync(GarageEntity garage, CancellationToken cancellationToken = default)
    {
        var t = garage.ToTable();
        var data = await _writeDbRepository
            .AddAsync(t, cancellationToken);
        return data.ToEntity();
    }

    public Task<GarageEntity> UpdateAsync(GarageEntity garage, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id, long userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<GarageEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<GarageEntity?> GetByIdUserIdAsync(long userId, long id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<GarageEntity>> GetByUserIdAsync(long userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<GarageEntity>> GetAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}