using Application.Features.Comments.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Comments.Rules;

public class CommentBusinessRules : BaseBusinessRules
{
    private readonly ICommentRepository _commentRepository;
    private readonly ILocalizationService _localizationService;

    public CommentBusinessRules(ICommentRepository commentRepository, ILocalizationService localizationService)
    {
        _commentRepository = commentRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CommentsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CommentShouldExistWhenSelected(Comment? comment)
    {
        if (comment == null)
            await throwBusinessException(CommentsBusinessMessages.CommentNotExists);
    }

    public async Task CommentIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Comment? comment = await _commentRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CommentShouldExistWhenSelected(comment);
    }
}