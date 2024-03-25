using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBootcampRepository : IAsyncRepository<Bootcamp, int>, IRepository<Bootcamp, int> { }
