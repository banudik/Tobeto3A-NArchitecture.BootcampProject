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

namespace Application.Features.BootcampImages.Commands.Update;

public class UpdateBootcampImageCommand
    : IRequest<UpdatedBootcampImageResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public int Id { get; set; }
    public int BootcampId { get; set; }
    public string ImagePath { get; set; }

    public string[] Roles => [Admin, Write, BootcampImagesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBootcampImages"];

    public class UpdateBootcampImageCommandHandler : IRequestHandler<UpdateBootcampImageCommand, UpdatedBootcampImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampImageRepository _bootcampImageRepository;
        private readonly BootcampImageBusinessRules _bootcampImageBusinessRules;

        public UpdateBootcampImageCommandHandler(
            IMapper mapper,
            IBootcampImageRepository bootcampImageRepository,
            BootcampImageBusinessRules bootcampImageBusinessRules
        )
        {
            _mapper = mapper;
            _bootcampImageRepository = bootcampImageRepository;
            _bootcampImageBusinessRules = bootcampImageBusinessRules;
        }

        public async Task<UpdatedBootcampImageResponse> Handle(
            UpdateBootcampImageCommand request,
            CancellationToken cancellationToken
        )
        {
            BootcampImage? bootcampImage = await _bootcampImageRepository.GetAsync(
                predicate: bi => bi.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _bootcampImageBusinessRules.BootcampImageShouldExistWhenSelected(bootcampImage);
            bootcampImage = _mapper.Map(request, bootcampImage);

            await _bootcampImageRepository.UpdateAsync(bootcampImage!);

            UpdatedBootcampImageResponse response = _mapper.Map<UpdatedBootcampImageResponse>(bootcampImage);
            return response;
        }
    }
}
