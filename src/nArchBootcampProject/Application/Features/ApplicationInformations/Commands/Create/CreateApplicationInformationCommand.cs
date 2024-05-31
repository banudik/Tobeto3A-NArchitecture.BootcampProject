using Application.Features.Applicants.Constants;
using Application.Features.ApplicationInformations.Constants;
using Application.Features.ApplicationInformations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.ApplicationInformations.Constants.ApplicationInformationsOperationClaims;

namespace Application.Features.ApplicationInformations.Commands.Create;

public class CreateApplicationInformationCommand
    : IRequest<CreatedApplicationInformationResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public Guid ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public short ApplicationStateInformationId { get; set; }

    public string[] Roles => [Admin, Write, ApplicationInformationsOperationClaims.Create, ApplicantsOperationClaims.ApplicantRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetApplicationInformations"];

    public class CreateApplicationInformationCommandHandler
        : IRequestHandler<CreateApplicationInformationCommand, CreatedApplicationInformationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationInformationRepository _applicationInformationRepository;
        private readonly ApplicationInformationBusinessRules _applicationInformationBusinessRules;

        public CreateApplicationInformationCommandHandler(
            IMapper mapper,
            IApplicationInformationRepository applicationInformationRepository,
            ApplicationInformationBusinessRules applicationInformationBusinessRules
        )
        {
            _mapper = mapper;
            _applicationInformationRepository = applicationInformationRepository;
            _applicationInformationBusinessRules = applicationInformationBusinessRules;
        }

        public async Task<CreatedApplicationInformationResponse> Handle(
            CreateApplicationInformationCommand request,
            CancellationToken cancellationToken
        )
        {
            ApplicationInformation applicationInformation = _mapper.Map<ApplicationInformation>(request);
            await _applicationInformationBusinessRules.CheckIfBootcampIsActive(request.BootcampId);
            await _applicationInformationBusinessRules.CheckApplicationInformationDuplicate(applicationInformation.ApplicantId, applicationInformation.BootcampId);
            await _applicationInformationBusinessRules.CheckIfApplicantIsBlacklisted(applicationInformation.ApplicantId);
            await _applicationInformationRepository.AddAsync(applicationInformation);

            CreatedApplicationInformationResponse response = _mapper.Map<CreatedApplicationInformationResponse>(
                applicationInformation
            );
            return response;
        }
    }
}
