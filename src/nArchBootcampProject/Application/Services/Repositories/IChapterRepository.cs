using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IChapterRepository : IAsyncRepository<Chapter, int>, IRepository<Chapter, int>
{
}