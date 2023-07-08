﻿using System.Linq.Expressions;
using Vehicle.Doctor.System.API.Infrastructure.Tables.BaseTables;
using Vehicle.Doctor.System.Common.Pagination;

namespace Vehicle.Doctor.System.API.Infrastructure.Tables;

public interface IReadDbRepository<T> where T : BaseTable
{
    DataDbContext Context { get; }

    Task<T?> FirstOrDefaultAsync(Guid id, CancellationToken cancellation = default);

    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellation = default);

    Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellation = default);

    Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellation = default);

    Task<PagedResult<T>> BrowseAsync<TQuery>(Expression<Func<T, bool>> predicate,
        TQuery query, CancellationToken cancellation = default) where TQuery : IPagedQuery;
    Task<PagedResult<T>> BrowseAsync<TQuery>(Expression<Func<T, bool>> predicate,
        Expression<Func<T, object>> order,
        TQuery query, CancellationToken cancellation = default) where TQuery : IPagedQuery;

    Task<PagedResult<T>> BrowseDescAsync<TQuery>(Expression<Func<T, bool>> predicate,
        Expression<Func<T, object>> order,
        TQuery query, CancellationToken cancellation = default) where TQuery : IPagedQuery;
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellation = default);
}