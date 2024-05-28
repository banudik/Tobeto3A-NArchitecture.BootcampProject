using Application.Features.Chapters.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Chapters.Constants.ChaptersOperationClaims;
using Application.Features.Applicants.Constants;
using Application.Features.Employees.Constants;
using Application.Features.Instructors.Constants;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Chapters.Queries.GetList;

public class GetListChapterQuery : IRequest<GetListResponse<GetListChapterListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read, ApplicantsOperationClaims.ApplicantRole, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListChapters({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetChapters";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListChapterQueryHandler : IRequestHandler<GetListChapterQuery, GetListResponse<GetListChapterListItemDto>>
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IMapper _mapper;

        public GetListChapterQueryHandler(IChapterRepository chapterRepository, IMapper mapper)
        {
            _chapterRepository = chapterRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListChapterListItemDto>> Handle(GetListChapterQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Chapter> chapters = await _chapterRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken,
                include: p => p.Include(x => x.Bootcamp)
            );

            GetListResponse<GetListChapterListItemDto> response = _mapper.Map<GetListResponse<GetListChapterListItemDto>>(chapters);
            return response;
        }
    }
}