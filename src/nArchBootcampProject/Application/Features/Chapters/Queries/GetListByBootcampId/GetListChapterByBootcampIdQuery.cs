using Application.Features.Applicants.Constants;
using Application.Features.Chapters.Constants;
using Application.Features.Chapters.Queries.GetList;
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

namespace Application.Features.Chapters.Queries.GetListByBootcampId;
public class GetListChapterByBootcampIdQuery : IRequest<GetListResponse<GetListChapterListItemDto>>//, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public int BootcampId { get; set; }

    public string[] Roles => [ChaptersOperationClaims.Admin, ChaptersOperationClaims.Read, ApplicantsOperationClaims.ApplicantRole, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListChapters({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetChapters";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListChapterByBootcampIdQueryHandler : IRequestHandler<GetListChapterByBootcampIdQuery, GetListResponse<GetListChapterListItemDto>>
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IMapper _mapper;

        public GetListChapterByBootcampIdQueryHandler(IChapterRepository chapterRepository, IMapper mapper)
        {
            _chapterRepository = chapterRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListChapterListItemDto>> Handle(GetListChapterByBootcampIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Chapter> chapters = await _chapterRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                include: p => p.Include(x => x.Bootcamp),
                predicate:x=>x.BootcampId == request.BootcampId
            );

            GetListResponse<GetListChapterListItemDto> response = _mapper.Map<GetListResponse<GetListChapterListItemDto>>(chapters);
            return response;
        }
    }
}
