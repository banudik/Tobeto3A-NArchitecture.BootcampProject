using Application.Features.BootcampLogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.BootcampLogs.Commands.Update;

public class UpdateBootcampLogCommand : IRequest<UpdatedBootcampLogResponse>, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int BootcampId { get; set; }
    public int ChapterId { get; set; }
    public Guid UserId { get; set; }
    public bool Status { get; set; }
    public Bootcamp Bootcamp { get; set; }
    public User User { get; set; }

    public class UpdateBootcampLogCommandHandler : IRequestHandler<UpdateBootcampLogCommand, UpdatedBootcampLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampLogRepository _bootcampLogRepository;
        private readonly BootcampLogBusinessRules _bootcampLogBusinessRules;

        public UpdateBootcampLogCommandHandler(IMapper mapper, IBootcampLogRepository bootcampLogRepository,
                                         BootcampLogBusinessRules bootcampLogBusinessRules)
        {
            _mapper = mapper;
            _bootcampLogRepository = bootcampLogRepository;
            _bootcampLogBusinessRules = bootcampLogBusinessRules;
        }

        public async Task<UpdatedBootcampLogResponse> Handle(UpdateBootcampLogCommand request, CancellationToken cancellationToken)
        {
            BootcampLog? bootcampLog = await _bootcampLogRepository.GetAsync(predicate: bl => bl.Id == request.Id, cancellationToken: cancellationToken);
            await _bootcampLogBusinessRules.BootcampLogShouldExistWhenSelected(bootcampLog);
            bootcampLog = _mapper.Map(request, bootcampLog);

            await _bootcampLogRepository.UpdateAsync(bootcampLog!);

            UpdatedBootcampLogResponse response = _mapper.Map<UpdatedBootcampLogResponse>(bootcampLog);
            return response;
        }
    }
}