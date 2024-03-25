using Application.Features.Applicants.Constants;
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

namespace Application.Features.Applicants.Commands.Delete;

public class DeleteApplicantCommand
    : IRequest<DeletedApplicantResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, ApplicantsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetApplicants"];

    public class DeleteApplicantCommandHandler : IRequestHandler<DeleteApplicantCommand, DeletedApplicantResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicantRepository _applicantRepository;
        private readonly ApplicantBusinessRules _applicantBusinessRules;

        public DeleteApplicantCommandHandler(
            IMapper mapper,
            IApplicantRepository applicantRepository,
            ApplicantBusinessRules applicantBusinessRules
        )
        {
            _mapper = mapper;
            _applicantRepository = applicantRepository;
            _applicantBusinessRules = applicantBusinessRules;
        }

        public async Task<DeletedApplicantResponse> Handle(DeleteApplicantCommand request, CancellationToken cancellationToken)
        {
            Applicant? applicant = await _applicantRepository.GetAsync(
                predicate: a => a.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _applicantBusinessRules.ApplicantShouldExistWhenSelected(applicant);

            await _applicantRepository.DeleteAsync(applicant!);

            DeletedApplicantResponse response = _mapper.Map<DeletedApplicantResponse>(applicant);
            return response;
        }
    }
}
