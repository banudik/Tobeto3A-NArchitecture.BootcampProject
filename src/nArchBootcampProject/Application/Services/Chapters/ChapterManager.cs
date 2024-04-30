using Application.Features.Chapters.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Chapters;

public class ChapterManager : IChapterService
{
    private readonly IChapterRepository _chapterRepository;
    private readonly ChapterBusinessRules _chapterBusinessRules;

    public ChapterManager(IChapterRepository chapterRepository, ChapterBusinessRules chapterBusinessRules)
    {
        _chapterRepository = chapterRepository;
        _chapterBusinessRules = chapterBusinessRules;
    }

    public async Task<Chapter?> GetAsync(
        Expression<Func<Chapter, bool>> predicate,
        Func<IQueryable<Chapter>, IIncludableQueryable<Chapter, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Chapter? chapter = await _chapterRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return chapter;
    }

    public async Task<IPaginate<Chapter>?> GetListAsync(
        Expression<Func<Chapter, bool>>? predicate = null,
        Func<IQueryable<Chapter>, IOrderedQueryable<Chapter>>? orderBy = null,
        Func<IQueryable<Chapter>, IIncludableQueryable<Chapter, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Chapter> chapterList = await _chapterRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return chapterList;
    }

    public async Task<Chapter> AddAsync(Chapter chapter)
    {
        Chapter addedChapter = await _chapterRepository.AddAsync(chapter);

        return addedChapter;
    }

    public async Task<Chapter> UpdateAsync(Chapter chapter)
    {
        Chapter updatedChapter = await _chapterRepository.UpdateAsync(chapter);

        return updatedChapter;
    }

    public async Task<Chapter> DeleteAsync(Chapter chapter, bool permanent = false)
    {
        Chapter deletedChapter = await _chapterRepository.DeleteAsync(chapter);

        return deletedChapter;
    }
}
