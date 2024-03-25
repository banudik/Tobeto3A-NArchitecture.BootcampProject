using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BlacklistRepository : EfRepositoryBase<Blacklist, int, BaseDbContext>, IBlacklistRepository
{
    public BlacklistRepository(BaseDbContext context)
        : base(context) { }
}
