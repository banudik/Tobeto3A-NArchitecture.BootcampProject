using NArchitecture.Core.Application.Responses;

namespace Application.Features.Users.Commands.Delete;

public class DeletedUserResponse : IResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
