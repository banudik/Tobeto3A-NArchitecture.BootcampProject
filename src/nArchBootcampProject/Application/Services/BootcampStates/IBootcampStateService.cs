using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.BootcampStates;

public interface IBootcampStateService
{
    Task<BootcampState?> GetAsync(
        Expression<Func<BootcampState, bool>> predicate,
        Func<IQueryable<BootcampState>, IIncludableQueryable<BootcampState, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BootcampState>?> GetListAsync(
        Expression<Func<BootcampState, bool>>? predicate = null,
        Func<IQueryable<BootcampState>, IOrderedQueryable<BootcampState>>? orderBy = null,
        Func<IQueryable<BootcampState>, IIncludableQueryable<BootcampState, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BootcampState> AddAsync(BootcampState bootcampState);
    Task<BootcampState> UpdateAsync(BootcampState bootcampState);
    Task<BootcampState> DeleteAsync(BootcampState bootcampState, bool permanent = false);
}
