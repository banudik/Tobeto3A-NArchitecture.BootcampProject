using Application.Features.Applicants.Constants;
using Application.Features.Bootcamps.Constants;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Bootcamps.Queries.GetListByApplicationId;
public class GetListByApplicationQuery : IRequest<GetListResponse<GetListBootcampListItemDto>>, ISecuredRequest//, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public Guid ApplicantId { get; set; }
    public string[] Roles => [BootcampsOperationClaims.Admin, BootcampsOperationClaims.Read, ApplicantsOperationClaims.ApplicantRole, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBootcamps({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBootcamps";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListByApplicationQueryHandler
        : IRequestHandler<GetListByApplicationQuery, GetListResponse<GetListBootcampListItemDto>>
    {
        private readonly IBootcampRepository _bootcampRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationInformationRepository _applicationInformationRepository;

        public GetListByApplicationQueryHandler(IBootcampRepository bootcampRepository, IMapper mapper, IApplicationInformationRepository applicationInformationRepository)
        {
            _bootcampRepository = bootcampRepository;
            _mapper = mapper;
            _applicationInformationRepository = applicationInformationRepository;
        }

        public async Task<GetListResponse<GetListBootcampListItemDto>> Handle(
            GetListByApplicationQuery request,
            CancellationToken cancellationToken
        )
        {
            //Get Approved Applications
            var approvedApplications = await _applicationInformationRepository.GetListAsync(
                predicate: x => x.ApplicantId == request.ApplicantId && x.ApplicationStateInformationId == 2,
                index: 0,
                size: 1000,
                cancellationToken: cancellationToken
                );

            var approvedBootcampIds = approvedApplications.Items.Select(a => a.BootcampId).Distinct().ToList();

            IPaginate<Bootcamp> bootcamps = await _bootcampRepository.GetListAsync(
                predicate: x => approvedBootcampIds.Contains(x.Id),
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
