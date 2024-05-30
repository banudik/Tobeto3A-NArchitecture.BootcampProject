using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BootcampLogs;

public interface IBootcampLogService
{
    Task<BootcampLog?> GetAsync(
        Expression<Func<BootcampLog, bool>> predicate,
        Func<IQueryable<BootcampLog>, IIncludableQueryable<BootcampLog, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BootcampLog>?> GetListAsync(
        Expression<Func<BootcampLog, bool>>? predicate = null,
        Func<IQueryable<BootcampLog>, IOrderedQueryable<BootcampLog>>? orderBy = null,
        Func<IQueryable<BootcampLog>, IIncludableQueryable<BootcampLog, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BootcampLog> AddAsync(BootcampLog bootcampLog);
    Task<BootcampLog> UpdateAsync(BootcampLog bootcampLog);
    Task<BootcampLog> DeleteAsync(BootcampLog bootcampLog, bool permanent = false);
}
