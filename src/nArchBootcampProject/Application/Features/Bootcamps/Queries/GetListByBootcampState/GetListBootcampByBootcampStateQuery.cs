using Application.Features.Applicants.Constants;
using Application.Features.Bootcamps.Queries.GetList;
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
using static Application.Features.Bootcamps.Constants.BootcampsOperationClaims;

namespace Application.Features.Bootcamps.Queries.GetListByBootcampState;

public class GetListBootcampByBootcampStateQuery : IRequest<GetListResponse<GetListBootcampListItemDto>> , ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public short BootcampStateId { get; set; }
    public string[] Roles => [Admin, Read, ApplicantsOperationClaims.ApplicantRole, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBootcamps({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBootcamps";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBootcampByBootcampStateQueryHandler
        : IRequestHandler<GetListBootcampByBootcampStateQuery, GetListResponse<GetListBootcampListItemDto>>
    {
        private readonly IBootcampRepository _bootcampRepository;
        private readonly IMapper _mapper;

        public GetListBootcampByBootcampStateQueryHandler(IBootcampRepository bootcampRepository, IMapper mapper)
        {
            _bootcampRepository = bootcampRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBootcampListItemDto>> Handle(
            GetListBootcampByBootcampStateQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<Bootcamp> bootcamps = await _bootcampRepository.GetListAsync(
                predicate: x => x.BootcampStateId == request.BootcampStateId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                include: p => p.Include(x => x.Instructor).Include(p => p.BootcampState).Include(p => p.BootcampImage)
            );

            GetListResponse<GetListBootcampListItemDto> response = _mapper.Map<GetListResponse<GetListBootcampListItemDto>>(
                bootcamps
            );
            return response;
        }
    }
}