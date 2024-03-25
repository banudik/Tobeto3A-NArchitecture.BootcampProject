using Application.Features.BootcampImages.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.BootcampImages.Rules;

public class BootcampImageBusinessRules : BaseBusinessRules
{
    private readonly IBootcampImageRepository _bootcampImageRepository;
    private readonly ILocalizationService _localizationService;

    public BootcampImageBusinessRules(IBootcampImageRepository bootcampImageRepository, ILocalizationService localizationService)
    {
        _bootcampImageRepository = bootcampImageRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BootcampImagesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BootcampImageShouldExistWhenSelected(BootcampImage? bootcampImage)
    {
        if (bootcampImage == null)
            await throwBusinessException(BootcampImagesBusinessMessages.BootcampImageNotExists);
    }

    public async Task BootcampImageIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        BootcampImage? bootcampImage = await _bootcampImageRepository.GetAsync(
            predicate: bi => bi.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BootcampImageShouldExistWhenSelected(bootcampImage);
    }
}
