using NArchitecture.Core.Application.Responses;

namespace Application.Features.Blacklists.Commands.Create;

public class CreatedBlacklistResponse : IResponse
{
    public int Id { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public int ApplicantId { get; set; }
}
