using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.BootcampLogs.Queries.GetList;

public class GetListBootcampLogQuery : IRequest<GetListResponse<GetListBootcampLogListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListBootcampLogQueryHandler : IRequestHandler<GetListBootcampLogQuery, GetListResponse<GetListBootcampLogListItemDto>>
    {
        private readonly IBootcampLogRepository _bootcampLogRepository;
        private readonly IMapper _mapper;

        public GetListBootcampLogQueryHandler(IBootcampLogRepository bootcampLogRepository, IMapper mapper)
        {
            _bootcampLogRepository = bootcampLogRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBootcampLogListItemDto>> Handle(GetListBootcampLogQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BootcampLog> bootcampLogs = await _bootcampLogRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBootcampLogListItemDto> response = _mapper.Map<GetListResponse<GetListBootcampLogListItemDto>>(bootcampLogs);
            return response;
        }
    }
}