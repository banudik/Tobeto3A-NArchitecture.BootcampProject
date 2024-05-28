using Application.Features.Applicants.Commands.Update;
using Application.Features.Applicants.Constants;
using Application.Features.Applicants.Rules;
using Application.Features.Auth.Commands.ForgotPassword;
using Application.Features.Auth.Constants;
using Application.Features.Auth.Rules;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Constants;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Application.Services.UsersService;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.ResetPassword;
public class ResetPasswordCommand : IRequest , ISecuredRequest
{
    public Guid UserId { get; set; }
    public ResetPasswordDto ResetPasswordDtos { get; set; }

    string[] ISecuredRequest.Roles => throw new NotImplementedException();


    public ResetPasswordCommand()
    {
        ResetPasswordDtos = null!;
    }

    public ResetPasswordCommand(Guid userId,ResetPasswordDto resetPasswordDto)
    {
        UserId = userId;
        ResetPasswordDtos = resetPasswordDto;
    }

    public class ForgotPasswordCommandHandler : IRequestHandler<ResetPasswordCommand>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IUserRepository _userRepository;
        private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;

        public ForgotPasswordCommandHandler(IUserService userService, IMapper mapper, AuthBusinessRules authBusinessRules, UserBusinessRules userBusinessRules, IUserRepository userRepository, IEmailAuthenticatorRepository emailAuthenticatorRepository)
        {
            _userService = userService;
            _mapper = mapper;
            _authBusinessRules = authBusinessRules;
            _userBusinessRules = userBusinessRules;
            _userRepository = userRepository;
            _emailAuthenticatorRepository = emailAuthenticatorRepository;
        }


        public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            //Gelen istek üzerindek UserId ile eşleşen account'u getirir
            User? user = await _userService.GetAsync(
                predicate: u => u.Id == request.UserId,
                cancellationToken: cancellationToken
            );
            //Eşleşen kullanıcı var mı kontrol eder (User == null)
            await _authBusinessRules.UserShouldBeExistsWhenSelected(user);

            //Eski şifre ile aynı olmaması için kontrol ediyoruz ( şuan exception mesajını göstermiyor...)
            await _authBusinessRules.PasswordShouldNotBeSameAsOld(request.ResetPasswordDtos.Password, user);

            //şifre sıfırlama isteği oluşturulmuş mu kontrolu, aynı link üzerinten tekrar şifre değiştirmeyi de engeller
            var emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(e => e.UserId == user.Id);
            await _authBusinessRules.PasswordResetRequestBeExists(emailAuthenticator);

            //Yeni şifrenin encrypt edilmesi
            HashingHelper.CreatePasswordHash(
                request.ResetPasswordDtos.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            //Kullanıcının Şifre sıfırlama isteğini kaldırıyoruz, aynı link üzerinden tekrar şifre sıfırlamak isterse engel olmak için
            emailAuthenticator.ResetPasswordToken = false;
            emailAuthenticator.ResetPasswordTokenExpiry = null;
            await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);

            await _userRepository.UpdateAsync(user!);

            //UpdatedUserResponse response = _mapper.Map<UpdatedUserResponse>(user);

        }

    }
}
