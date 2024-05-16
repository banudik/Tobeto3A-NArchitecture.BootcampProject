using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Application.Services.UsersService;
using Domain.Entities;
using MediatR;
using MimeKit;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Security.JWT;


namespace Application.Features.Auth.Commands.ForgotPassword;
public class ForgotPasswordCommand : IRequest
{
    public ForgotPasswordDto ForgotPasswordDto { get; set; }
    public string IpAddress { get; set; }
    public string? ForgotPasswordUrlPrefix { get; set; }

    public ForgotPasswordCommand()
    {
        ForgotPasswordUrlPrefix = string.Empty;
    }

    public ForgotPasswordCommand(ForgotPasswordDto forgotPasswordDto, string forgotPasswordUrlPrefix)
    {
        ForgotPasswordDto = forgotPasswordDto;
        ForgotPasswordUrlPrefix = forgotPasswordUrlPrefix;
    }

    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand>
    {
        private readonly IUserService _userService;
        private readonly IMailService _mailService;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IAuthService _authService;
        private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;


        public ForgotPasswordCommandHandler(IUserService userService, IMailService mailService, AuthBusinessRules authBusinessRules, IEmailAuthenticatorRepository emailAuthenticatorRepository, IAuthService authService)
        {
            _userService = userService;
            _mailService = mailService;
            _authBusinessRules = authBusinessRules;
            _emailAuthenticatorRepository = emailAuthenticatorRepository;
            _authService = authService;
        }

        public async Task Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userService.GetAsync(
                predicate: u => u.Email == request.ForgotPasswordDto.Email,
                cancellationToken: cancellationToken);//Gelen email ile eşleşen userı getirir

            await _authBusinessRules.UserShouldBeExistsWhenSelected(user); //Böyle bir user var mı kontrol ediyor

            var emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(e => e.UserId == user.Id);


            AccessToken createdAccessToken = await _authService.CreateAccessToken(user);//userin tokenini oluşturur
            createdAccessToken.ExpirationDate = DateTime.Now.AddMinutes(15);


            //EmailAuthenticator tablosundaki şifremi unuttum için oluşturulan token ve süresini tabloya atıyoruz
            emailAuthenticator.ResetPasswordToken = createdAccessToken.Token;
            emailAuthenticator.ResetPasswordTokenExpiry = createdAccessToken.ExpirationDate;
            await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);

            var toEmailList = new List<MailboxAddress> { new(name: user.Email, user.Email) };

            string ResetPasswordLink = $"http://localhost:4200/reset-password?token={createdAccessToken.Token}";

            string htmlFilePath = Path.Combine("wwwroot", "emails", "ForgotPassword.html");

            string htmlContent = File.ReadAllText(htmlFilePath);

            htmlContent = htmlContent.Replace("{{VerifyLink}}", ResetPasswordLink);

            _mailService.SendMail(
                new Mail
                {
                    ToList = toEmailList,
                    Subject = "Şifrenizi mi unuttunuz? - CodeStorm",
                    TextBody =
                        $"Link üzerinden şifrenizi yenileyebilirsiniz, bu uzantıyı kimseyle palaşmayın. Buraya tıklayın : {ResetPasswordLink}",
                    HtmlBody = htmlContent

                }
            );

        }
    }
}
