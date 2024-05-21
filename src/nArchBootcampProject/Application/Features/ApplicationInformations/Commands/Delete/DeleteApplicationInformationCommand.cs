using Application.Features.ApplicationInformations.Constants;
using Application.Features.ApplicationInformations.Constants;
using Application.Features.ApplicationInformations.Rules;
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
using static Application.Features.ApplicationInformations.Constants.ApplicationInformationsOperationClaims;

namespace Application.Features.ApplicationInformations.Commands.Delete;

public class DeleteApplicationInformationCommand
    : IRequest<DeletedApplicationInformationResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, ApplicationInformationsOperationClaims.Delete, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetApplicationInformations"];

    public class DeleteApplicationInformationCommandHandler
        : IRequestHandler<DeleteApplicationInformationCommand, DeletedApplicationInformationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationInformationRepository _applicationInformationRepository;
        private readonly ApplicationInformationBusinessRules _applicationInformationBusinessRules;

        public DeleteApplicationInformationCommandHandler(
            IMapper mapper,
            IApplicationInformationRepository applicationInformationRepository,
            ApplicationInformationBusinessRules applicationInformationBusinessRules
        )
        {
            _mapper = mapper;
            _applicationInformationRepository = applicationInformationRepository;
            _applicationInformationBusinessRules = applicationInformationBusinessRules;
        }

        public async Task<DeletedApplicationInformationResponse> Handle(
            DeleteApplicationInformationCommand request,
            CancellationToken cancellationToken
        )
        {
            ApplicationInformation? applicationInformation = await _applicationInformationRepository.GetAsync(
                predicate: ai => ai.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _applicationInformationBusinessRules.ApplicationInformationShouldExistWhenSelected(applicationInformation);

            await _applicationInformationRepository.DeleteAsync(applicationInformation!);

            DeletedApplicationInformationResponse response = _mapper.Map<DeletedApplicationInformationResponse>(
                applicationInformation
            );
            return response;
        }
    }
}
