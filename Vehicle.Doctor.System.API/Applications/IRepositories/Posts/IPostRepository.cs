﻿using System.Linq.Expressions;
using Vehicle.Doctor.System.API.Applications.Entities.Posts;
using Vehicle.Doctor.System.API.Applications.Features.Posts.Queries;
using Vehicle.Doctor.System.API.Infrastructure.Tables.Posts;
using Vehicle.Doctor.System.Common.Pagination;

namespace Vehicle.Doctor.System.API.Applications.IRepositories.Posts;

public interface IPostRepository
{
    Task<PagedResult<PostEntity>> GetAsync(PagedQuery q, CancellationToken cancellationToken = default);
    Task<PagedResult<PostEntity>> GetByUserAsync(GetPostByUserQuery q, CancellationToken cancellationToken = default);
    Task<PostEntity?> GetSinglePostAsync(Expression<Func<PostTable, bool>> predicate, CancellationToken cancellationToken = default);

    Task<PostEntity> CreateAsync(PostEntity postEntity, CancellationToken cancellationToken = default);
    Task<PostEntity> UpdateAsync(PostEntity postEntity, CancellationToken cancellationToken = default);
}