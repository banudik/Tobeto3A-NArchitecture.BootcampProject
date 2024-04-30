using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Comments;

public interface ICommentService
{
    Task<Comment?> GetAsync(
        Expression<Func<Comment, bool>> predicate,
        Func<IQueryable<Comment>, IIncludableQueryable<Comment, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Comment>?> GetListAsync(
        Expression<Func<Comment, bool>>? predicate = null,
        Func<IQueryable<Comment>, IOrderedQueryable<Comment>>? orderBy = null,
        Func<IQueryable<Comment>, IIncludableQueryable<Comment, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Comment> AddAsync(Comment comment);
    Task<Comment> UpdateAsync(Comment comment);
    Task<Comment> DeleteAsync(Comment comment, bool permanent = false);
}
