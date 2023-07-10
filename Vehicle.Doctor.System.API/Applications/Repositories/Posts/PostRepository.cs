using Microsoft.EntityFrameworkCore;
using Vehicle.Doctor.System.API.Applications.Entities.Posts;
using Vehicle.Doctor.System.API.Applications.Features.Posts.Queries;
using Vehicle.Doctor.System.API.Applications.IRepositories.Posts;
using Vehicle.Doctor.System.API.Infrastructure.Tables;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;
using Vehicle.Doctor.System.Common.Pagination;

namespace Vehicle.Doctor.System.API.Applications.Repositories.Posts;

public class PostRepository : IPostRepository
{
    private readonly IWriteDbRepository<PostTable> _writeDbRepository;
    private readonly IReadDbRepository<PostTable> _readDbRepository;

    public PostRepository(IWriteDbRepository<PostTable> writeDbRepository, IReadDbRepository<PostTable> readDbRepository)
    {
        _writeDbRepository = writeDbRepository;
        _readDbRepository = readDbRepository;
    }

    public async Task<PagedResult<PostEntity>> GetAsync(PagedQuery q, CancellationToken cancellationToken = default)
    {
        var context = _readDbRepository.Context;
        var posts = await context.Posts!.Include(i => i.Comments)
            .Include(i => i.Likes).PaginateAsync(q, cancellationToken);
        return posts.Map(i => i.ToEntity());
    }

    public async Task<PagedResult<PostEntity>> GetByUserAsync(GetPostByUserQuery q, CancellationToken cancellationToken = default)
    {
        var context = _readDbRepository.Context;
        var data = await context.Posts!.Where(i => i.PosterId == q.UserId).Include(i => i.Likes)
            .Include(i => i.Comments).PaginateAsync(q.Q, cancellationToken);
        return data.Map(i => i.ToEntity());
    }

    public async Task<PostEntity> CreateAsync(PostEntity postEntity, CancellationToken cancellationToken = default)
    {
        var data = await _writeDbRepository.AddAsync(postEntity.ToTable(), cancellationToken);
        return data.ToEntity();
    }
}