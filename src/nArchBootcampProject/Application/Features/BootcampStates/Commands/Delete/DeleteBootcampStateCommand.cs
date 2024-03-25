using Application.Features.BootcampStates.Constants;
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

namespace Application.Features.BootcampStates.Commands.Delete;

public class DeleteBootcampStateCommand
    : IRequest<DeletedBootcampStateResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public short Id { get; set; }

    public string[] Roles => [Admin, Write, BootcampStatesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBootcampStates"];

    public class DeleteBootcampStateCommandHandler : IRequestHandler<DeleteBootcampStateCommand, DeletedBootcampStateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampStateRepository _bootcampStateRepository;
        private readonly BootcampStateBusinessRules _bootcampStateBusinessRules;

        public DeleteBootcampStateCommandHandler(
            IMapper mapper,
            IBootcampStateRepository bootcampStateRepository,
            BootcampStateBusinessRules bootcampStateBusinessRules
        )
        {
            _mapper = mapper;
            _bootcampStateRepository = bootcampStateRepository;
            _bootcampStateBusinessRules = bootcampStateBusinessRules;
        }

        public async Task<DeletedBootcampStateResponse> Handle(
            DeleteBootcampStateCommand request,
            CancellationToken cancellationToken
        )
        {
            BootcampState? bootcampState = await _bootcampStateRepository.GetAsync(
                predicate: bs => bs.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _bootcampStateBusinessRules.BootcampStateShouldExistWhenSelected(bootcampState);

            await _bootcampStateRepository.DeleteAsync(bootcampState!);

            DeletedBootcampStateResponse response = _mapper.Map<DeletedBootcampStateResponse>(bootcampState);
            return response;
        }
    }
}
