using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IApplicationInformationRepository
    : IAsyncRepository<ApplicationInformation, int>,
        IRepository<ApplicationInformation, int> { }
