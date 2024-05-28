using Application.Features.Comments.Constants;
using Application.Features.Comments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Comments.Constants.CommentsOperationClaims;
using Application.Features.Employees.Constants;
using Application.Features.Instructors.Constants;

namespace Application.Features.Comments.Commands.Update;

public class UpdateCommentCommand : IRequest<UpdatedCommentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    //public string Context { get; set; }
    //public int ChapterId { get; set; }
    //public Guid UserId { get; set; }
    public bool Status { get; set; }

    public string[] Roles => [Admin, Write, CommentsOperationClaims.Update, InstructorsOperationClaims.InstructorRole, EmployeesOperationClaims.EmployeeRole];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetComments"];

    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, UpdatedCommentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        private readonly CommentBusinessRules _commentBusinessRules;

        public UpdateCommentCommandHandler(IMapper mapper, ICommentRepository commentRepository,
                                         CommentBusinessRules commentBusinessRules)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
            _commentBusinessRules = commentBusinessRules;
        }

        public async Task<UpdatedCommentResponse> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            Comment? comment = await _commentRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _commentBusinessRules.CommentShouldExistWhenSelected(comment);
            comment = _mapper.Map(request, comment);

            await _commentRepository.UpdateAsync(comment!);

            UpdatedCommentResponse response = _mapper.Map<UpdatedCommentResponse>(comment);
            return response;
        }
    }
}