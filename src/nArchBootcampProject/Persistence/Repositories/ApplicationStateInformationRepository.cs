using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ApplicationStateInformationRepository
    : EfRepositoryBase<ApplicationStateInformation, short, BaseDbContext>,
        IApplicationStateInformationRepository
{
    public ApplicationStateInformationRepository(BaseDbContext context)
        : base(context) { }
}
