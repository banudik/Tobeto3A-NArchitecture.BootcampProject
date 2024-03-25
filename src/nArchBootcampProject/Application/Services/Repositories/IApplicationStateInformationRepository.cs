using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IApplicationStateInformationRepository
    : IAsyncRepository<ApplicationStateInformation, short>,
        IRepository<ApplicationStateInformation, short> { }
