using System.Web;
using Application.Features.Auth.Rules;
using Application.Services.AuthenticatorService;
using Application.Services.Repositories;
using Application.Services.UsersService;
using Domain.Entities;
using MediatR;
using MimeKit;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Security.Enums;

namespace Application.Features.Auth.Commands.EnableEmailAuthenticator;

public class EnableEmailAuthenticatorCommand : IRequest, ISecuredRequest
{
    public Guid UserId { get; set; }
    public string VerifyEmailUrlPrefix { get; set; }

    public string[] Roles => [];

    public EnableEmailAuthenticatorCommand()
    {
        VerifyEmailUrlPrefix = string.Empty;
    }

    public EnableEmailAuthenticatorCommand(Guid userId, string verifyEmailUrlPrefix)
    {
        UserId = userId;
        VerifyEmailUrlPrefix = verifyEmailUrlPrefix;
    }

    public class EnableEmailAuthenticatorCommandHandler : IRequestHandler<EnableEmailAuthenticatorCommand>
    {
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IAuthenticatorService _authenticatorService;
        private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
        private readonly IMailService _mailService;
        private readonly IUserService _userService;

        public EnableEmailAuthenticatorCommandHandler(
            IUserService userService,
            IEmailAuthenticatorRepository emailAuthenticatorRepository,
            IMailService mailService,
            AuthBusinessRules authBusinessRules,
            IAuthenticatorService authenticatorService
        )
        {
            _userService = userService;
            _emailAuthenticatorRepository = emailAuthenticatorRepository;
            _mailService = mailService;
            _authBusinessRules = authBusinessRules;
            _authenticatorService = authenticatorService;
        }

        public async Task Handle(EnableEmailAuthenticatorCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userService.GetAsync(
                predicate: u => u.Id == request.UserId,
                cancellationToken: cancellationToken
            );
            await _authBusinessRules.UserShouldBeExistsWhenSelected(user);
            await _authBusinessRules.UserShouldNotBeHaveAuthenticator(user!);

            user!.AuthenticatorType = AuthenticatorType.Email;
            await _userService.UpdateAsync(user);

            EmailAuthenticator emailAuthenticator = await _authenticatorService.CreateEmailAuthenticator(user);
            EmailAuthenticator addedEmailAuthenticator = await _emailAuthenticatorRepository.AddAsync(emailAuthenticator);

            var toEmailList = new List<MailboxAddress> { new(name: user.Email, user.Email) };

            string VerifyLink = $"{request.VerifyEmailUrlPrefix}?ActivationKey={HttpUtility.UrlEncode(addedEmailAuthenticator.ActivationKey)}";

            string htmlBody = @"
            <!DOCTYPE html>
            <html lang='en'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>MailVerify</title>
                <style>
                    body {
                        font-family: Arial, sans-serif;
                        background-color: #f4f4f4;
                        padding: 20px;
                    }
                    .container {
                        max-width: 600px;
                        margin: 0 auto;
                        background-color: #fff;
                        padding: 40px;
                        border-radius: 8px;
                        box-shadow: 0 0 10px rgba(0,0,0,0.1);
                    }
                    h1 {
                        text-align: center;
                        color: #333;
                    }

                    p {
                        font-size: 16px;
                        line-height: 1.6;
                        margin-bottom: 20px;
                        color: #555;
                    }
                    .button {
                        display: inline-block;
                        padding: 10px 20px;
                        background-color: #007bff;
                        color: #fff;
                        text-decoration: none;
                        border-radius: 5px;
                    }
                    .footer {
                        margin-top: 30px;
                        text-align: center;
                        color: #999;
                    }
                </style>
            </head>
            <body>
                <div class='container'>
                    <h1>MailVerify</h1>
                    <p>Merhaba, hesabınızı doğrulamak için aşağıdaki butona tıklayın:</p>
                    <a href='{VerifyLink}' class='button'>Hesabımı Doğrula</a>
                    <p>Eğer butona tıklamakta sorun yaşıyorsanız, aşağıdaki bağlantıyı tarayıcınızın adres çubuğuna yapıştırabilirsiniz:</p>
                    <p><a href='{VerifyLink}'>{VerifyLink}</a></p>
                    <p>Teşekkürler,<br>MailVerify Ekibi</p>
                </div>
                <div class='footer'>
                    <p>Bu bir otomatik e-postadır, lütfen yanıtlamayınız.</p>
                </div>
            </body>
            </html>";

            _mailService.SendMail(
                new Mail
                {
                    ToList = toEmailList,
                    Subject = "Hesabınızı Onaylayın - CodeStorm",
                    TextBody =
                        $"Link üzerinden hesabınızı doğrulayabilirsiniz: <a href=\"{request.VerifyEmailUrlPrefix}?ActivationKey={HttpUtility.UrlEncode(addedEmailAuthenticator.ActivationKey)}\">Doğrulama Linki</a>",
                    HtmlBody = htmlBody

                    //HtmlBody = $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n   <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>MailVerify</title>\r\n    <style>\r\n        body {{\r\n            font-family: Arial, sans-serif;\r\n            background-color: #f4f4f4;\r\n            padding: 20px;\r\n        }}\r\n        .container {{\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            background-color: #fff;\r\n            padding: 40px;\r\n            border-radius: 8px;\r\n            box-shadow: 0 0 10px rgba(0,0,0,0.1);\r\n        }}\r\n        h1 {{\r\n            text-align: center;\r\n            color: #333;\r\n        }}\r\n        p {{\r\n            font-size: 16px;\r\n            line-height: 1.6;\r\n            margin-bottom: 20px;\r\n            color: #555;\r\n        }}\r\n        .button {{\r\n            display: inline-block;\r\n            padding: 10px 20px;\r\n            background-color: #007bff;\r\n            color: #fff;\r\n            text-decoration: none;\r\n            border-radius: 5px;\r\n        }}\r\n        .footer {{\r\n            margin-top: 30px;\r\n            text-align: center;\r\n            color: #999;\r\n        }}\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <h1>MailVerify</h1>\r\n        " +
                    //$"<p>Merhaba, hesabınızı doğrulamak için aşağıdaki butona tıklayın:</p>\r\n        <a href=\"{request.VerifyEmailUrlPrefix}?ActivationKey={HttpUtility.UrlEncode(addedEmailAuthenticator.ActivationKey)}\" class=\"button\">Hesabımı Doğrula</a>\r\n        " +
                    //$"<p>Eğer butona tıklamakta sorun yaşıyorsanız, aşağıdaki bağlantıyı tarayıcınızın adres çubuğuna yapıştırabilirsiniz:</p>\r\n        <p><a href=\"{request.VerifyEmailUrlPrefix}?ActivationKey={HttpUtility.UrlEncode(addedEmailAuthenticator.ActivationKey)}\">www.mailverify.com/verify</a></p>\r\n        <p>Teşekkürler,<br>MailVerify Ekibi</p>\r\n    </div>\r\n    <div class=\"footer\">\r\n        " +
                    //$"<p>Bu bir otomatik e-postadır, lütfen yanıtlamayınız.</p>\r\n    </div>\r\n</body>\r\n</html>\r\n"

                }
            );
        }
    }
}
