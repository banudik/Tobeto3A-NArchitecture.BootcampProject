using Application.Features.BootcampLogs.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.BootcampLogs.Rules;

public class BootcampLogBusinessRules : BaseBusinessRules
{
    private readonly IBootcampLogRepository _bootcampLogRepository;
    private readonly ILocalizationService _localizationService;

    public BootcampLogBusinessRules(IBootcampLogRepository bootcampLogRepository, ILocalizationService localizationService)
    {
        _bootcampLogRepository = bootcampLogRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BootcampLogsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BootcampLogShouldExistWhenSelected(BootcampLog? bootcampLog)
    {
        if (bootcampLog == null)
            await throwBusinessException(BootcampLogsBusinessMessages.BootcampLogNotExists);
    }

    public async Task BootcampLogIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        BootcampLog? bootcampLog = await _bootcampLogRepository.GetAsync(
            predicate: bl => bl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BootcampLogShouldExistWhenSelected(bootcampLog);
    }

    public async Task CheckIfLogAlreadyExist(Guid UserId,int bootcampId,int chapterId, CancellationToken cancellationToken)
    {
        BootcampLog? bootcampLog = await _bootcampLogRepository.GetAsync(
            predicate: bl => bl.UserId == UserId && bl.BootcampId == bootcampId && bl.ChapterId == chapterId,
            enableTracking: false,
            cancellationToken: cancellationToken
        );

        if (bootcampLog != null)
        {
            throw new BusinessException("Log already exist!");
        }
            
    }
}