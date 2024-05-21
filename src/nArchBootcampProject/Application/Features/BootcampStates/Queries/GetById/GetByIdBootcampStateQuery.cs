using Application.Features.BootcampStates.Constants;
using Application.Features.BootcampStates.Rules;
using Application.Features.Employees.Constants;
using Application.Features.Instructors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using static Application.Features.BootcampStates.Constants.BootcampStatesOperationClaims;

namespace Application.Features.BootcampStates.Queries.GetById;

public class GetByIdBootcampStateQuery : IRequest<GetByIdBootcampStateResponse>, ISecuredRequest
{
    public short Id { get; set; }

    public string[] Roles => [Admin, Read, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public class GetByIdBootcampStateQueryHandler : IRequestHandler<GetByIdBootcampStateQuery, GetByIdBootcampStateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBootcampStateRepository _bootcampStateRepository;
        private readonly BootcampStateBusinessRules _bootcampStateBusinessRules;

        public GetByIdBootcampStateQueryHandler(
            IMapper mapper,
            IBootcampStateRepository bootcampStateRepository,
            BootcampStateBusinessRules bootcampStateBusinessRules
        )
        {
            _mapper = mapper;
            _bootcampStateRepository = bootcampStateRepository;
            _bootcampStateBusinessRules = bootcampStateBusinessRules;
        }

        public async Task<GetByIdBootcampStateResponse> Handle(
            GetByIdBootcampStateQuery request,
            CancellationToken cancellationToken
        )
        {
            BootcampState? bootcampState = await _bootcampStateRepository.GetAsync(
                predicate: bs => bs.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _bootcampStateBusinessRules.BootcampStateShouldExistWhenSelected(bootcampState);

            GetByIdBootcampStateResponse response = _mapper.Map<GetByIdBootcampStateResponse>(bootcampState);
            return response;
        }
    }
}
