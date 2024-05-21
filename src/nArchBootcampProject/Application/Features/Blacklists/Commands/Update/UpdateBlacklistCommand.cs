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

namespace Application.Features.Blacklists.Commands.Update;

public class UpdateBlacklistCommand
    : IRequest<UpdatedBlacklistResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public int Id { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public int ApplicantId { get; set; }

    public string[] Roles => [Admin, Write, BlacklistsOperationClaims.Update, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBlacklists"];

    public class UpdateBlacklistCommandHandler : IRequestHandler<UpdateBlacklistCommand, UpdatedBlacklistResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlacklistRepository _blacklistRepository;
        private readonly BlacklistBusinessRules _blacklistBusinessRules;

        public UpdateBlacklistCommandHandler(
            IMapper mapper,
            IBlacklistRepository blacklistRepository,
            BlacklistBusinessRules blacklistBusinessRules
        )
        {
            _mapper = mapper;
            _blacklistRepository = blacklistRepository;
            _blacklistBusinessRules = blacklistBusinessRules;
        }

        public async Task<UpdatedBlacklistResponse> Handle(UpdateBlacklistCommand request, CancellationToken cancellationToken)
        {
            Blacklist? blacklist = await _blacklistRepository.GetAsync(
                predicate: b => b.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _blacklistBusinessRules.BlacklistShouldExistWhenSelected(blacklist);
            blacklist = _mapper.Map(request, blacklist);

            await _blacklistRepository.UpdateAsync(blacklist!);

            UpdatedBlacklistResponse response = _mapper.Map<UpdatedBlacklistResponse>(blacklist);
            return response;
        }
    }
}
