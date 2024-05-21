using Application.Features.Chapters.Constants;
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
using Application.Features.Employees.Constants;
using Application.Features.Instructors.Constants;

namespace Application.Features.Chapters.Commands.Delete;

public class DeleteChapterCommand : IRequest<DeletedChapterResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, ChaptersOperationClaims.Delete, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetChapters"];

    public class DeleteChapterCommandHandler : IRequestHandler<DeleteChapterCommand, DeletedChapterResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChapterRepository _chapterRepository;
        private readonly ChapterBusinessRules _chapterBusinessRules;

        public DeleteChapterCommandHandler(IMapper mapper, IChapterRepository chapterRepository,
                                         ChapterBusinessRules chapterBusinessRules)
        {
            _mapper = mapper;
            _chapterRepository = chapterRepository;
            _chapterBusinessRules = chapterBusinessRules;
        }

        public async Task<DeletedChapterResponse> Handle(DeleteChapterCommand request, CancellationToken cancellationToken)
        {
            Chapter? chapter = await _chapterRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _chapterBusinessRules.ChapterShouldExistWhenSelected(chapter);

            await _chapterRepository.DeleteAsync(chapter!);

            DeletedChapterResponse response = _mapper.Map<DeletedChapterResponse>(chapter);
            return response;
        }
    }
}