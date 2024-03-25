using Application.Features.ApplicationStateInformations.Constants;
using Application.Features.ApplicationStateInformations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.ApplicationStateInformations.Constants.ApplicationStateInformationsOperationClaims;

namespace Application.Features.ApplicationStateInformations.Commands.Update;

public class UpdateApplicationStateInformationCommand
    : IRequest<UpdatedApplicationStateInformationResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public short Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, ApplicationStateInformationsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetApplicationStateInformations"];

    public class UpdateApplicationStateInformationCommandHandler
        : IRequestHandler<UpdateApplicationStateInformationCommand, UpdatedApplicationStateInformationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationStateInformationRepository _applicationStateInformationRepository;
        private readonly ApplicationStateInformationBusinessRules _applicationStateInformationBusinessRules;

        public UpdateApplicationStateInformationCommandHandler(
            IMapper mapper,
            IApplicationStateInformationRepository applicationStateInformationRepository,
            ApplicationStateInformationBusinessRules applicationStateInformationBusinessRules
        )
        {
            _mapper = mapper;
            _applicationStateInformationRepository = applicationStateInformationRepository;
            _applicationStateInformationBusinessRules = applicationStateInformationBusinessRules;
        }

        public async Task<UpdatedApplicationStateInformationResponse> Handle(
            UpdateApplicationStateInformationCommand request,
            CancellationToken cancellationToken
        )
        {
            ApplicationStateInformation? applicationStateInformation = await _applicationStateInformationRepository.GetAsync(
                predicate: asi => asi.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _applicationStateInformationBusinessRules.ApplicationStateInformationShouldExistWhenSelected(
                applicationStateInformation
            );
            applicationStateInformation = _mapper.Map(request, applicationStateInformation);

            await _applicationStateInformationRepository.UpdateAsync(applicationStateInformation!);

            UpdatedApplicationStateInformationResponse response = _mapper.Map<UpdatedApplicationStateInformationResponse>(
                applicationStateInformation
            );
            return response;
        }
    }
}
