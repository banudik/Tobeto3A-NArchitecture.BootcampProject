using NArchitecture.Core.Security.Attributes;

namespace Application.Features.Bootcamps.Constants;

[OperationClaimConstants]
public static class BootcampsOperationClaims
{
    private const string _section = "Bootcamps";

    public const string Admin = $"{_section}.Admin";

    public const string Read = $"{_section}.Read";
    public const string Write = $"{_section}.Write";

    public const string Create = $"{_section}.Create";
    public const string Update = $"{_section}.Update";
    public const string Delete = $"{_section}.Delete";
}
