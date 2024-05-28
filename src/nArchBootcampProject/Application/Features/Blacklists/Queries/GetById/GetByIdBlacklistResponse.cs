using NArchitecture.Core.Application.Responses;

namespace Application.Features.Blacklists.Queries.GetById;

public class GetByIdBlacklistResponse : IResponse
{
    public int Id { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public Guid ApplicantId { get; set; }
    public string ApplicantFirstName { get; set; }
    public string ApplicantLastName { get; set; }
    public string ApplicantEmail { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
