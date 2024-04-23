using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Chapters;

public interface IChapterService
{
    Task<Chapter?> GetAsync(
        Expression<Func<Chapter, bool>> predicate,
        Func<IQueryable<Chapter>, IIncludableQueryable<Chapter, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Chapter>?> GetListAsync(
        Expression<Func<Chapter, bool>>? predicate = null,
        Func<IQueryable<Chapter>, IOrderedQueryable<Chapter>>? orderBy = null,
        Func<IQueryable<Chapter>, IIncludableQueryable<Chapter, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Chapter> AddAsync(Chapter chapter);
    Task<Chapter> UpdateAsync(Chapter chapter);
    Task<Chapter> DeleteAsync(Chapter chapter, bool permanent = false);
}
