using Application.Features.BootcampImages.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.BootcampImages.Constants.BootcampImagesOperationClaims;

namespace Application.Features.BootcampImages.Queries.GetList;

public class GetListBootcampImageQuery
    : IRequest<GetListResponse<GetListBootcampImageListItemDto>>,
        ISecuredRequest,
        ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBootcampImages({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBootcampImages";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBootcampImageQueryHandler
        : IRequestHandler<GetListBootcampImageQuery, GetListResponse<GetListBootcampImageListItemDto>>
    {
        private readonly IBootcampImageRepository _bootcampImageRepository;
        private readonly IMapper _mapper;

        public GetListBootcampImageQueryHandler(IBootcampImageRepository bootcampImageRepository, IMapper mapper)
        {
            _bootcampImageRepository = bootcampImageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBootcampImageListItemDto>> Handle(
            GetListBootcampImageQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<BootcampImage> bootcampImages = await _bootcampImageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBootcampImageListItemDto> response = _mapper.Map<
                GetListResponse<GetListBootcampImageListItemDto>
            >(bootcampImages);
            return response;
        }
    }
}
