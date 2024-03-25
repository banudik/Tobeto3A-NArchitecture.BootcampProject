using System.Linq.Expressions;
using Application.Features.BootcampStates.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.BootcampStates;

public class BootcampStateManager : IBootcampStateService
{
    private readonly IBootcampStateRepository _bootcampStateRepository;
    private readonly BootcampStateBusinessRules _bootcampStateBusinessRules;

    public BootcampStateManager(
        IBootcampStateRepository bootcampStateRepository,
        BootcampStateBusinessRules bootcampStateBusinessRules
    )
    {
        _bootcampStateRepository = bootcampStateRepository;
        _bootcampStateBusinessRules = bootcampStateBusinessRules;
    }

    public async Task<BootcampState?> GetAsync(
        Expression<Func<BootcampState, bool>> predicate,
        Func<IQueryable<BootcampState>, IIncludableQueryable<BootcampState, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BootcampState? bootcampState = await _bootcampStateRepository.GetAsync(
            predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bootcampState;
    }

    public async Task<IPaginate<BootcampState>?> GetListAsync(
        Expression<Func<BootcampState, bool>>? predicate = null,
        Func<IQueryable<BootcampState>, IOrderedQueryable<BootcampState>>? orderBy = null,
        Func<IQueryable<BootcampState>, IIncludableQueryable<BootcampState, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BootcampState> bootcampStateList = await _bootcampStateRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bootcampStateList;
    }

    public async Task<BootcampState> AddAsync(BootcampState bootcampState)
    {
        BootcampState addedBootcampState = await _bootcampStateRepository.AddAsync(bootcampState);

        return addedBootcampState;
    }

    public async Task<BootcampState> UpdateAsync(BootcampState bootcampState)
    {
        BootcampState updatedBootcampState = await _bootcampStateRepository.UpdateAsync(bootcampState);

        return updatedBootcampState;
    }

    public async Task<BootcampState> DeleteAsync(BootcampState bootcampState, bool permanent = false)
    {
        BootcampState deletedBootcampState = await _bootcampStateRepository.DeleteAsync(bootcampState);

        return deletedBootcampState;
    }
}
