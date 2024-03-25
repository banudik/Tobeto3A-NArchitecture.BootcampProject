using Application.Features.ApplicationStateInformations.Constants;
using Application.Features.ApplicationStateInformations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using static Application.Features.ApplicationStateInformations.Constants.ApplicationStateInformationsOperationClaims;

namespace Application.Features.ApplicationStateInformations.Queries.GetById;

public class GetByIdApplicationStateInformationQuery : IRequest<GetByIdApplicationStateInformationResponse>, ISecuredRequest
{
    public short Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdApplicationStateInformationQueryHandler
        : IRequestHandler<GetByIdApplicationStateInformationQuery, GetByIdApplicationStateInformationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationStateInformationRepository _applicationStateInformationRepository;
        private readonly ApplicationStateInformationBusinessRules _applicationStateInformationBusinessRules;

        public GetByIdApplicationStateInformationQueryHandler(
            IMapper mapper,
            IApplicationStateInformationRepository applicationStateInformationRepository,
            ApplicationStateInformationBusinessRules applicationStateInformationBusinessRules
        )
        {
            _mapper = mapper;
            _applicationStateInformationRepository = applicationStateInformationRepository;
            _applicationStateInformationBusinessRules = applicationStateInformationBusinessRules;
        }

        public async Task<GetByIdApplicationStateInformationResponse> Handle(
            GetByIdApplicationStateInformationQuery request,
            CancellationToken cancellationToken
        )
        {
            ApplicationStateInformation? applicationStateInformation = await _applicationStateInformationRepository.GetAsync(
                predicate: asi => asi.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _applicationStateInformationBusinessRules.ApplicationStateInformationShouldExistWhenSelected(
                applicationStateInformation
            );

            GetByIdApplicationStateInformationResponse response = _mapper.Map<GetByIdApplicationStateInformationResponse>(
                applicationStateInformation
            );
            return response;
        }
    }
}
