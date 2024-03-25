using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class InstructorRepository : EfRepositoryBase<Instructor, Guid, BaseDbContext>, IInstructorRepository
{
    public InstructorRepository(BaseDbContext context)
        : base(context) { }
}
