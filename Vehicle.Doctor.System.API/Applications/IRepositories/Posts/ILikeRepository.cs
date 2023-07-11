using System.Linq.Expressions;
using Vehicle.Doctor.System.API.Applications.Entities.Posts;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;

namespace Vehicle.Doctor.System.API.Applications.IRepositories.Posts;

public interface ILikeRepository
{
    Task<int> GetCountAsync(Expression<Func<LikeTable, bool>> predicate, CancellationToken cancellation = default);
    Task<bool> DeleteAsync(Expression<Func<LikeTable, bool>> predicate, CancellationToken cancellation = default);
    Task<LikeEntity> CreateAsync(LikeEntity entity, CancellationToken cancellation = default);
}