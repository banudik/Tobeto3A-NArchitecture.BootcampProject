using Application.Features.BootcampLogs.Constants;
using Application.Features.BootcampLogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.BootcampLogs.Commands.Delete;

public class DeleteBootcampLogCommand : IRequest<DeletedBootcampLogResponse>, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public class DeleteBootcampLogCommandHandler : IRequestHandler<DeleteBootcampLogCommand, DeletedBootcampLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampLogRepository _bootcampLogRepository;
        private readonly BootcampLogBusinessRules _bootcampLogBusinessRules;

        public DeleteBootcampLogCommandHandler(IMapper mapper, IBootcampLogRepository bootcampLogRepository,
                                         BootcampLogBusinessRules bootcampLogBusinessRules)
        {
            _mapper = mapper;
            _bootcampLogRepository = bootcampLogRepository;
            _bootcampLogBusinessRules = bootcampLogBusinessRules;
        }

        public async Task<DeletedBootcampLogResponse> Handle(DeleteBootcampLogCommand request, CancellationToken cancellationToken)
        {
            BootcampLog? bootcampLog = await _bootcampLogRepository.GetAsync(predicate: bl => bl.Id == request.Id, cancellationToken: cancellationToken);
            await _bootcampLogBusinessRules.BootcampLogShouldExistWhenSelected(bootcampLog);

            await _bootcampLogRepository.DeleteAsync(bootcampLog!);

            DeletedBootcampLogResponse response = _mapper.Map<DeletedBootcampLogResponse>(bootcampLog);
            return response;
        }
    }
}