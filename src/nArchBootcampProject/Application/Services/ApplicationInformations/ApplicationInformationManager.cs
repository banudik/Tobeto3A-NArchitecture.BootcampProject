using System.Linq.Expressions;
using Application.Features.ApplicationInformations.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.ApplicationInformations;

public class ApplicationInformationManager : IApplicationInformationService
{
    private readonly IApplicationInformationRepository _applicationInformationRepository;
    private readonly ApplicationInformationBusinessRules _applicationInformationBusinessRules;

    public ApplicationInformationManager(
        IApplicationInformationRepository applicationInformationRepository,
        ApplicationInformationBusinessRules applicationInformationBusinessRules
    )
    {
        _applicationInformationRepository = applicationInformationRepository;
        _applicationInformationBusinessRules = applicationInformationBusinessRules;
    }

    public async Task<ApplicationInformation?> GetAsync(
        Expression<Func<ApplicationInformation, bool>> predicate,
        Func<IQueryable<ApplicationInformation>, IIncludableQueryable<ApplicationInformation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ApplicationInformation? applicationInformation = await _applicationInformationRepository.GetAsync(
            predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return applicationInformation;
    }

    public async Task<IPaginate<ApplicationInformation>?> GetListAsync(
        Expression<Func<ApplicationInformation, bool>>? predicate = null,
        Func<IQueryable<ApplicationInformation>, IOrderedQueryable<ApplicationInformation>>? orderBy = null,
        Func<IQueryable<ApplicationInformation>, IIncludableQueryable<ApplicationInformation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ApplicationInformation> applicationInformationList = await _applicationInformationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return applicationInformationList;
    }

    public async Task<ApplicationInformation> AddAsync(ApplicationInformation applicationInformation)
    {
        ApplicationInformation addedApplicationInformation = await _applicationInformationRepository.AddAsync(
            applicationInformation
        );

        return addedApplicationInformation;
    }

    public async Task<ApplicationInformation> UpdateAsync(ApplicationInformation applicationInformation)
    {
        ApplicationInformation updatedApplicationInformation = await _applicationInformationRepository.UpdateAsync(
            applicationInformation
        );

        return updatedApplicationInformation;
    }

    public async Task<ApplicationInformation> DeleteAsync(ApplicationInformation applicationInformation, bool permanent = false)
    {
        ApplicationInformation deletedApplicationInformation = await _applicationInformationRepository.DeleteAsync(
            applicationInformation
        );

        return deletedApplicationInformation;
    }
}
