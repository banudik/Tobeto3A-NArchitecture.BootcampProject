using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationInformations.Commands.Update;

public class UpdatedApplicationInformationResponse : IResponse
{
    public int Id { get; set; }
    public Guid ApplicantId { get; set; }
    public string ApplicantFirstName { get; set; }
    public string ApplicantLastName { get; set; }
    public int BootcampId { get; set; }
    public string BootcampName { get; set; }
    public string ApplicationStateName { get; set; }
}
