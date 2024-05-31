using Application.Features.Blacklists.Constants;
using Application.Features.Blacklists.Constants;
using Application.Features.Blacklists.Rules;
using Application.Features.Employees.Constants;
using Application.Features.Instructors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.Blacklists.Constants.BlacklistsOperationClaims;

namespace Application.Features.Blacklists.Commands.Delete;

public class DeleteBlacklistCommand
    : IRequest<DeletedBlacklistResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, BlacklistsOperationClaims.Delete, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBlacklists"];

    public class DeleteBlacklistCommandHandler : IRequestHandler<DeleteBlacklistCommand, DeletedBlacklistResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlacklistRepository _blacklistRepository;
        private readonly BlacklistBusinessRules _blacklistBusinessRules;

        public DeleteBlacklistCommandHandler(
            IMapper mapper,
            IBlacklistRepository blacklistRepository,
            BlacklistBusinessRules blacklistBusinessRules
        )
        {
            _mapper = mapper;
            _blacklistRepository = blacklistRepository;
            _blacklistBusinessRules = blacklistBusinessRules;
        }

        public async Task<DeletedBlacklistResponse> Handle(DeleteBlacklistCommand request, CancellationToken cancellationToken)
        {
            Blacklist? blacklist = await _blacklistRepository.GetAsync(
                predicate: b => b.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _blacklistBusinessRules.BlacklistShouldExistWhenSelected(blacklist);

            await _blacklistRepository.DeleteAsync(blacklist,permanent:true);

            DeletedBlacklistResponse response = _mapper.Map<DeletedBlacklistResponse>(blacklist);
            return response;
        }
    }
}
