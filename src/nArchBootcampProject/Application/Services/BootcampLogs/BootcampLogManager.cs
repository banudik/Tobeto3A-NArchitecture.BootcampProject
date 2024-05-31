using Application.Features.BootcampLogs.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BootcampLogs;

public class BootcampLogManager : IBootcampLogService
{
    private readonly IBootcampLogRepository _bootcampLogRepository;
    private readonly BootcampLogBusinessRules _bootcampLogBusinessRules;

    public BootcampLogManager(IBootcampLogRepository bootcampLogRepository, BootcampLogBusinessRules bootcampLogBusinessRules)
    {
        _bootcampLogRepository = bootcampLogRepository;
        _bootcampLogBusinessRules = bootcampLogBusinessRules;
    }

    public async Task<BootcampLog?> GetAsync(
        Expression<Func<BootcampLog, bool>> predicate,
        Func<IQueryable<BootcampLog>, IIncludableQueryable<BootcampLog, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BootcampLog? bootcampLog = await _bootcampLogRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bootcampLog;
    }

    public async Task<IPaginate<BootcampLog>?> GetListAsync(
        Expression<Func<BootcampLog, bool>>? predicate = null,
        Func<IQueryable<BootcampLog>, IOrderedQueryable<BootcampLog>>? orderBy = null,
        Func<IQueryable<BootcampLog>, IIncludableQueryable<BootcampLog, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BootcampLog> bootcampLogList = await _bootcampLogRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bootcampLogList;
    }

    public async Task<BootcampLog> AddAsync(BootcampLog bootcampLog)
    {
        BootcampLog addedBootcampLog = await _bootcampLogRepository.AddAsync(bootcampLog);

        return addedBootcampLog;
    }

    public async Task<BootcampLog> UpdateAsync(BootcampLog bootcampLog)
    {
        BootcampLog updatedBootcampLog = await _bootcampLogRepository.UpdateAsync(bootcampLog);

        return updatedBootcampLog;
    }

    public async Task<BootcampLog> DeleteAsync(BootcampLog bootcampLog, bool permanent = false)
    {
        BootcampLog deletedBootcampLog = await _bootcampLogRepository.DeleteAsync(bootcampLog);

        return deletedBootcampLog;
    }
}
