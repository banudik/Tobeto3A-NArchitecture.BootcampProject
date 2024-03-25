using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IInstructorRepository : IAsyncRepository<Instructor, Guid>, IRepository<Instructor, Guid> { }
