using Application.Features.ApplicationInformations.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.ApplicationInformations.Rules;

public class ApplicationInformationBusinessRules : BaseBusinessRules
{
    private readonly IApplicationInformationRepository _applicationInformationRepository;
    private readonly ILocalizationService _localizationService;

    public ApplicationInformationBusinessRules(
        IApplicationInformationRepository applicationInformationRepository,
        ILocalizationService localizationService
    )
    {
        _applicationInformationRepository = applicationInformationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(
            messageKey,
            ApplicationInformationsBusinessMessages.SectionName
        );
        throw new BusinessException(message);
    }

    public async Task ApplicationInformationShouldExistWhenSelected(ApplicationInformation? applicationInformation)
    {
        if (applicationInformation == null)
            await throwBusinessException(ApplicationInformationsBusinessMessages.ApplicationInformationNotExists);
    }

    public async Task ApplicationInformationIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ApplicationInformation? applicationInformation = await _applicationInformationRepository.GetAsync(
            predicate: ai => ai.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ApplicationInformationShouldExistWhenSelected(applicationInformation);
    }
}
