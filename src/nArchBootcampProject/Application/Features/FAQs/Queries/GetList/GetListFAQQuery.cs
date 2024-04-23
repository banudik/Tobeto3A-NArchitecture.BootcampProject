using Application.Features.FAQs.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.FAQs.Constants.FAQsOperationClaims;

namespace Application.Features.FAQs.Queries.GetList;

public class GetListFAQQuery : IRequest<GetListResponse<GetListFAQListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListFAQs({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetFAQs";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListFAQQueryHandler : IRequestHandler<GetListFAQQuery, GetListResponse<GetListFAQListItemDto>>
    {
        private readonly IFAQRepository _fAQRepository;
        private readonly IMapper _mapper;

        public GetListFAQQueryHandler(IFAQRepository fAQRepository, IMapper mapper)
        {
            _fAQRepository = fAQRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListFAQListItemDto>> Handle(GetListFAQQuery request, CancellationToken cancellationToken)
        {
            IPaginate<FAQ> fAQs = await _fAQRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFAQListItemDto> response = _mapper.Map<GetListResponse<GetListFAQListItemDto>>(fAQs);
            return response;
        }
    }
}