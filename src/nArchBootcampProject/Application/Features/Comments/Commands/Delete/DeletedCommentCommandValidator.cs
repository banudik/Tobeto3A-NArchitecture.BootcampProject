using FluentValidation;

namespace Application.Features.Comments.Commands.Delete;

public class DeleteCommentCommandValidator : AbstractValidator<DeleteCommentCommand>
{
    public DeleteCommentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}