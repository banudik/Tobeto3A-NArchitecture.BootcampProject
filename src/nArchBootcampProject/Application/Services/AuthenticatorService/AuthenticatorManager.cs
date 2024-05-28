﻿using Application.Services.Repositories;
using Domain.Entities;
using MimeKit;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Security.EmailAuthenticator;
using NArchitecture.Core.Security.Enums;
using NArchitecture.Core.Security.OtpAuthenticator;

namespace Application.Services.AuthenticatorService;

public class AuthenticatorManager : IAuthenticatorService
{
    private readonly IEmailAuthenticatorHelper _emailAuthenticatorHelper;
    private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
    private readonly IMailService _mailService;
    private readonly IOtpAuthenticatorHelper _otpAuthenticatorHelper;
    private readonly IOtpAuthenticatorRepository _otpAuthenticatorRepository;
    private readonly string _htmlFilePath;

    public AuthenticatorManager(
        IEmailAuthenticatorHelper emailAuthenticatorHelper,
        IEmailAuthenticatorRepository emailAuthenticatorRepository,
        IMailService mailService,
        IOtpAuthenticatorHelper otpAuthenticatorHelper,
        IOtpAuthenticatorRepository otpAuthenticatorRepository
    )
    {
        _emailAuthenticatorHelper = emailAuthenticatorHelper;
        _emailAuthenticatorRepository = emailAuthenticatorRepository;
        _mailService = mailService;
        _otpAuthenticatorHelper = otpAuthenticatorHelper;
        _otpAuthenticatorRepository = otpAuthenticatorRepository;
        _htmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", "emails", "2FA.html");
    }

    public async Task<EmailAuthenticator> CreateEmailAuthenticator(User user)
    {
        EmailAuthenticator emailAuthenticator =
            new()
            {
                UserId = user.Id,
                ActivationKey = await _emailAuthenticatorHelper.CreateEmailActivationKey(),
                IsVerified = false
            };
        return emailAuthenticator;
    }

    public async Task<OtpAuthenticator> CreateOtpAuthenticator(User user)
    {
        OtpAuthenticator otpAuthenticator =
            new()
            {
                UserId = user.Id,
                SecretKey = await _otpAuthenticatorHelper.GenerateSecretKey(),
                IsVerified = false
            };
        return otpAuthenticator;
    }

    public async Task<string> ConvertSecretKeyToString(byte[] secretKey)
    {
        string result = await _otpAuthenticatorHelper.ConvertSecretKeyToString(secretKey);
        return result;
    }

    public async Task SendAuthenticatorCode(User user)
    {
        if (user.AuthenticatorType is AuthenticatorType.Email)
            await SendAuthenticatorCodeWithEmail(user);
    }

    public async Task VerifyAuthenticatorCode(User user, string authenticatorCode)
    {
        if (user.AuthenticatorType is AuthenticatorType.Email)
            await VerifyAuthenticatorCodeWithEmail(user, authenticatorCode);
        else if (user.AuthenticatorType is AuthenticatorType.Otp)
            await VerifyAuthenticatorCodeWithOtp(user, authenticatorCode);
    }

    private async Task SendAuthenticatorCodeWithEmail(User user)
    {
        EmailAuthenticator? emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(predicate: e =>
            e.UserId == user.Id
        );
        if (emailAuthenticator is null)
            throw new NotFoundException("E-posta Kimlik Doğrulayıcı bulunamadı.");
        if (!emailAuthenticator.IsVerified)
            throw new BusinessException("E-posta Kimlik Doğrulayıcının doğrulanmış olması gerekir.");

        string authenticatorCode = await _emailAuthenticatorHelper.CreateEmailActivationCode();
        emailAuthenticator.ActivationKey = authenticatorCode;
        await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);

        var toEmailList = new List<MailboxAddress> { new(name: user.Email, address: user.Email) };

        //  html dosyası çok uzun olduğu için replace metodu performansı etkileyebilir yavaş çalışırsa aşağıdaki yapıyı uygula
        //using (StreamReader sr = new StreamReader(_htmlFilePath))
        //using (StreamWriter sw = new StreamWriter("path/to/temporary/html/file.html"))
        //{
        //    string line;
        //    while ((line = sr.ReadLine()) != null)
        //    {
        //        // Eğer satır içinde "{{ActivationCode}}" varsa, bu kısmı değiştir ve yeni dosyaya yaz
        //        if (line.Contains("{{ActivationCode}}"))
        //        {
        //            line = line.Replace("{{ActivationCode}}", authenticatorCode);
        //        }
        //        sw.WriteLine(line);
        //    }
        //}
        //string htmlContent = File.ReadAllText("path/to/temporary/html/file.html");

        string htmlFilePath = Path.Combine("wwwroot", "emails", "2FA.html");

        string htmlContent = File.ReadAllText(htmlFilePath);

        htmlContent = htmlContent.Replace("{{ActivationCode}}", authenticatorCode);

        await _mailService.SendEmailAsync(
            new Mail
            {
                ToList = toEmailList,
                Subject = "İki faktörlü kimlik doğrulama kodunuz - CodeStorm",
                TextBody = $"Enter your authenticator code: {authenticatorCode}",
                HtmlBody = htmlContent

            }
        );
    }

    private async Task VerifyAuthenticatorCodeWithEmail(User user, string authenticatorCode)
    {
        EmailAuthenticator? emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(predicate: e =>
            e.UserId == user.Id
        );
        if (emailAuthenticator is null)
            throw new NotFoundException("Email Authenticator not found.");
        if (emailAuthenticator.ActivationKey != authenticatorCode)
            throw new BusinessException("Authenticator code is invalid.");
        emailAuthenticator.ActivationKey = null;
        await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);
    }

    private async Task VerifyAuthenticatorCodeWithOtp(User user, string authenticatorCode)
    {
        OtpAuthenticator? otpAuthenticator = await _otpAuthenticatorRepository.GetAsync(predicate: e => e.UserId == user.Id);
        if (otpAuthenticator is null)
            throw new NotFoundException("Otp Authenticator not found.");
        bool result = await _otpAuthenticatorHelper.VerifyCode(otpAuthenticator.SecretKey, authenticatorCode);
        if (!result)
            throw new BusinessException("Authenticator code is invalid.");
    }
}
