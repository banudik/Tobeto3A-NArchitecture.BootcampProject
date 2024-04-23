using NArchitecture.Core.Application.Responses;

namespace Application.Features.FAQs.Commands.Update;

public class UpdatedFAQResponse : IResponse
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public string Category { get; set; }
}