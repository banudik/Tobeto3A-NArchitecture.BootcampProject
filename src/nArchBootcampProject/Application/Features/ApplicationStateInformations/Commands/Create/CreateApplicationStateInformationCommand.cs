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

namespace Application.Features.ApplicationStateInformations.Commands.Create;

public class CreateApplicationStateInformationCommand
    : IRequest<CreatedApplicationStateInformationResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public string? Name { get; set; }

    public string[] Roles => [Admin, Write, ApplicationStateInformationsOperationClaims.Create, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetApplicationStateInformations"];

    public class CreateApplicationStateInformationCommandHandler
        : IRequestHandler<CreateApplicationStateInformationCommand, CreatedApplicationStateInformationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationStateInformationRepository _applicationStateInformationRepository;
        private readonly ApplicationStateInformationBusinessRules _applicationStateInformationBusinessRules;

        public CreateApplicationStateInformationCommandHandler(
            IMapper mapper,
            IApplicationStateInformationRepository applicationStateInformationRepository,
            ApplicationStateInformationBusinessRules applicationStateInformationBusinessRules
        )
        {
            _mapper = mapper;
            _applicationStateInformationRepository = applicationStateInformationRepository;
            _applicationStateInformationBusinessRules = applicationStateInformationBusinessRules;
        }

        public async Task<CreatedApplicationStateInformationResponse> Handle(
            CreateApplicationStateInformationCommand request,
            CancellationToken cancellationToken
        )
        {
            ApplicationStateInformation applicationStateInformation = _mapper.Map<ApplicationStateInformation>(request);

            await _applicationStateInformationRepository.AddAsync(applicationStateInformation);

            CreatedApplicationStateInformationResponse response = _mapper.Map<CreatedApplicationStateInformationResponse>(
                applicationStateInformation
            );
            return response;
        }
    }
}
