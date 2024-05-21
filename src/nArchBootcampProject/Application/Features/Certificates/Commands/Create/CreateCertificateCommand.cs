using Application.Features.Certificates.Constants;
using Application.Features.Certificates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Certificates.Constants.CertificatesOperationClaims;
using Application.Services.Certificates;
using Application.Features.Bootcamps.Commands.Create;
using Application.Services.UsersService;
using Application.Features.Auth.Rules;
using NArchitecture.Core.Security.Entities;

namespace Application.Features.Certificates.Commands.Create;

public class CreateCertificateCommand : IRequest<CreatedCertificateResponse>//, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid UserId { get; set; }
    public CreateCertificateDto CreateCertificateDto { get; set; }

    public CreateCertificateCommand()
    {
        CreateCertificateDto = null!;
    }

    public CreateCertificateCommand(Guid userId,CreateCertificateDto createCertificateDto)
    {
        UserId = userId;
        CreateCertificateDto = createCertificateDto;
    }


    public class CreateCertificateCommandHandler : IRequestHandler<CreateCertificateCommand, CreatedCertificateResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICertificateRepository _certificateRepository;
        private readonly ICertificateService _certificateService;
        private readonly CertificateBusinessRules _certificateBusinessRules;
        private readonly IUserService _userService;
        private readonly AuthBusinessRules _authBusinessRules;

        public CreateCertificateCommandHandler(IMapper mapper, ICertificateRepository certificateRepository,
                                         CertificateBusinessRules certificateBusinessRules, ICertificateService certificateService)
        {
            _mapper = mapper;
            _certificateRepository = certificateRepository;
            _certificateBusinessRules = certificateBusinessRules;
            _certificateService = certificateService;
        }

        public async Task<CreatedCertificateResponse> Handle(CreateCertificateCommand request, CancellationToken cancellationToken)
        {
            //User? user = await _userService.GetAsync(
            //    predicate: u => u.Id == request.UserId,
            //    cancellationToken: cancellationToken
            //);


            //await _authBusinessRules.UserShouldBeExistsWhenSelected(user);
            //böyle bir bootcamp var mý kontrol et ilave olarak

            var certificate = new Certificate
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                BootcampId = request.CreateCertificateDto.BootcampId,
            };

            await _certificateRepository.AddAsync(certificate);

            //await _certificateRepository.UpdateAsync(cancellationToken);

            await _certificateService.GenerateCertificatePdf(certificate);

            CreatedCertificateResponse response = _mapper.Map<CreatedCertificateResponse>(certificate);
            return response;


            //CreatedCertificateResponse createdCertificateResponse = certificate.Id;
            //return certificate.Id;

        }
    }
}