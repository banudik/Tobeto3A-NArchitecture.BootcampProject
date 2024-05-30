using Application.Features.BootcampLogs.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BootcampLogs.Queries.GetListByUserId;
public class GetListBootcampLogByUserIdQuery : IRequest<GetListResponse<GetListBootcampLogListItemDto>>
{
    public Guid UserId { get; set; }
    public int BootcampId { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetListBootcampLogByUserIdQueryHandler : IRequestHandler<GetListBootcampLogByUserIdQuery, GetListResponse<GetListBootcampLogListItemDto>>
    {
        private readonly IBootcampLogRepository _bootcampLogRepository;
        private readonly IMapper _mapper;

        public GetListBootcampLogByUserIdQueryHandler(IBootcampLogRepository bootcampLogRepository, IMapper mapper)
        {
            _bootcampLogRepository = bootcampLogRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBootcampLogListItemDto>> Handle(GetListBootcampLogByUserIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BootcampLog> bootcampLogs = await _bootcampLogRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                predicate: x => x.UserId == request.UserId && x.BootcampId == request.BootcampId
            );

            GetListResponse<GetListBootcampLogListItemDto> response = _mapper.Map<GetListResponse<GetListBootcampLogListItemDto>>(bootcampLogs);
            return response;
        }
    }
}
