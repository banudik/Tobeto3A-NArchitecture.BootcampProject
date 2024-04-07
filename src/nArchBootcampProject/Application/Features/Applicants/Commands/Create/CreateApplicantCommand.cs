using Application.Features.Applicants.Constants;
using Application.Features.Applicants.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.Applicants.Constants.ApplicantsOperationClaims;

namespace Application.Features.Applicants.Commands.Create;

public class CreateApplicantCommand
    : IRequest<CreatedApplicantResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string About { get; set; }

    public string[] Roles => [Admin, Write, ApplicantsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetApplicants"];

    public class CreateApplicantCommandHandler : IRequestHandler<CreateApplicantCommand, CreatedApplicantResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicantRepository _applicantRepository;
        private readonly ApplicantBusinessRules _applicantBusinessRules;

        public CreateApplicantCommandHandler(
            IMapper mapper,
            IApplicantRepository applicantRepository,
            ApplicantBusinessRules applicantBusinessRules
        )
        {
            _mapper = mapper;
            _applicantRepository = applicantRepository;
            _applicantBusinessRules = applicantBusinessRules;
        }

        public async Task<CreatedApplicantResponse> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
        {
            Applicant applicant = _mapper.Map<Applicant>(request);

            await _applicantRepository.AddAsync(applicant);

            CreatedApplicantResponse response = _mapper.Map<CreatedApplicantResponse>(applicant);
            return response;
        }
    }
}
