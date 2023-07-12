using System.Linq.Expressions;
using Vehicle.Doctor.System.API.Applications.Entities.Posts;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;
using Vehicle.Doctor.System.Common.Pagination;

namespace Vehicle.Doctor.System.API.Applications.IRepositories.Posts;

public interface ICommentRepository
{
    Task<int> GetCountAsync(Expression<Func<CommentTable, bool>> predicate, CancellationToken cancellationToken = default);

    Task<PagedResult<CommentEntity>> GetAsync(Expression<Func<CommentTable, bool>> predicate, PagedQuery q,
        CancellationToken cancellation = default);
    Task<CommentEntity> CreateAsync(CommentEntity entity, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Expression<Func<CommentTable, bool>> predicate, CancellationToken cancellationToken = default);
}