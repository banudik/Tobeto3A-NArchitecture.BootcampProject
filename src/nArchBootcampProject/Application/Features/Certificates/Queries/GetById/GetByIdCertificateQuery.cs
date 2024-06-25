using Application.Features.Certificates.Constants;
using Application.Features.Certificates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Certificates.Constants.CertificatesOperationClaims;

namespace Application.Features.Certificates.Queries.GetById;

public class GetByIdCertificateQuery : IRequest<GetByIdCertificateResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public int BootcampId { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCertificateQueryHandler : IRequestHandler<GetByIdCertificateQuery, GetByIdCertificateResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICertificateRepository _certificateRepository;
        private readonly CertificateBusinessRules _certificateBusinessRules;

        public GetByIdCertificateQueryHandler(IMapper mapper, ICertificateRepository certificateRepository, CertificateBusinessRules certificateBusinessRules)
        {
            _mapper = mapper;
            _certificateRepository = certificateRepository;
            _certificateBusinessRules = certificateBusinessRules;
        }

        public async Task<GetByIdCertificateResponse> Handle(GetByIdCertificateQuery request, CancellationToken cancellationToken)
        {
            Certificate? certificate = await _certificateRepository.GetAsync(predicate: c => c.Id == request.Id && c.BootcampId == request.BootcampId, cancellationToken: cancellationToken);
            await _certificateBusinessRules.CertificateShouldExistWhenSelected(certificate);

            GetByIdCertificateResponse response = _mapper.Map<GetByIdCertificateResponse>(certificate);
            return response;
        }
    }
}