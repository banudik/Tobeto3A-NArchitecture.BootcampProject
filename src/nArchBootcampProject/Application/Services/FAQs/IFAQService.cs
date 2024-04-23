using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FAQs;

public interface IFAQService
{
    Task<FAQ?> GetAsync(
        Expression<Func<FAQ, bool>> predicate,
        Func<IQueryable<FAQ>, IIncludableQueryable<FAQ, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<FAQ>?> GetListAsync(
        Expression<Func<FAQ, bool>>? predicate = null,
        Func<IQueryable<FAQ>, IOrderedQueryable<FAQ>>? orderBy = null,
        Func<IQueryable<FAQ>, IIncludableQueryable<FAQ, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<FAQ> AddAsync(FAQ fAQ);
    Task<FAQ> UpdateAsync(FAQ fAQ);
    Task<FAQ> DeleteAsync(FAQ fAQ, bool permanent = false);
}
