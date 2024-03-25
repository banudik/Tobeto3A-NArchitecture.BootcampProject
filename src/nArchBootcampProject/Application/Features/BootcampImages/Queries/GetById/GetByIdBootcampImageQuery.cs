using Application.Features.BootcampImages.Constants;
using Application.Features.BootcampImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using static Application.Features.BootcampImages.Constants.BootcampImagesOperationClaims;

namespace Application.Features.BootcampImages.Queries.GetById;

public class GetByIdBootcampImageQuery : IRequest<GetByIdBootcampImageResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBootcampImageQueryHandler : IRequestHandler<GetByIdBootcampImageQuery, GetByIdBootcampImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampImageRepository _bootcampImageRepository;
        private readonly BootcampImageBusinessRules _bootcampImageBusinessRules;

        public GetByIdBootcampImageQueryHandler(
            IMapper mapper,
            IBootcampImageRepository bootcampImageRepository,
            BootcampImageBusinessRules bootcampImageBusinessRules
        )
        {
            _mapper = mapper;
            _bootcampImageRepository = bootcampImageRepository;
            _bootcampImageBusinessRules = bootcampImageBusinessRules;
        }

        public async Task<GetByIdBootcampImageResponse> Handle(
            GetByIdBootcampImageQuery request,
            CancellationToken cancellationToken
        )
        {
            BootcampImage? bootcampImage = await _bootcampImageRepository.GetAsync(
                predicate: bi => bi.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _bootcampImageBusinessRules.BootcampImageShouldExistWhenSelected(bootcampImage);

            GetByIdBootcampImageResponse response = _mapper.Map<GetByIdBootcampImageResponse>(bootcampImage);
            return response;
        }
    }
}
