using Application.Features.FAQs.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.FAQs.Rules;

public class FAQBusinessRules : BaseBusinessRules
{
    private readonly IFAQRepository _fAQRepository;
    private readonly ILocalizationService _localizationService;

    public FAQBusinessRules(IFAQRepository fAQRepository, ILocalizationService localizationService)
    {
        _fAQRepository = fAQRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, FAQsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task FAQShouldExistWhenSelected(FAQ? fAQ)
    {
        if (fAQ == null)
            await throwBusinessException(FAQsBusinessMessages.FAQNotExists);
    }

    public async Task FAQIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        FAQ? fAQ = await _fAQRepository.GetAsync(
            predicate: faq => faq.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await FAQShouldExistWhenSelected(fAQ);
    }
}