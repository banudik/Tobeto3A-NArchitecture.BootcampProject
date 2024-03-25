using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IApplicantRepository : IAsyncRepository<Applicant, Guid>, IRepository<Applicant, Guid> { }
