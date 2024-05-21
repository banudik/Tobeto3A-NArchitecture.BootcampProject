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

namespace Application.Features.ApplicationInformations.Commands.Update;

public class UpdateApplicationInformationCommand
    : IRequest<UpdatedApplicationInformationResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public int Id { get; set; }
    //public int ApplicantId { get; set; }
    //public int BootcampId { get; set; }
    public int ApplicationStateInformationId { get; set; }

    public string[] Roles => [Admin, Write, ApplicationInformationsOperationClaims.Update, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetApplicationInformations"];

    public class UpdateApplicationInformationCommandHandler
        : IRequestHandler<UpdateApplicationInformationCommand, UpdatedApplicationInformationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationInformationRepository _applicationInformationRepository;
        private readonly ApplicationInformationBusinessRules _applicationInformationBusinessRules;

        public UpdateApplicationInformationCommandHandler(
            IMapper mapper,
            IApplicationInformationRepository applicationInformationRepository,
            ApplicationInformationBusinessRules applicationInformationBusinessRules
        )
        {
            _mapper = mapper;
            _applicationInformationRepository = applicationInformationRepository;
            _applicationInformationBusinessRules = applicationInformationBusinessRules;
        }

        public async Task<UpdatedApplicationInformationResponse> Handle(
            UpdateApplicationInformationCommand request,
            CancellationToken cancellationToken
        )
        {
            ApplicationInformation? applicationInformation = await _applicationInformationRepository.GetAsync(
                predicate: ai => ai.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _applicationInformationBusinessRules.ApplicationInformationShouldExistWhenSelected(applicationInformation);
            applicationInformation = _mapper.Map(request, applicationInformation);

            await _applicationInformationRepository.UpdateAsync(applicationInformation!);

            UpdatedApplicationInformationResponse response = _mapper.Map<UpdatedApplicationInformationResponse>(
                applicationInformation
            );
            return response;
        }
    }
}
