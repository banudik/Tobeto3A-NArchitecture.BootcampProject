using NArchitecture.Core.Application.Responses;

namespace Application.Features.BootcampLogs.Queries.GetById;

public class GetByIdBootcampLogResponse : IResponse
{
    public int Id { get; set; }
    public int BootcampId { get; set; }
    public int ChapterId { get; set; }
    public Guid UserId { get; set; }
    public bool Status { get; set; }
}