using System.Linq.Expressions;
using Application.Features.ApplicationStateInformations.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.ApplicationStateInformations;

public class ApplicationStateInformationManager : IApplicationStateInformationService
{
    private readonly IApplicationStateInformationRepository _applicationStateInformationRepository;
    private readonly ApplicationStateInformationBusinessRules _applicationStateInformationBusinessRules;

    public ApplicationStateInformationManager(
        IApplicationStateInformationRepository applicationStateInformationRepository,
        ApplicationStateInformationBusinessRules applicationStateInformationBusinessRules
    )
    {
        _applicationStateInformationRepository = applicationStateInformationRepository;
        _applicationStateInformationBusinessRules = applicationStateInformationBusinessRules;
    }

    public async Task<ApplicationStateInformation?> GetAsync(
        Expression<Func<ApplicationStateInformation, bool>> predicate,
        Func<IQueryable<ApplicationStateInformation>, IIncludableQueryable<ApplicationStateInformation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ApplicationStateInformation? applicationStateInformation = await _applicationStateInformationRepository.GetAsync(
            predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return applicationStateInformation;
    }

    public async Task<IPaginate<ApplicationStateInformation>?> GetListAsync(
        Expression<Func<ApplicationStateInformation, bool>>? predicate = null,
        Func<IQueryable<ApplicationStateInformation>, IOrderedQueryable<ApplicationStateInformation>>? orderBy = null,
        Func<IQueryable<ApplicationStateInformation>, IIncludableQueryable<ApplicationStateInformation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ApplicationStateInformation> applicationStateInformationList =
            await _applicationStateInformationRepository.GetListAsync(
                predicate,
                orderBy,
                include,
                index,
                size,
                withDeleted,
                enableTracking,
                cancellationToken
            );
        return applicationStateInformationList;
    }

    public async Task<ApplicationStateInformation> AddAsync(ApplicationStateInformation applicationStateInformation)
    {
        ApplicationStateInformation addedApplicationStateInformation = await _applicationStateInformationRepository.AddAsync(
            applicationStateInformation
        );

        return addedApplicationStateInformation;
    }

    public async Task<ApplicationStateInformation> UpdateAsync(ApplicationStateInformation applicationStateInformation)
    {
        ApplicationStateInformation updatedApplicationStateInformation = await _applicationStateInformationRepository.UpdateAsync(
            applicationStateInformation
        );

        return updatedApplicationStateInformation;
    }

    public async Task<ApplicationStateInformation> DeleteAsync(
        ApplicationStateInformation applicationStateInformation,
        bool permanent = false
    )
    {
        ApplicationStateInformation deletedApplicationStateInformation = await _applicationStateInformationRepository.DeleteAsync(
            applicationStateInformation
        );

        return deletedApplicationStateInformation;
    }
}
