using Application.Features.Announcements.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Announcements;

public class AnnouncementManager : IAnnouncementService
{
    private readonly IAnnouncementRepository _announcementRepository;
    private readonly AnnouncementBusinessRules _announcementBusinessRules;

    public AnnouncementManager(IAnnouncementRepository announcementRepository, AnnouncementBusinessRules announcementBusinessRules)
    {
        _announcementRepository = announcementRepository;
        _announcementBusinessRules = announcementBusinessRules;
    }

    public async Task<Announcement?> GetAsync(
        Expression<Func<Announcement, bool>> predicate,
        Func<IQueryable<Announcement>, IIncludableQueryable<Announcement, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Announcement? announcement = await _announcementRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return announcement;
    }

    public async Task<IPaginate<Announcement>?> GetListAsync(
        Expression<Func<Announcement, bool>>? predicate = null,
        Func<IQueryable<Announcement>, IOrderedQueryable<Announcement>>? orderBy = null,
        Func<IQueryable<Announcement>, IIncludableQueryable<Announcement, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Announcement> announcementList = await _announcementRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return announcementList;
    }

    public async Task<Announcement> AddAsync(Announcement announcement)
    {
        Announcement addedAnnouncement = await _announcementRepository.AddAsync(announcement);

        return addedAnnouncement;
    }

    public async Task<Announcement> UpdateAsync(Announcement announcement)
    {
        Announcement updatedAnnouncement = await _announcementRepository.UpdateAsync(announcement);

        return updatedAnnouncement;
    }

    public async Task<Announcement> DeleteAsync(Announcement announcement, bool permanent = false)
    {
        Announcement deletedAnnouncement = await _announcementRepository.DeleteAsync(announcement);

        return deletedAnnouncement;
    }
}
