using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Blacklists.Queries.GetList;

public class GetListBlacklistListItemDto : IDto
{
    public int Id { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public Guid ApplicantId { get; set; }
}
