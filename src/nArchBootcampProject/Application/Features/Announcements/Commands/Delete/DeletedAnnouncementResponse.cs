using NArchitecture.Core.Application.Responses;

namespace Application.Features.Announcements.Commands.Delete;

public class DeletedAnnouncementResponse : IResponse
{
    public int Id { get; set; }
}