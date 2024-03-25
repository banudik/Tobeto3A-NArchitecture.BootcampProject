using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ApplicationInformationRepository
    : EfRepositoryBase<ApplicationInformation, int, BaseDbContext>,
        IApplicationInformationRepository
{
    public ApplicationInformationRepository(BaseDbContext context)
        : base(context) { }
}
