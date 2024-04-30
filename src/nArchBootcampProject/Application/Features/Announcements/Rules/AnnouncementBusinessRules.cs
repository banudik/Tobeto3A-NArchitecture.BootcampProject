using Application.Features.Announcements.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Announcements.Rules;

public class AnnouncementBusinessRules : BaseBusinessRules
{
    private readonly IAnnouncementRepository _announcementRepository;
    private readonly ILocalizationService _localizationService;

    public AnnouncementBusinessRules(IAnnouncementRepository announcementRepository, ILocalizationService localizationService)
    {
        _announcementRepository = announcementRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AnnouncementsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AnnouncementShouldExistWhenSelected(Announcement? announcement)
    {
        if (announcement == null)
            await throwBusinessException(AnnouncementsBusinessMessages.AnnouncementNotExists);
    }

    public async Task AnnouncementIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Announcement? announcement = await _announcementRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AnnouncementShouldExistWhenSelected(announcement);
    }
}