using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICommentRepository : IAsyncRepository<Comment, int>, IRepository<Comment, int>
{
}