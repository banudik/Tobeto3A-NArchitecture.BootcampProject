using Application.Features.BootcampLogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.BootcampLogs.Commands.Create;

public class CreateBootcampLogCommand : IRequest<CreatedBootcampLogResponse>, ILoggableRequest, ITransactionalRequest
{
    public int BootcampId { get; set; }
    public int ChapterId { get; set; }
    public Guid UserId { get; set; }
    public bool Status { get; set; }

    public class CreateBootcampLogCommandHandler : IRequestHandler<CreateBootcampLogCommand, CreatedBootcampLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampLogRepository _bootcampLogRepository;
        private readonly BootcampLogBusinessRules _bootcampLogBusinessRules;

        public CreateBootcampLogCommandHandler(IMapper mapper, IBootcampLogRepository bootcampLogRepository,
                                         BootcampLogBusinessRules bootcampLogBusinessRules)
        {
            _mapper = mapper;
            _bootcampLogRepository = bootcampLogRepository;
            _bootcampLogBusinessRules = bootcampLogBusinessRules;
        }

        public async Task<CreatedBootcampLogResponse> Handle(CreateBootcampLogCommand request, CancellationToken cancellationToken)
        {
            BootcampLog bootcampLog = _mapper.Map<BootcampLog>(request);

            await _bootcampLogRepository.AddAsync(bootcampLog);

            CreatedBootcampLogResponse response = _mapper.Map<CreatedBootcampLogResponse>(bootcampLog);
            return response;
        }
    }
}