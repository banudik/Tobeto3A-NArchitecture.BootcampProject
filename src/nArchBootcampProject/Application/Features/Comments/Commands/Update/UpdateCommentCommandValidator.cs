using FluentValidation;

namespace Application.Features.Comments.Commands.Update;

public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
{
    public UpdateCommentCommandValidator()
    {
        //RuleFor(c => c.Id).NotEmpty();
        //RuleFor(c => c.Context).NotEmpty();
        //RuleFor(c => c.ChapterId).NotEmpty();
        //RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}