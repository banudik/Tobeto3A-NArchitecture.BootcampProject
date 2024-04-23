using Application.Features.Comments.Constants;
using Application.Features.Comments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Comments.Constants.CommentsOperationClaims;

namespace Application.Features.Comments.Queries.GetById;

public class GetByIdCommentQuery : IRequest<GetByIdCommentResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCommentQueryHandler : IRequestHandler<GetByIdCommentQuery, GetByIdCommentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        private readonly CommentBusinessRules _commentBusinessRules;

        public GetByIdCommentQueryHandler(IMapper mapper, ICommentRepository commentRepository, CommentBusinessRules commentBusinessRules)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
            _commentBusinessRules = commentBusinessRules;
        }

        public async Task<GetByIdCommentResponse> Handle(GetByIdCommentQuery request, CancellationToken cancellationToken)
        {
            Comment? comment = await _commentRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _commentBusinessRules.CommentShouldExistWhenSelected(comment);

            GetByIdCommentResponse response = _mapper.Map<GetByIdCommentResponse>(comment);
            return response;
        }
    }
}