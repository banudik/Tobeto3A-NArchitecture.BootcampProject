using NArchitecture.Core.Application.Responses;

namespace Application.Features.Users.Commands.Create;

public class CreatedUserResponse : IResponse
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

    public CreatedUserResponse()
    {

        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
    }

    public CreatedUserResponse(Guid ýd, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email, string password, bool status)
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
