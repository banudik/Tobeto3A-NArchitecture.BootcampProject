using Application.Features.Auth.Rules;
using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Application.Services.UsersService;
using Domain.Entities;
using MediatR;
using MimeKit;
using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Security.Entities;
using NArchitecture.Core.Security.Enums;
using NArchitecture.Core.Security.JWT;
using System.Web;

namespace Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<LoggedResponse>
{
    public UserForLoginDto UserForLoginDto { get; set; }
    public string IpAddress { get; set; }

    public LoginCommand()
    {
        UserForLoginDto = null!;
        IpAddress = string.Empty;
    }

    public LoginCommand(UserForLoginDto userForLoginDto, string ipAddress)
    {
        UserForLoginDto = userForLoginDto;
        IpAddress = ipAddress;
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedResponse>
    {
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IAuthenticatorService _authenticatorService;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IMailService _mailService;
        private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;


        public LoginCommandHandler(
            IUserService userService,
            IAuthService authService,
            AuthBusinessRules authBusinessRules,
            IAuthenticatorService authenticatorService,
            IMailService mailService,
            IEmailAuthenticatorRepository emailAuthenticatorRepository)
        {
            _userService = userService;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _authenticatorService = authenticatorService;
            _mailService = mailService;
            _emailAuthenticatorRepository = emailAuthenticatorRepository;
        }

        public async Task<LoggedResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userService.GetAsync(
                predicate: u => u.Email == request.UserForLoginDto.Email,
                cancellationToken: cancellationToken
            );
            await _authBusinessRules.UserShouldBeExistsWhenSelected(user);
            await _authBusinessRules.UserPasswordShouldBeMatch(user!, request.UserForLoginDto.Password);

            LoggedResponse loggedResponse = new();

            //Kullanıcının Kimlik doğrulama tipini kontrol eder, AuthenticatorType = 1 ve AuthenticatorCode = null ise kimlik doğrulama kodu gönderir.
            // swagger'dan test ederken null yerine "string" gönderdiği için doğrulama kodu göndermiyor, elle null girilmesi gerek
            if (user!.AuthenticatorType is not AuthenticatorType.None)
            {
                if (request.UserForLoginDto.AuthenticatorCode is null)
                {
                    await _authenticatorService.SendAuthenticatorCode(user);
                    loggedResponse.RequiredAuthenticatorType = user.AuthenticatorType;

                    //EmailAuthenticator emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(
                    //predicate: e => e.UserId == user.Id,
                    //cancellationToken: cancellationToken);

                    var toEmailList = new List<MailboxAddress> { new(name: user.Email, user.Email) };

                    //_mailService.SendMail(
                    //    new Mail
                    //    {
                    //        ToList = toEmailList,
                    //        Subject = "İki faktörlü kimlik doğrulama kodunuz - CodeStorm",
                    //        TextBody =
                    //            $"Kodunuz: {emailAuthenticator.ActivationKey}",
                    //        HtmlBody =
                    //            $"Kodunuz: {emailAuthenticator.ActivationKey}"
                    //    }
                    //);

                    return loggedResponse;
                }

                await _authenticatorService.VerifyAuthenticatorCode(user, request.UserForLoginDto.AuthenticatorCode);
            }

            AccessToken createdAccessToken = await _authService.CreateAccessToken(user);

            Domain.Entities.RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
            Domain.Entities.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);
            await _authService.DeleteOldRefreshTokens(user.Id);

            loggedResponse.AccessToken = createdAccessToken;
            loggedResponse.RefreshToken = addedRefreshToken;
            return loggedResponse;
        }
    }
}
