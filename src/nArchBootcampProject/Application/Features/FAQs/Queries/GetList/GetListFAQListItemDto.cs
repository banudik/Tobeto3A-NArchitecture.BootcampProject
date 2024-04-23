using NArchitecture.Core.Application.Dtos;

namespace Application.Features.FAQs.Queries.GetList;

public class GetListFAQListItemDto : IDto
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public string Category { get; set; }
}