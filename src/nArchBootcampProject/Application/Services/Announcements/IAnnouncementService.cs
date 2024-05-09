using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Announcements;

public interface IAnnouncementService
{
    Task<Announcement?> GetAsync(
        Expression<Func<Announcement, bool>> predicate,
        Func<IQueryable<Announcement>, IIncludableQueryable<Announcement, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Announcement>?> GetListAsync(
        Expression<Func<Announcement, bool>>? predicate = null,
        Func<IQueryable<Announcement>, IOrderedQueryable<Announcement>>? orderBy = null,
        Func<IQueryable<Announcement>, IIncludableQueryable<Announcement, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Announcement> AddAsync(Announcement announcement);
    Task<Announcement> UpdateAsync(Announcement announcement);
    Task<Announcement> DeleteAsync(Announcement announcement, bool permanent = false);
}
