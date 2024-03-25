using Application.Features.Applicants.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.Applicants.Constants.ApplicantsOperationClaims;

namespace Application.Features.Applicants.Queries.GetList;

public class GetListApplicantQuery : IRequest<GetListResponse<GetListApplicantListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListApplicants({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetApplicants";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListApplicantQueryHandler
        : IRequestHandler<GetListApplicantQuery, GetListResponse<GetListApplicantListItemDto>>
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMapper _mapper;

        public GetListApplicantQueryHandler(IApplicantRepository applicantRepository, IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListApplicantListItemDto>> Handle(
            GetListApplicantQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<Applicant> applicants = await _applicantRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListApplicantListItemDto> response = _mapper.Map<GetListResponse<GetListApplicantListItemDto>>(
                applicants
            );
            return response;
        }
    }
}
