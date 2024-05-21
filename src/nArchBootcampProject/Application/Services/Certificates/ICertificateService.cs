using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Certificates;

public interface ICertificateService
{
    Task<Certificate?> GetAsync(
        Expression<Func<Certificate, bool>> predicate,
        Func<IQueryable<Certificate>, IIncludableQueryable<Certificate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Certificate>?> GetListAsync(
        Expression<Func<Certificate, bool>>? predicate = null,
        Func<IQueryable<Certificate>, IOrderedQueryable<Certificate>>? orderBy = null,
        Func<IQueryable<Certificate>, IIncludableQueryable<Certificate, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Certificate> AddAsync(Certificate certificate);
    Task<Certificate> UpdateAsync(Certificate certificate);
    Task<Certificate> DeleteAsync(Certificate certificate, bool permanent = false);
    Task GenerateCertificatePdf(Certificate certificate);
}
