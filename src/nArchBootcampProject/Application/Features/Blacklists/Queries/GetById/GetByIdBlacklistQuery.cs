using Application.Features.Blacklists.Constants;
using Application.Features.Blacklists.Rules;
using Application.Features.Employees.Constants;
using Application.Features.Instructors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using static Application.Features.Blacklists.Constants.BlacklistsOperationClaims;

namespace Application.Features.Blacklists.Queries.GetById;

public class GetByIdBlacklistQuery : IRequest<GetByIdBlacklistResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public class GetByIdBlacklistQueryHandler : IRequestHandler<GetByIdBlacklistQuery, GetByIdBlacklistResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlacklistRepository _blacklistRepository;
        private readonly BlacklistBusinessRules _blacklistBusinessRules;

        public GetByIdBlacklistQueryHandler(
            IMapper mapper,
            IBlacklistRepository blacklistRepository,
            BlacklistBusinessRules blacklistBusinessRules
        )
        {
            _mapper = mapper;
            _blacklistRepository = blacklistRepository;
            _blacklistBusinessRules = blacklistBusinessRules;
        }

        public async Task<GetByIdBlacklistResponse> Handle(GetByIdBlacklistQuery request, CancellationToken cancellationToken)
        {
            Blacklist? blacklist = await _blacklistRepository.GetAsync(
                predicate: b => b.Id == request.Id,
                cancellationToken: cancellationToken,
                include: p => p.Include(x => x.Applicant)
            );
            await _blacklistBusinessRules.BlacklistShouldExistWhenSelected(blacklist);

            GetByIdBlacklistResponse response = _mapper.Map<GetByIdBlacklistResponse>(blacklist);
            return response;
        }
    }
}
