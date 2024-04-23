using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FAQRepository : EfRepositoryBase<FAQ, int, BaseDbContext>, IFAQRepository
{
    public FAQRepository(BaseDbContext context) : base(context)
    {
    }
}