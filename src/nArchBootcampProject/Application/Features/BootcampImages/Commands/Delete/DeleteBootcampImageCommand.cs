using Application.Features.BootcampImages.Constants;
using Application.Features.BootcampImages.Constants;
using Application.Features.BootcampImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.BootcampImages.Constants.BootcampImagesOperationClaims;

namespace Application.Features.BootcampImages.Commands.Delete;

public class DeleteBootcampImageCommand
    : IRequest<DeletedBootcampImageResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, BootcampImagesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBootcampImages"];

    public class DeleteBootcampImageCommandHandler : IRequestHandler<DeleteBootcampImageCommand, DeletedBootcampImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampImageRepository _bootcampImageRepository;
        private readonly BootcampImageBusinessRules _bootcampImageBusinessRules;

        public DeleteBootcampImageCommandHandler(
            IMapper mapper,
            IBootcampImageRepository bootcampImageRepository,
            BootcampImageBusinessRules bootcampImageBusinessRules
        )
        {
            _mapper = mapper;
            _bootcampImageRepository = bootcampImageRepository;
            _bootcampImageBusinessRules = bootcampImageBusinessRules;
        }

        public async Task<DeletedBootcampImageResponse> Handle(
            DeleteBootcampImageCommand request,
            CancellationToken cancellationToken
        )
        {
            BootcampImage? bootcampImage = await _bootcampImageRepository.GetAsync(
                predicate: bi => bi.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _bootcampImageBusinessRules.BootcampImageShouldExistWhenSelected(bootcampImage);

            await _bootcampImageRepository.DeleteAsync(bootcampImage!);

            DeletedBootcampImageResponse response = _mapper.Map<DeletedBootcampImageResponse>(bootcampImage);
            return response;
        }
    }
}
