using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.ApplicationStateInformations;

public interface IApplicationStateInformationService
{
    Task<ApplicationStateInformation?> GetAsync(
        Expression<Func<ApplicationStateInformation, bool>> predicate,
        Func<IQueryable<ApplicationStateInformation>, IIncludableQueryable<ApplicationStateInformation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ApplicationStateInformation>?> GetListAsync(
        Expression<Func<ApplicationStateInformation, bool>>? predicate = null,
        Func<IQueryable<ApplicationStateInformation>, IOrderedQueryable<ApplicationStateInformation>>? orderBy = null,
        Func<IQueryable<ApplicationStateInformation>, IIncludableQueryable<ApplicationStateInformation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ApplicationStateInformation> AddAsync(ApplicationStateInformation applicationStateInformation);
    Task<ApplicationStateInformation> UpdateAsync(ApplicationStateInformation applicationStateInformation);
    Task<ApplicationStateInformation> DeleteAsync(
        ApplicationStateInformation applicationStateInformation,
        bool permanent = false
    );
}
