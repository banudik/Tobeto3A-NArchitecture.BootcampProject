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

namespace Application.Features.FAQs.Commands.Update;

public class UpdateFAQCommand : IRequest<UpdatedFAQResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public string Category { get; set; }

    public string[] Roles => [Admin, Write, FAQsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetFAQs"];

    public class UpdateFAQCommandHandler : IRequestHandler<UpdateFAQCommand, UpdatedFAQResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFAQRepository _fAQRepository;
        private readonly FAQBusinessRules _fAQBusinessRules;

        public UpdateFAQCommandHandler(IMapper mapper, IFAQRepository fAQRepository,
                                         FAQBusinessRules fAQBusinessRules)
        {
            _mapper = mapper;
            _fAQRepository = fAQRepository;
            _fAQBusinessRules = fAQBusinessRules;
        }

        public async Task<UpdatedFAQResponse> Handle(UpdateFAQCommand request, CancellationToken cancellationToken)
        {
            FAQ? fAQ = await _fAQRepository.GetAsync(predicate: faq => faq.Id == request.Id, cancellationToken: cancellationToken);
            await _fAQBusinessRules.FAQShouldExistWhenSelected(fAQ);
            fAQ = _mapper.Map(request, fAQ);

            await _fAQRepository.UpdateAsync(fAQ!);

            UpdatedFAQResponse response = _mapper.Map<UpdatedFAQResponse>(fAQ);
            return response;
        }
    }
}