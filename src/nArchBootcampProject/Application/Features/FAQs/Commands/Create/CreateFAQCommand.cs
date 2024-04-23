using Application.Features.FAQs.Constants;
using Application.Features.FAQs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.FAQs.Constants.FAQsOperationClaims;

namespace Application.Features.FAQs.Commands.Create;

public class CreateFAQCommand : IRequest<CreatedFAQResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Question { get; set; }
    public string Answer { get; set; }
    public string Category { get; set; }

    public string[] Roles => [Admin, Write, FAQsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetFAQs"];

    public class CreateFAQCommandHandler : IRequestHandler<CreateFAQCommand, CreatedFAQResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFAQRepository _fAQRepository;
        private readonly FAQBusinessRules _fAQBusinessRules;

        public CreateFAQCommandHandler(IMapper mapper, IFAQRepository fAQRepository,
                                         FAQBusinessRules fAQBusinessRules)
        {
            _mapper = mapper;
            _fAQRepository = fAQRepository;
            _fAQBusinessRules = fAQBusinessRules;
        }

        public async Task<CreatedFAQResponse> Handle(CreateFAQCommand request, CancellationToken cancellationToken)
        {
            FAQ fAQ = _mapper.Map<FAQ>(request);

            await _fAQRepository.AddAsync(fAQ);

            CreatedFAQResponse response = _mapper.Map<CreatedFAQResponse>(fAQ);
            return response;
        }
    }
}