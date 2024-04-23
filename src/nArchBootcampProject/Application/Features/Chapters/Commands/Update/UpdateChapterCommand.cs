using Application.Features.Chapters.Constants;
using Application.Features.Chapters.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Chapters.Constants.ChaptersOperationClaims;

namespace Application.Features.Chapters.Commands.Update;

public class UpdateChapterCommand : IRequest<UpdatedChapterResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int Sort { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string Link { get; set; }
    public int BootcampId { get; set; }
    public int Time { get; set; }

    public string[] Roles => [Admin, Write, ChaptersOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetChapters"];

    public class UpdateChapterCommandHandler : IRequestHandler<UpdateChapterCommand, UpdatedChapterResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChapterRepository _chapterRepository;
        private readonly ChapterBusinessRules _chapterBusinessRules;

        public UpdateChapterCommandHandler(IMapper mapper, IChapterRepository chapterRepository,
                                         ChapterBusinessRules chapterBusinessRules)
        {
            _mapper = mapper;
            _chapterRepository = chapterRepository;
            _chapterBusinessRules = chapterBusinessRules;
        }

        public async Task<UpdatedChapterResponse> Handle(UpdateChapterCommand request, CancellationToken cancellationToken)
        {
            Chapter? chapter = await _chapterRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _chapterBusinessRules.ChapterShouldExistWhenSelected(chapter);
            chapter = _mapper.Map(request, chapter);

            await _chapterRepository.UpdateAsync(chapter!);

            UpdatedChapterResponse response = _mapper.Map<UpdatedChapterResponse>(chapter);
            return response;
        }
    }
}