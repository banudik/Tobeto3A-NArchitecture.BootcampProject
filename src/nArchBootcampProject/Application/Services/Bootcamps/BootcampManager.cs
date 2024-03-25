using System.Linq.Expressions;
using Application.Features.Bootcamps.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.Bootcamps;

public class BootcampManager : IBootcampService
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly BootcampBusinessRules _bootcampBusinessRules;

    public BootcampManager(IBootcampRepository bootcampRepository, BootcampBusinessRules bootcampBusinessRules)
    {
        _bootcampRepository = bootcampRepository;
        _bootcampBusinessRules = bootcampBusinessRules;
    }

    public async Task<Bootcamp?> GetAsync(
        Expression<Func<Bootcamp, bool>> predicate,
        Func<IQueryable<Bootcamp>, IIncludableQueryable<Bootcamp, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Bootcamp? bootcamp = await _bootcampRepository.GetAsync(
            predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bootcamp;
    }

    public async Task<IPaginate<Bootcamp>?> GetListAsync(
        Expression<Func<Bootcamp, bool>>? predicate = null,
        Func<IQueryable<Bootcamp>, IOrderedQueryable<Bootcamp>>? orderBy = null,
        Func<IQueryable<Bootcamp>, IIncludableQueryable<Bootcamp, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Bootcamp> bootcampList = await _bootcampRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bootcampList;
    }

    public async Task<Bootcamp> AddAsync(Bootcamp bootcamp)
    {
        Bootcamp addedBootcamp = await _bootcampRepository.AddAsync(bootcamp);

        return addedBootcamp;
    }

    public async Task<Bootcamp> UpdateAsync(Bootcamp bootcamp)
    {
        Bootcamp updatedBootcamp = await _bootcampRepository.UpdateAsync(bootcamp);

        return updatedBootcamp;
    }

    public async Task<Bootcamp> DeleteAsync(Bootcamp bootcamp, bool permanent = false)
    {
        Bootcamp deletedBootcamp = await _bootcampRepository.DeleteAsync(bootcamp);

        return deletedBootcamp;
    }
}
