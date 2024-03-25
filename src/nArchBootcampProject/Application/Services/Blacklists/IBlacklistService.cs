using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.Blacklists;

public interface IBlacklistService
{
    Task<Blacklist?> GetAsync(
        Expression<Func<Blacklist, bool>> predicate,
        Func<IQueryable<Blacklist>, IIncludableQueryable<Blacklist, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Blacklist>?> GetListAsync(
        Expression<Func<Blacklist, bool>>? predicate = null,
        Func<IQueryable<Blacklist>, IOrderedQueryable<Blacklist>>? orderBy = null,
        Func<IQueryable<Blacklist>, IIncludableQueryable<Blacklist, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Blacklist> AddAsync(Blacklist blacklist);
    Task<Blacklist> UpdateAsync(Blacklist blacklist);
    Task<Blacklist> DeleteAsync(Blacklist blacklist, bool permanent = false);
}
