using Application.Features.Blacklists.Constants;
using Application.Features.Blacklists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.Blacklists.Constants.BlacklistsOperationClaims;

namespace Application.Features.Blacklists.Commands.Create;

public class CreateBlacklistCommand
    : IRequest<CreatedBlacklistResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public int ApplicantId { get; set; }

    public string[] Roles => [Admin, Write, BlacklistsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBlacklists"];

    public class CreateBlacklistCommandHandler : IRequestHandler<CreateBlacklistCommand, CreatedBlacklistResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlacklistRepository _blacklistRepository;
        private readonly BlacklistBusinessRules _blacklistBusinessRules;

        public CreateBlacklistCommandHandler(
            IMapper mapper,
            IBlacklistRepository blacklistRepository,
            BlacklistBusinessRules blacklistBusinessRules
        )
        {
            _mapper = mapper;
            _blacklistRepository = blacklistRepository;
            _blacklistBusinessRules = blacklistBusinessRules;
        }

        public async Task<CreatedBlacklistResponse> Handle(CreateBlacklistCommand request, CancellationToken cancellationToken)
        {
            Blacklist blacklist = _mapper.Map<Blacklist>(request);

            await _blacklistRepository.AddAsync(blacklist);

            CreatedBlacklistResponse response = _mapper.Map<CreatedBlacklistResponse>(blacklist);
            return response;
        }
    }
}
