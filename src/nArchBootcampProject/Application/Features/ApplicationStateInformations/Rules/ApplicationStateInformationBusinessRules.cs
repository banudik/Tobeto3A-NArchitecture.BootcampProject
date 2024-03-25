using Application.Features.ApplicationStateInformations.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.ApplicationStateInformations.Rules;

public class ApplicationStateInformationBusinessRules : BaseBusinessRules
{
    private readonly IApplicationStateInformationRepository _applicationStateInformationRepository;
    private readonly ILocalizationService _localizationService;

    public ApplicationStateInformationBusinessRules(
        IApplicationStateInformationRepository applicationStateInformationRepository,
        ILocalizationService localizationService
    )
    {
        _applicationStateInformationRepository = applicationStateInformationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(
            messageKey,
            ApplicationStateInformationsBusinessMessages.SectionName
        );
        throw new BusinessException(message);
    }

    public async Task ApplicationStateInformationShouldExistWhenSelected(ApplicationStateInformation? applicationStateInformation)
    {
        if (applicationStateInformation == null)
            await throwBusinessException(ApplicationStateInformationsBusinessMessages.ApplicationStateInformationNotExists);
    }

    public async Task ApplicationStateInformationIdShouldExistWhenSelected(short id, CancellationToken cancellationToken)
    {
        ApplicationStateInformation? applicationStateInformation = await _applicationStateInformationRepository.GetAsync(
            predicate: asi => asi.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ApplicationStateInformationShouldExistWhenSelected(applicationStateInformation);
    }
}
