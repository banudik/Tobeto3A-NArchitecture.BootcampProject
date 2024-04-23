using NArchitecture.Core.Application.Responses;

namespace Application.Features.FAQs.Commands.Create;

public class CreatedFAQResponse : IResponse
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public string Category { get; set; }
}