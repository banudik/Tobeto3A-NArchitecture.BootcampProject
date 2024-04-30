using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAnnouncementRepository : IAsyncRepository<Announcement, int>, IRepository<Announcement, int>
{
}