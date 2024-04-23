using Application.Features.FAQs.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FAQs;

public class FAQManager : IFAQService
{
    private readonly IFAQRepository _fAQRepository;
    private readonly FAQBusinessRules _fAQBusinessRules;

    public FAQManager(IFAQRepository fAQRepository, FAQBusinessRules fAQBusinessRules)
    {
        _fAQRepository = fAQRepository;
        _fAQBusinessRules = fAQBusinessRules;
    }

    public async Task<FAQ?> GetAsync(
        Expression<Func<FAQ, bool>> predicate,
        Func<IQueryable<FAQ>, IIncludableQueryable<FAQ, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        FAQ? fAQ = await _fAQRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return fAQ;
    }

    public async Task<IPaginate<FAQ>?> GetListAsync(
        Expression<Func<FAQ, bool>>? predicate = null,
        Func<IQueryable<FAQ>, IOrderedQueryable<FAQ>>? orderBy = null,
        Func<IQueryable<FAQ>, IIncludableQueryable<FAQ, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<FAQ> fAQList = await _fAQRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return fAQList;
    }

    public async Task<FAQ> AddAsync(FAQ fAQ)
    {
        FAQ addedFAQ = await _fAQRepository.AddAsync(fAQ);

        return addedFAQ;
    }

    public async Task<FAQ> UpdateAsync(FAQ fAQ)
    {
        FAQ updatedFAQ = await _fAQRepository.UpdateAsync(fAQ);

        return updatedFAQ;
    }

    public async Task<FAQ> DeleteAsync(FAQ fAQ, bool permanent = false)
    {
        FAQ deletedFAQ = await _fAQRepository.DeleteAsync(fAQ);

        return deletedFAQ;
    }
}
