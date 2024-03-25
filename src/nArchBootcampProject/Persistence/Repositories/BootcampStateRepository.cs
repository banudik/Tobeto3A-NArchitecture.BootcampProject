using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BootcampStateRepository : EfRepositoryBase<BootcampState, short, BaseDbContext>, IBootcampStateRepository
{
    public BootcampStateRepository(BaseDbContext context)
        : base(context) { }
}
