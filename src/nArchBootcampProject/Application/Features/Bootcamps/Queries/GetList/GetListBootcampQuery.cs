using Application.Features.Bootcamps.Constants;
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

namespace Application.Features.Bootcamps.Queries.GetList;

public class GetListBootcampQuery : IRequest<GetListResponse<GetListBootcampListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBootcamps({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBootcamps";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBootcampQueryHandler : IRequestHandler<GetListBootcampQuery, GetListResponse<GetListBootcampListItemDto>>
    {
        private readonly IBootcampRepository _bootcampRepository;
        private readonly IMapper _mapper;

        public GetListBootcampQueryHandler(IBootcampRepository bootcampRepository, IMapper mapper)
        {
            _bootcampRepository = bootcampRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBootcampListItemDto>> Handle(
            GetListBootcampQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<Bootcamp> bootcamps = await _bootcampRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                include:x=>x.Include(x=>x.Instructor).Include(x=>x.BootcampState).Include(x=>x.BootcampImage).Include(x=>x.Description)

            );

            GetListResponse<GetListBootcampListItemDto> response = _mapper.Map<GetListResponse<GetListBootcampListItemDto>>(
                bootcamps
            );
            return response;
        }
    }
}
