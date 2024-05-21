using Application.Features.ApplicationStateInformations.Constants;
using Application.Features.ApplicationStateInformations.Constants;
using Application.Features.ApplicationStateInformations.Rules;
using Application.Features.Employees.Constants;
using Application.Features.Instructors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.ApplicationStateInformations.Constants.ApplicationStateInformationsOperationClaims;

namespace Application.Features.ApplicationStateInformations.Commands.Delete;

public class DeleteApplicationStateInformationCommand
    : IRequest<DeletedApplicationStateInformationResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public short Id { get; set; }

    public string[] Roles => [Admin, Write, ApplicationStateInformationsOperationClaims.Delete, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetApplicationStateInformations"];

    public class DeleteApplicationStateInformationCommandHandler
        : IRequestHandler<DeleteApplicationStateInformationCommand, DeletedApplicationStateInformationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationStateInformationRepository _applicationStateInformationRepository;
        private readonly ApplicationStateInformationBusinessRules _applicationStateInformationBusinessRules;

        public DeleteApplicationStateInformationCommandHandler(
            IMapper mapper,
            IApplicationStateInformationRepository applicationStateInformationRepository,
            ApplicationStateInformationBusinessRules applicationStateInformationBusinessRules
        )
        {
            _mapper = mapper;
            _applicationStateInformationRepository = applicationStateInformationRepository;
            _applicationStateInformationBusinessRules = applicationStateInformationBusinessRules;
        }

        public async Task<DeletedApplicationStateInformationResponse> Handle(
            DeleteApplicationStateInformationCommand request,
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

            await _applicationStateInformationRepository.DeleteAsync(applicationStateInformation!);

            DeletedApplicationStateInformationResponse response = _mapper.Map<DeletedApplicationStateInformationResponse>(
                applicationStateInformation
            );
            return response;
        }
    }
}
