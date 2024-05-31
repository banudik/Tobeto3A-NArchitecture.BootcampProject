using Application.Features.Certificates.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Certificates.Rules;

public class CertificateBusinessRules : BaseBusinessRules
{
    private readonly ICertificateRepository _certificateRepository;
    private readonly ILocalizationService _localizationService;

    public CertificateBusinessRules(ICertificateRepository certificateRepository, ILocalizationService localizationService)
    {
        _certificateRepository = certificateRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CertificatesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CertificateShouldExistWhenSelected(Certificate? certificate)
    {
        if (certificate == null)
            await throwBusinessException(CertificatesBusinessMessages.CertificateNotExists);
    }

    public async Task CertificateIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Certificate? certificate = await _certificateRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CertificateShouldExistWhenSelected(certificate);
    }

    public async Task CheckIfCertificateAlreadyCreated(Guid id,int bootcampId, CancellationToken cancellationToken)
    {

        Certificate? certificate = await _certificateRepository.GetAsync(
            predicate: c=>c.UserId == id && c.BootcampId == bootcampId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        if(certificate != null)
        {
            throw new BusinessException("You Already Created This Certificate!");
        }

    }
}