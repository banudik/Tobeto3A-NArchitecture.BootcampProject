using FluentValidation;

namespace Application.Features.Announcements.Commands.Delete;

public class DeleteAnnouncementCommandValidator : AbstractValidator<DeleteAnnouncementCommand>
{
    public DeleteAnnouncementCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}