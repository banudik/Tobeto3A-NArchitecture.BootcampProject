using NArchitecture.Core.Security.Attributes;

namespace Application.Features.Employees.Constants;

[OperationClaimConstants]
public static class EmployeesOperationClaims
{
    private const string _section = "Employees";

    public const string Admin = $"{_section}.Admin";

    public const string Read = $"{_section}.Read";
    public const string Write = $"{_section}.Write";

    public const string Create = $"{_section}.Create";
    public const string Update = $"{_section}.Update";
    public const string Delete = $"{_section}.Delete";
}
