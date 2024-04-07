using NArchitecture.Core.Application.Responses;

namespace Application.Features.Users.Commands.Update;

public class UpdatedUserResponse : IResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Status { get; set; }

    public UpdatedUserResponse()
    {
        UserName = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        NationalIdentity = string.Empty;
        Password = string.Empty;
        Email = string.Empty;
    }

    public UpdatedUserResponse(Guid ýd, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email, string password, bool status)
    {
        Id = ýd;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = email;
        Password = password;
        Status = status;
    }
}
