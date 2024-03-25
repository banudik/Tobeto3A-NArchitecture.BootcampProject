using NArchitecture.Core.Application.Responses;

namespace Application.Features.Blacklists.Commands.Delete;

public class DeletedBlacklistResponse : IResponse
{
    public int Id { get; set; }
}
