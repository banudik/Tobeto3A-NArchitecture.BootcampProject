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

namespace Application.Features.Chapters.Commands.Create;

public class CreateChapterCommand : IRequest<CreatedChapterResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Sort { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string Link { get; set; }
    public int BootcampId { get; set; }
    public int Time { get; set; }

    public string[] Roles => [Admin, Write, ChaptersOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetChapters"];

    public class CreateChapterCommandHandler : IRequestHandler<CreateChapterCommand, CreatedChapterResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChapterRepository _chapterRepository;
        private readonly ChapterBusinessRules _chapterBusinessRules;

        public CreateChapterCommandHandler(IMapper mapper, IChapterRepository chapterRepository,
                                         ChapterBusinessRules chapterBusinessRules)
        {
            _mapper = mapper;
            _chapterRepository = chapterRepository;
            _chapterBusinessRules = chapterBusinessRules;
        }

        public async Task<CreatedChapterResponse> Handle(CreateChapterCommand request, CancellationToken cancellationToken)
        {
            Chapter chapter = _mapper.Map<Chapter>(request);

            await _chapterRepository.AddAsync(chapter);

            CreatedChapterResponse response = _mapper.Map<CreatedChapterResponse>(chapter);
            return response;
        }
    }
}