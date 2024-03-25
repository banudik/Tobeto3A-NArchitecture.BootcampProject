using Application.Features.ApplicationInformations.Constants;
using Application.Features.ApplicationInformations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using static Application.Features.ApplicationInformations.Constants.ApplicationInformationsOperationClaims;

namespace Application.Features.ApplicationInformations.Queries.GetById;

public class GetByIdApplicationInformationQuery : IRequest<GetByIdApplicationInformationResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdApplicationInformationQueryHandler
        : IRequestHandler<GetByIdApplicationInformationQuery, GetByIdApplicationInformationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationInformationRepository _applicationInformationRepository;
        private readonly ApplicationInformationBusinessRules _applicationInformationBusinessRules;

        public GetByIdApplicationInformationQueryHandler(
            IMapper mapper,
            IApplicationInformationRepository applicationInformationRepository,
            ApplicationInformationBusinessRules applicationInformationBusinessRules
        )
        {
            _mapper = mapper;
            _applicationInformationRepository = applicationInformationRepository;
            _applicationInformationBusinessRules = applicationInformationBusinessRules;
        }

        public async Task<GetByIdApplicationInformationResponse> Handle(
            GetByIdApplicationInformationQuery request,
            CancellationToken cancellationToken
        )
        {
            ApplicationInformation? applicationInformation = await _applicationInformationRepository.GetAsync(
                predicate: ai => ai.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _applicationInformationBusinessRules.ApplicationInformationShouldExistWhenSelected(applicationInformation);

            GetByIdApplicationInformationResponse response = _mapper.Map<GetByIdApplicationInformationResponse>(
                applicationInformation
            );
            return response;
        }
    }
}
