using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBootcampLogRepository : IAsyncRepository<BootcampLog, int>, IRepository<BootcampLog, int>
{
}