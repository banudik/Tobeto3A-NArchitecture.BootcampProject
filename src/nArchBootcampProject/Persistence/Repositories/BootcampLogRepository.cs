using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BootcampLogRepository : EfRepositoryBase<BootcampLog, int, BaseDbContext>, IBootcampLogRepository
{
    public BootcampLogRepository(BaseDbContext context) : base(context)
    {
    }
}