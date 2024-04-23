using Application.Features.FAQs.Constants;
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

namespace Application.Features.FAQs.Commands.Delete;

public class DeleteFAQCommand : IRequest<DeletedFAQResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, FAQsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetFAQs"];

    public class DeleteFAQCommandHandler : IRequestHandler<DeleteFAQCommand, DeletedFAQResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFAQRepository _fAQRepository;
        private readonly FAQBusinessRules _fAQBusinessRules;

        public DeleteFAQCommandHandler(IMapper mapper, IFAQRepository fAQRepository,
                                         FAQBusinessRules fAQBusinessRules)
        {
            _mapper = mapper;
            _fAQRepository = fAQRepository;
            _fAQBusinessRules = fAQBusinessRules;
        }

        public async Task<DeletedFAQResponse> Handle(DeleteFAQCommand request, CancellationToken cancellationToken)
        {
            FAQ? fAQ = await _fAQRepository.GetAsync(predicate: faq => faq.Id == request.Id, cancellationToken: cancellationToken);
            await _fAQBusinessRules.FAQShouldExistWhenSelected(fAQ);

            await _fAQRepository.DeleteAsync(fAQ!);

            DeletedFAQResponse response = _mapper.Map<DeletedFAQResponse>(fAQ);
            return response;
        }
    }
}