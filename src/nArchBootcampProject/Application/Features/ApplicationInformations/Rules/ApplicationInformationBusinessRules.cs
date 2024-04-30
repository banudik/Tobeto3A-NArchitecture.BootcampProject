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
    private readonly IApplicantRepository _applicantRepository;

    public ApplicationInformationBusinessRules(
        IApplicationInformationRepository applicationInformationRepository,
        ILocalizationService localizationService, IApplicantRepository applicantRepository
    )
    {
        _applicationInformationRepository = applicationInformationRepository;
        _localizationService = localizationService;
        _applicantRepository = applicantRepository;
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
    public async Task CheckApplicationInformationDuplicate(Guid ApplicantId, int BootcampId)
    {
        var item = await _applicationInformationRepository.GetAsync(predicate: p => p.ApplicantId == ApplicantId && p.BootcampId == BootcampId);
        if (item != null)
        {
            throw new BusinessException("You alread applied to this bootcamp!");
        }
    }

    public async Task CheckIfApplicantExist(Guid applicantId)
    {
        var item = await _applicantRepository.GetAsync(predicate: p => p.Id == applicantId);
        if (item == null)
        {
            throw new BusinessException("You are not an applicant!");
        }
    }
}
