using Application.Features.Blacklists.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.Blacklists.Constants.BlacklistsOperationClaims;

namespace Application.Features.Blacklists.Queries.GetList;

public class GetListBlacklistQuery : IRequest<GetListResponse<GetListBlacklistListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBlacklists({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBlacklists";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBlacklistQueryHandler
        : IRequestHandler<GetListBlacklistQuery, GetListResponse<GetListBlacklistListItemDto>>
    {
        private readonly IBlacklistRepository _blacklistRepository;
        private readonly IMapper _mapper;

        public GetListBlacklistQueryHandler(IBlacklistRepository blacklistRepository, IMapper mapper)
        {
            _blacklistRepository = blacklistRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBlacklistListItemDto>> Handle(
            GetListBlacklistQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<Blacklist> blacklists = await _blacklistRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBlacklistListItemDto> response = _mapper.Map<GetListResponse<GetListBlacklistListItemDto>>(
                blacklists
            );
            return response;
        }
    }
}
