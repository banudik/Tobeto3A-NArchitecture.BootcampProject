using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.ApplicationInformations;

public interface IApplicationInformationService
{
    Task<ApplicationInformation?> GetAsync(
        Expression<Func<ApplicationInformation, bool>> predicate,
        Func<IQueryable<ApplicationInformation>, IIncludableQueryable<ApplicationInformation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ApplicationInformation>?> GetListAsync(
        Expression<Func<ApplicationInformation, bool>>? predicate = null,
        Func<IQueryable<ApplicationInformation>, IOrderedQueryable<ApplicationInformation>>? orderBy = null,
        Func<IQueryable<ApplicationInformation>, IIncludableQueryable<ApplicationInformation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ApplicationInformation> AddAsync(ApplicationInformation applicationInformation);
    Task<ApplicationInformation> UpdateAsync(ApplicationInformation applicationInformation);
    Task<ApplicationInformation> DeleteAsync(ApplicationInformation applicationInformation, bool permanent = false);
}
