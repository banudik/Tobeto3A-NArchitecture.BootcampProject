using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBootcampImageRepository : IAsyncRepository<BootcampImage, int>, IRepository<BootcampImage, int> { }
