using System.Linq.Expressions;
using Vehicle.Doctor.System.API.Applications.Entities.Posts;
using Vehicle.Doctor.System.API.Applications.IRepositories.Posts;
using Vehicle.Doctor.System.API.Infrastructure.Tables;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;

namespace Vehicle.Doctor.System.API.Applications.Repositories.Posts;

public class LikeRepository : ILikeRepository
{
    private readonly IWriteDbRepository<LikeTable> _writeDbRepository;
    private readonly IReadDbRepository<LikeTable> _readDbRepository;

    public LikeRepository(IWriteDbRepository<LikeTable> writeDbRepository, IReadDbRepository<LikeTable> readDbRepository)
    {
        _writeDbRepository = writeDbRepository;
        _readDbRepository = readDbRepository;
    }

    public Task<int> GetCountAsync(Expression<Func<LikeTable, bool>> predicate, CancellationToken cancellation = default)
    {
        return _readDbRepository.CountAsync(predicate, cancellation);
    }

    public async Task<bool> DeleteAsync(Expression<Func<LikeTable, bool>> predicate, CancellationToken cancellation = default)
    {
        var num = await _writeDbRepository.DeleteAsync(predicate, cancellation);
        return num > 0;
    }

    public async Task<LikeEntity> CreateAsync(LikeEntity entity, CancellationToken cancellation = default)
    {
        LikeEntity? en;
        if (entity.Id > 0)
        {
            en = await GetLikeAsync(i =>
                i.Id == entity.Id && i.GarageId == entity.GarageId && i.PostId == entity.PostId && i.LikerId == entity.LikerId, cancellation);
        }
        else
        {
            en = await GetLikeAsync(i => i.GarageId == entity.GarageId && i.PostId == entity.PostId && i.LikerId == entity.LikerId, cancellation);
        }

        if (en != null)
        {
            en.DeletedAt = null;
            en.DeletedBy = null;
            await _writeDbRepository.UpdateAsync(en.ToTable(), cancellation);
            return en;
        }

        var data = await _writeDbRepository.AddAsync(entity.ToTable(), cancellation);
        return data.ToEntity();
    }

    private async Task<LikeEntity?> GetLikeAsync(Expression<Func<LikeTable, bool>> predicate, CancellationToken cancellation = default)
    {
        var data = await _readDbRepository.FirstOrDefaultAsync(predicate, cancellation);
        return data?.ToEntity();
    }
}