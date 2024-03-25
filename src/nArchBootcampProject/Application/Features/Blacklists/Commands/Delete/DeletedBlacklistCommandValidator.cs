using FluentValidation;

namespace Application.Features.Blacklists.Commands.Delete;

public class DeleteBlacklistCommandValidator : AbstractValidator<DeleteBlacklistCommand>
{
    public DeleteBlacklistCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
