using FluentValidation;

namespace Application.Features.Comments.Commands.Create;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(c => c.Context).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}