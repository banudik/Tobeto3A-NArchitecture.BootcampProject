using Application.Features.Chapters.Constants;
using Application.Features.Chapters.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Chapters.Constants.ChaptersOperationClaims;
using Application.Features.Applicants.Constants;
using Application.Features.Employees.Constants;
using Application.Features.Instructors.Constants;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Chapters.Queries.GetById;

public class GetByIdChapterQuery : IRequest<GetByIdChapterResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read, ApplicantsOperationClaims.ApplicantRole, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public class GetByIdChapterQueryHandler : IRequestHandler<GetByIdChapterQuery, GetByIdChapterResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChapterRepository _chapterRepository;
        private readonly ChapterBusinessRules _chapterBusinessRules;

        public GetByIdChapterQueryHandler(IMapper mapper, IChapterRepository chapterRepository, ChapterBusinessRules chapterBusinessRules)
        {
            _mapper = mapper;
            _chapterRepository = chapterRepository;
            _chapterBusinessRules = chapterBusinessRules;
        }

        public async Task<GetByIdChapterResponse> Handle(GetByIdChapterQuery request, CancellationToken cancellationToken)
        {
            Chapter? chapter = await _chapterRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken,include:p=>p.Include(x=>x.Bootcamp));
            await _chapterBusinessRules.ChapterShouldExistWhenSelected(chapter);

            GetByIdChapterResponse response = _mapper.Map<GetByIdChapterResponse>(chapter);
            return response;
        }
    }
}