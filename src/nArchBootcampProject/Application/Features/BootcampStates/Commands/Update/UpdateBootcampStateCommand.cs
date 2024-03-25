using Application.Features.BootcampStates.Constants;
using Application.Features.BootcampStates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.BootcampStates.Constants.BootcampStatesOperationClaims;

namespace Application.Features.BootcampStates.Commands.Update;

public class UpdateBootcampStateCommand
    : IRequest<UpdatedBootcampStateResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public short Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, BootcampStatesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBootcampStates"];

    public class UpdateBootcampStateCommandHandler : IRequestHandler<UpdateBootcampStateCommand, UpdatedBootcampStateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampStateRepository _bootcampStateRepository;
        private readonly BootcampStateBusinessRules _bootcampStateBusinessRules;

        public UpdateBootcampStateCommandHandler(
            IMapper mapper,
            IBootcampStateRepository bootcampStateRepository,
            BootcampStateBusinessRules bootcampStateBusinessRules
        )
        {
            _mapper = mapper;
            _bootcampStateRepository = bootcampStateRepository;
            _bootcampStateBusinessRules = bootcampStateBusinessRules;
        }

        public async Task<UpdatedBootcampStateResponse> Handle(
            UpdateBootcampStateCommand request,
            CancellationToken cancellationToken
        )
        {
            BootcampState? bootcampState = await _bootcampStateRepository.GetAsync(
                predicate: bs => bs.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _bootcampStateBusinessRules.BootcampStateShouldExistWhenSelected(bootcampState);
            bootcampState = _mapper.Map(request, bootcampState);

            await _bootcampStateRepository.UpdateAsync(bootcampState!);

            UpdatedBootcampStateResponse response = _mapper.Map<UpdatedBootcampStateResponse>(bootcampState);
            return response;
        }
    }
}
