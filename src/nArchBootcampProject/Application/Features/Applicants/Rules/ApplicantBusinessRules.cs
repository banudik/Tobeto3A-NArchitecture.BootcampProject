using Application.Features.Applicants.Constants;
using Application.Features.Users.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using NArchitecture.Core.Security.Hashing;

namespace Application.Features.Applicants.Rules;

public class ApplicantBusinessRules : BaseBusinessRules
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly ILocalizationService _localizationService;

    public ApplicantBusinessRules(IApplicantRepository applicantRepository, ILocalizationService localizationService)
    {
        _applicantRepository = applicantRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ApplicantsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ApplicantShouldExistWhenSelected(Applicant? applicant)
    {
        if (applicant == null)
            await throwBusinessException(ApplicantsBusinessMessages.ApplicantNotExists);
    }

    public async Task ApplicantIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Applicant? applicant = await _applicantRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ApplicantShouldExistWhenSelected(applicant);
    }

    public async Task ApplicantPasswordShouldBeMatched(User user, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            await throwBusinessException(UsersMessages.PasswordDontMatch);
    }
}
