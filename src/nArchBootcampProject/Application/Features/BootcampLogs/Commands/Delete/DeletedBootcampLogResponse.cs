using NArchitecture.Core.Application.Responses;

namespace Application.Features.BootcampLogs.Commands.Delete;

public class DeletedBootcampLogResponse : IResponse
{
    public int Id { get; set; }
}