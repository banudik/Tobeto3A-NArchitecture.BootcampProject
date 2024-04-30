using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AnnouncementRepository : EfRepositoryBase<Announcement, int, BaseDbContext>, IAnnouncementRepository
{
    public AnnouncementRepository(BaseDbContext context) : base(context)
    {
    }
}