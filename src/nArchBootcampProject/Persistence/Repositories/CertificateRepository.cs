using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CertificateRepository : EfRepositoryBase<Certificate, Guid, BaseDbContext>, ICertificateRepository
{
    public CertificateRepository(BaseDbContext context) : base(context)
    {
    }
}