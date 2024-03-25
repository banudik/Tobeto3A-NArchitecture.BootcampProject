using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBootcampStateRepository : IAsyncRepository<BootcampState, short>, IRepository<BootcampState, short> { }
