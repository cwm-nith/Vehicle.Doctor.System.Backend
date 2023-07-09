using Vehicle.Doctor.System.API.Applications.Entities.Garages;
using Vehicle.Doctor.System.Common.Pagination;

namespace Vehicle.Doctor.System.API.Applications.IRepositories.Garages;

public interface IGarageRepository
{
    Task<GarageEntity> CreateAsync(GarageEntity garage, CancellationToken cancellationToken = default);
    Task<GarageEntity> UpdateAsync(GarageEntity garage, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(long id, long userId, CancellationToken cancellationToken = default);

    Task<GarageEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<GarageEntity?> GetByIdUserIdAsync(long userId, long id, CancellationToken cancellationToken = default);
    Task<PagedResult<GarageEntity>> GetByUserIdAsync(long userId, CancellationToken cancellationToken = default);
    Task<PagedResult<GarageEntity>> GetAsync(CancellationToken cancellationToken = default);
}