using Application.Features.Bootcamps.Constants;
using Application.Features.Bootcamps.Constants;
using Application.Features.Bootcamps.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.Bootcamps.Constants.BootcampsOperationClaims;

namespace Application.Features.Bootcamps.Commands.Delete;

public class DeleteBootcampCommand
    : IRequest<DeletedBootcampResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, BootcampsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBootcamps"];

    public class DeleteBootcampCommandHandler : IRequestHandler<DeleteBootcampCommand, DeletedBootcampResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampRepository _bootcampRepository;
        private readonly BootcampBusinessRules _bootcampBusinessRules;
        private readonly IBootcampImageRepository _bootcampImageRepository;

        public DeleteBootcampCommandHandler(
            IMapper mapper,
            IBootcampRepository bootcampRepository,
            BootcampBusinessRules bootcampBusinessRules
,
            IBootcampImageRepository bootcampImageRepository)
        {
            _mapper = mapper;
            _bootcampRepository = bootcampRepository;
            _bootcampBusinessRules = bootcampBusinessRules;
            _bootcampImageRepository = bootcampImageRepository;
        }

        public async Task<DeletedBootcampResponse> Handle(DeleteBootcampCommand request, CancellationToken cancellationToken)
        {
            Bootcamp? bootcamp = await _bootcampRepository.GetAsync(
                predicate: b => b.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _bootcampBusinessRules.BootcampShouldExistWhenSelected(bootcamp);
            var image = await _bootcampImageRepository.GetAsync(predicate:p=>p.Id == bootcamp!.BootcampImageId);
            await _bootcampImageRepository.DeleteAsync(image!, permanent: true);
            await _bootcampRepository.DeleteAsync(bootcamp!,permanent:true);

            DeletedBootcampResponse response = _mapper.Map<DeletedBootcampResponse>(bootcamp);
            return response;
        }
    }
}
