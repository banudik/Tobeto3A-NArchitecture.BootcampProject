using NArchitecture.Core.Application.Responses;

namespace Application.Features.BootcampLogs.Commands.Create;

public class CreatedBootcampLogResponse : IResponse
{
    public int Id { get; set; }
    public int BootcampId { get; set; }
    public int ChapterId { get; set; }
    public Guid UserId { get; set; }
    public bool Status { get; set; }
}