using NArchitecture.Core.Application.Responses;

namespace Application.Features.Blacklists.Queries.GetById;

public class GetByIdBlacklistResponse : IResponse
{
    public int Id { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public int ApplicantId { get; set; }
}
