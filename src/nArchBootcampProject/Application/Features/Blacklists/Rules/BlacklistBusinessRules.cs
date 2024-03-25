using Application.Features.Blacklists.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Blacklists.Rules;

public class BlacklistBusinessRules : BaseBusinessRules
{
    private readonly IBlacklistRepository _blacklistRepository;
    private readonly ILocalizationService _localizationService;

    public BlacklistBusinessRules(IBlacklistRepository blacklistRepository, ILocalizationService localizationService)
    {
        _blacklistRepository = blacklistRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BlacklistsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BlacklistShouldExistWhenSelected(Blacklist? blacklist)
    {
        if (blacklist == null)
            await throwBusinessException(BlacklistsBusinessMessages.BlacklistNotExists);
    }

    public async Task BlacklistIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Blacklist? blacklist = await _blacklistRepository.GetAsync(
            predicate: b => b.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BlacklistShouldExistWhenSelected(blacklist);
    }
}
