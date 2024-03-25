using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BootcampRepository : EfRepositoryBase<Bootcamp, int, BaseDbContext>, IBootcampRepository
{
    public BootcampRepository(BaseDbContext context)
        : base(context) { }
}
