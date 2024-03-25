using Application.Features.ApplicationStateInformations.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.ApplicationStateInformations.Constants.ApplicationStateInformationsOperationClaims;

namespace Application.Features.ApplicationStateInformations.Queries.GetList;

public class GetListApplicationStateInformationQuery
    : IRequest<GetListResponse<GetListApplicationStateInformationListItemDto>>,
        ISecuredRequest,
        ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListApplicationStateInformations({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetApplicationStateInformations";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListApplicationStateInformationQueryHandler
        : IRequestHandler<GetListApplicationStateInformationQuery, GetListResponse<GetListApplicationStateInformationListItemDto>>
    {
        private readonly IApplicationStateInformationRepository _applicationStateInformationRepository;
        private readonly IMapper _mapper;

        public GetListApplicationStateInformationQueryHandler(
            IApplicationStateInformationRepository applicationStateInformationRepository,
            IMapper mapper
        )
        {
            _applicationStateInformationRepository = applicationStateInformationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListApplicationStateInformationListItemDto>> Handle(
            GetListApplicationStateInformationQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<ApplicationStateInformation> applicationStateInformations =
                await _applicationStateInformationRepository.GetListAsync(
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken
                );

            GetListResponse<GetListApplicationStateInformationListItemDto> response = _mapper.Map<
                GetListResponse<GetListApplicationStateInformationListItemDto>
            >(applicationStateInformations);
            return response;
        }
    }
}
