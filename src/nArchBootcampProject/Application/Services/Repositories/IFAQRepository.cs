using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IFAQRepository : IAsyncRepository<FAQ, int>, IRepository<FAQ, int>
{
}