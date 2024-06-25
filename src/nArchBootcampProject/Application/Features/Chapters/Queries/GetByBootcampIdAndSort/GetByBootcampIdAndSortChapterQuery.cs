using Application.Features.Applicants.Constants;
using Application.Features.Chapters.Constants;
using Application.Features.Chapters.Queries.GetById;
using Application.Features.Chapters.Queries.GetList;
using Application.Features.Chapters.Rules;
using Application.Features.Employees.Constants;
using Application.Features.Instructors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Chapters.Queries.GetByBootcampIdAndSort;
public class GetByBootcampIdAndSortChapterQuery : IRequest<GetByIdChapterResponse>, ISecuredRequest
{
    public int bootcampId { get; set; }
    public int Sort { get; set; }

    public string[] Roles => [ChaptersOperationClaims.Admin, ChaptersOperationClaims.Read, ApplicantsOperationClaims.ApplicantRole, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public class GetByBootcampIdAndSortChapterQueryHandler : IRequestHandler<GetByBootcampIdAndSortChapterQuery, GetByIdChapterResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChapterRepository _chapterRepository;
        private readonly ChapterBusinessRules _chapterBusinessRules;

        public GetByBootcampIdAndSortChapterQueryHandler(IMapper mapper, IChapterRepository chapterRepository, ChapterBusinessRules chapterBusinessRules)
        {
            _mapper = mapper;
            _chapterRepository = chapterRepository;
            _chapterBusinessRules = chapterBusinessRules;
        }

        public async Task<GetByIdChapterResponse> Handle(GetByBootcampIdAndSortChapterQuery request, CancellationToken cancellationToken)
        {
            Chapter? chapter = await _chapterRepository.GetAsync(predicate: c => c.BootcampId == request.bootcampId && c.Sort == request.Sort,
                cancellationToken: cancellationToken, include: p => p.Include(x => x.Bootcamp));
            await _chapterBusinessRules.ChapterShouldExistWhenSelected(chapter);

            GetByIdChapterResponse response = _mapper.Map<GetByIdChapterResponse>(chapter);
            return response;
        }
    }
}
