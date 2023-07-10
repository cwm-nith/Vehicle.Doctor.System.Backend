using Vehicle.Doctor.System.API.Applications.Entities.Posts;
using Vehicle.Doctor.System.Common.Pagination;

namespace Vehicle.Doctor.System.API.Applications.IRepositories.Posts;

public interface IPostRepository
{
    Task<PagedResult<PostEntity>> GetAsync(PagedQuery q, CancellationToken cancellationToken = default);

    Task<PostEntity> CreateAsync(PostEntity postEntity,CancellationToken cancellationToken = default);
}