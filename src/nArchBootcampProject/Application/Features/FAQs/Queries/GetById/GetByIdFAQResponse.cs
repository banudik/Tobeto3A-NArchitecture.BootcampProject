using NArchitecture.Core.Application.Responses;

namespace Application.Features.FAQs.Queries.GetById;

public class GetByIdFAQResponse : IResponse
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public string Category { get; set; }
}