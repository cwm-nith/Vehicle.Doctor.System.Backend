using Vehicle.Doctor.System.API.Applications.Entities.Posts;

namespace Vehicle.Doctor.System.API.Applications.IRepositories.Posts;

public interface IPostRepository
{
    Task<PostEntity> CreateAsync(PostEntity postEntity,CancellationToken cancellationToken = default);
}