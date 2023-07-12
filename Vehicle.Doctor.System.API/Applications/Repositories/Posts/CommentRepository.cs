using System.Linq.Expressions;
using Vehicle.Doctor.System.API.Applications.Entities.Posts;
using Vehicle.Doctor.System.API.Applications.IRepositories.Posts;
using Vehicle.Doctor.System.API.Infrastructure.Tables;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;
using Vehicle.Doctor.System.Common.Pagination;

namespace Vehicle.Doctor.System.API.Applications.Repositories.Posts;

public class CommentRepository : ICommentRepository
{
    private readonly IReadDbRepository<CommentTable> _readDbRepository;
    private readonly IWriteDbRepository<CommentTable> _writeDbRepository;

    public CommentRepository(IReadDbRepository<CommentTable> readDbRepository, IWriteDbRepository<CommentTable> writeDbRepository)
    {
        _readDbRepository = readDbRepository;
        _writeDbRepository = writeDbRepository;
    }

    public Task<int> GetCountAsync(Expression<Func<CommentTable, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return _readDbRepository.CountAsync(predicate, cancellationToken);
    }

    public async Task<PagedResult<CommentEntity>> GetAsync(Expression<Func<CommentTable, bool>> predicate, PagedQuery q, CancellationToken cancellation = default)
    {
        var data = await _readDbRepository.BrowseAsync(predicate, q, cancellation);
        return data.Map(i => i.ToEntity());
    }

    public async Task<CommentEntity> CreateAsync(CommentEntity entity, CancellationToken cancellationToken = default)
    {
        var data = await _writeDbRepository.AddAsync(entity.ToTable(), cancellationToken);
        return data.ToEntity();
    }

    public async Task<bool> DeleteAsync(Expression<Func<CommentTable, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var num = await _writeDbRepository.DeleteAsync(predicate, cancellationToken);
        return num > 0;
    }
}