using Application.Features.ApplicationInformations.Constants;
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
using static Application.Features.ApplicationInformations.Constants.ApplicationInformationsOperationClaims;

namespace Application.Features.ApplicationInformations.Queries.GetList;

public class GetListApplicationInformationQuery
    : IRequest<GetListResponse<GetListApplicationInformationListItemDto>>,
        ISecuredRequest,
        ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListApplicationInformations({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetApplicationInformations";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListApplicationInformationQueryHandler
        : IRequestHandler<GetListApplicationInformationQuery, GetListResponse<GetListApplicationInformationListItemDto>>
    {
        private readonly IApplicationInformationRepository _applicationInformationRepository;
        private readonly IMapper _mapper;

        public GetListApplicationInformationQueryHandler(
            IApplicationInformationRepository applicationInformationRepository,
            IMapper mapper
        )
        {
            _applicationInformationRepository = applicationInformationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListApplicationInformationListItemDto>> Handle(
            GetListApplicationInformationQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<ApplicationInformation> applicationInformations = await _applicationInformationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                include:x=>x.Include(p=>p.Bootcamp).Include(p=>p.Applicant).Include(p=>p.ApplicationStateInformation)
            );

            GetListResponse<GetListApplicationInformationListItemDto> response = _mapper.Map<
                GetListResponse<GetListApplicationInformationListItemDto>
            >(applicationInformations);
            return response;
        }
    }
}
