using Application.Features.Bootcamps.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Bootcamps.Rules;

public class BootcampBusinessRules : BaseBusinessRules
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly ILocalizationService _localizationService;

    public BootcampBusinessRules(IBootcampRepository bootcampRepository, ILocalizationService localizationService)
    {
        _bootcampRepository = bootcampRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BootcampsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BootcampShouldExistWhenSelected(Bootcamp? bootcamp)
    {
        if (bootcamp == null)
            await throwBusinessException(BootcampsBusinessMessages.BootcampNotExists);
    }

    public async Task BootcampIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Bootcamp? bootcamp = await _bootcampRepository.GetAsync(
            predicate: b => b.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BootcampShouldExistWhenSelected(bootcamp);
    }
}
