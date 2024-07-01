using Domain.Entities;
using MediatR;
using MimeKit;
using NArchitecture.Core.Mailing;

namespace Application.Features.Contact.SendEmail;
public class SendEmailCommand : IRequest<Unit>
{
    public ContactFormModel ContactForm { get; set; }

    public SendEmailCommand(ContactFormModel contactForm)
    {
        ContactForm = contactForm;
    }
}

public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, Unit>
{
    private readonly IMailService _mailService;

    public SendEmailCommandHandler(IMailService mailService)
    {
        _mailService = mailService;
    }

    public async Task<Unit> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
       

        // Email gövdesini oluştur
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Your Site", "codestormpair6@gmail.com"));
        message.To.Add(new MailboxAddress("Recipient", "codestormpair6@gmail.com")); // veya alıcı email adresi

        message.Subject = "Contact Us Form Submission";

        var body = new BodyBuilder
        {
            TextBody = $"Name: {request.ContactForm.Name}\nEmail: {request.ContactForm.Email}\nMessage: {request.ContactForm.Message}",
            HtmlBody = $"<p><strong>Name:</strong> {request.ContactForm.Name}</p>" +
                          $"<p><strong>Email:</strong> {request.ContactForm.Email}</p>" +
                          $"<p><strong>Message:</strong> {request.ContactForm.Message}</p>"
        };
        message.Body = body.ToMessageBody();

        // Mail nesnesini oluştur ve email gönder
        var mail = new Mail
        {
            Subject = message.Subject,
            TextBody = body.TextBody,
            HtmlBody = body.HtmlBody,
            ToList = new List<MailboxAddress> { new MailboxAddress("Recipient", "codestormpair6@gmail.com") } // Alıcının email adresini burada güncelleyin
        };

        await _mailService.SendEmailAsync(mail);

        return Unit.Value; // Unit olarak sonucu döndür
    }
}



