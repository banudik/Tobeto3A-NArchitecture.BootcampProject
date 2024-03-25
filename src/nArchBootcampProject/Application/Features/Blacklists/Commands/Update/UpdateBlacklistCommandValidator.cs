using FluentValidation;

namespace Application.Features.Blacklists.Commands.Update;

public class UpdateBlacklistCommandValidator : AbstractValidator<UpdateBlacklistCommand>
{
    public UpdateBlacklistCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Reason).NotEmpty();
        RuleFor(c => c.Date).NotEmpty();
        RuleFor(c => c.ApplicantId).NotEmpty();
    }
}
