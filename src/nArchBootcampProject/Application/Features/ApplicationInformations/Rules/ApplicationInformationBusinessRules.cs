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
    private readonly IBlacklistRepository _blacklistRepository;
    private readonly IBootcampRepository _bootcampRepository;

    public ApplicationInformationBusinessRules(
        IApplicationInformationRepository applicationInformationRepository,
        ILocalizationService localizationService, IApplicantRepository applicantRepository
, IBlacklistRepository blacklistRepository, IBootcampRepository bootcampRepository)
    {
        _applicationInformationRepository = applicationInformationRepository;
        _localizationService = localizationService;
        _applicantRepository = applicantRepository;
        _blacklistRepository = blacklistRepository;
        _bootcampRepository = bootcampRepository;
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

    public async Task CheckIfApplicantIsBlacklisted(Guid applicantId)
    {
        var item = await _blacklistRepository.GetAsync(predicate:p=>p.ApplicantId==applicantId);
        if(item != null)
        {
            throw new BusinessException(ApplicationInformationsBusinessMessages.ApplicantIsBlacklisted);
        }
    }

    public async Task CheckIfBootcampIsActive(int bootcampId)
    {
        var item = await _bootcampRepository.GetAsync(predicate: p => p.Id == bootcampId);
        if (item == null)
        {
            throw new BusinessException("Bootcamp does not exist!");
        }
        if(item.BootcampStateId != 1)
        {
            throw new BusinessException("Bootcamp application closed");
        }
    }
}
