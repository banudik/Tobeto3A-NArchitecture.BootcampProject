using Application.Features.Chapters.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Chapters.Rules;

public class ChapterBusinessRules : BaseBusinessRules
{
    private readonly IChapterRepository _chapterRepository;
    private readonly ILocalizationService _localizationService;

    public ChapterBusinessRules(IChapterRepository chapterRepository, ILocalizationService localizationService)
    {
        _chapterRepository = chapterRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ChaptersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ChapterShouldExistWhenSelected(Chapter? chapter)
    {
        if (chapter == null)
            await throwBusinessException(ChaptersBusinessMessages.ChapterNotExists);
    }

    public async Task ChapterIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Chapter? chapter = await _chapterRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ChapterShouldExistWhenSelected(chapter);
    }
}