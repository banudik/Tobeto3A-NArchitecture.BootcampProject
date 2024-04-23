using Application.Features.Comments.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Comments;

public class CommentManager : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly CommentBusinessRules _commentBusinessRules;

    public CommentManager(ICommentRepository commentRepository, CommentBusinessRules commentBusinessRules)
    {
        _commentRepository = commentRepository;
        _commentBusinessRules = commentBusinessRules;
    }

    public async Task<Comment?> GetAsync(
        Expression<Func<Comment, bool>> predicate,
        Func<IQueryable<Comment>, IIncludableQueryable<Comment, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Comment? comment = await _commentRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return comment;
    }

    public async Task<IPaginate<Comment>?> GetListAsync(
        Expression<Func<Comment, bool>>? predicate = null,
        Func<IQueryable<Comment>, IOrderedQueryable<Comment>>? orderBy = null,
        Func<IQueryable<Comment>, IIncludableQueryable<Comment, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Comment> commentList = await _commentRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return commentList;
    }

    public async Task<Comment> AddAsync(Comment comment)
    {
        Comment addedComment = await _commentRepository.AddAsync(comment);

        return addedComment;
    }

    public async Task<Comment> UpdateAsync(Comment comment)
    {
        Comment updatedComment = await _commentRepository.UpdateAsync(comment);

        return updatedComment;
    }

    public async Task<Comment> DeleteAsync(Comment comment, bool permanent = false)
    {
        Comment deletedComment = await _commentRepository.DeleteAsync(comment);

        return deletedComment;
    }
}
