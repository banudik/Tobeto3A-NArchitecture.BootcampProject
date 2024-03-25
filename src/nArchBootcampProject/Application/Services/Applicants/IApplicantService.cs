using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.Applicants;

public interface IApplicantService
{
    Task<Applicant?> GetAsync(
        Expression<Func<Applicant, bool>> predicate,
        Func<IQueryable<Applicant>, IIncludableQueryable<Applicant, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Applicant>?> GetListAsync(
        Expression<Func<Applicant, bool>>? predicate = null,
        Func<IQueryable<Applicant>, IOrderedQueryable<Applicant>>? orderBy = null,
        Func<IQueryable<Applicant>, IIncludableQueryable<Applicant, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Applicant> AddAsync(Applicant applicant);
    Task<Applicant> UpdateAsync(Applicant applicant);
    Task<Applicant> DeleteAsync(Applicant applicant, bool permanent = false);
}
