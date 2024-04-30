using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ChapterRepository : EfRepositoryBase<Chapter, int, BaseDbContext>, IChapterRepository
{
    public ChapterRepository(BaseDbContext context) : base(context)
    {
    }
}