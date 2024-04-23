using Application.Features.FAQs.Constants;
using Application.Features.FAQs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.FAQs.Constants.FAQsOperationClaims;

namespace Application.Features.FAQs.Queries.GetById;

public class GetByIdFAQQuery : IRequest<GetByIdFAQResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdFAQQueryHandler : IRequestHandler<GetByIdFAQQuery, GetByIdFAQResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFAQRepository _fAQRepository;
        private readonly FAQBusinessRules _fAQBusinessRules;

        public GetByIdFAQQueryHandler(IMapper mapper, IFAQRepository fAQRepository, FAQBusinessRules fAQBusinessRules)
        {
            _mapper = mapper;
            _fAQRepository = fAQRepository;
            _fAQBusinessRules = fAQBusinessRules;
        }

        public async Task<GetByIdFAQResponse> Handle(GetByIdFAQQuery request, CancellationToken cancellationToken)
        {
            FAQ? fAQ = await _fAQRepository.GetAsync(predicate: faq => faq.Id == request.Id, cancellationToken: cancellationToken);
            await _fAQBusinessRules.FAQShouldExistWhenSelected(fAQ);

            GetByIdFAQResponse response = _mapper.Map<GetByIdFAQResponse>(fAQ);
            return response;
        }
    }
}