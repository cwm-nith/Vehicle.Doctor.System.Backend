using Vehicle.Doctor.System.API.Applications.Entities.Posts;
using Vehicle.Doctor.System.API.Applications.IRepositories.Posts;
using Vehicle.Doctor.System.API.Infrastructure.Tables;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;

namespace Vehicle.Doctor.System.API.Applications.Repositories.Posts;

public class PostRepository : IPostRepository
{
    private readonly IWriteDbRepository<PostTable> _writeDbRepository;

    public PostRepository(IWriteDbRepository<PostTable> writeDbRepository)
    {
        _writeDbRepository = writeDbRepository;
    }

    public async Task<PostEntity> CreateAsync(PostEntity postEntity, CancellationToken cancellationToken = default)
    {
        var data = await _writeDbRepository.AddAsync(postEntity.ToTable(), cancellationToken);
        return data.ToEntity();
    }
}