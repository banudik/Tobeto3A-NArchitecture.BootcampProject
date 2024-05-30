using Application.Features.BootcampLogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BootcampLogs.Queries.GetById;

public class GetByIdBootcampLogQuery : IRequest<GetByIdBootcampLogResponse>
{
    public int Id { get; set; }

    public class GetByIdBootcampLogQueryHandler : IRequestHandler<GetByIdBootcampLogQuery, GetByIdBootcampLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampLogRepository _bootcampLogRepository;
        private readonly BootcampLogBusinessRules _bootcampLogBusinessRules;

        public GetByIdBootcampLogQueryHandler(IMapper mapper, IBootcampLogRepository bootcampLogRepository, BootcampLogBusinessRules bootcampLogBusinessRules)
        {
            _mapper = mapper;
            _bootcampLogRepository = bootcampLogRepository;
            _bootcampLogBusinessRules = bootcampLogBusinessRules;
        }

        public async Task<GetByIdBootcampLogResponse> Handle(GetByIdBootcampLogQuery request, CancellationToken cancellationToken)
        {
            BootcampLog? bootcampLog = await _bootcampLogRepository.GetAsync(predicate: bl => bl.Id == request.Id, cancellationToken: cancellationToken);
            await _bootcampLogBusinessRules.BootcampLogShouldExistWhenSelected(bootcampLog);

            GetByIdBootcampLogResponse response = _mapper.Map<GetByIdBootcampLogResponse>(bootcampLog);
            return response;
        }
    }
}