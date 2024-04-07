using NArchitecture.Core.Application.Responses;

namespace Application.Features.Bootcamps.Queries.GetById;

public class GetByIdBootcampResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Guid InstructorId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public short BootcampStateId { get; set; }
    public string InstructorFirstName { get; set; }
    public string InstructorLastName { get; set; }
    public string BootcampStateName { get; set; }
    public string BootcampImageImagePath { get; set; }
}
