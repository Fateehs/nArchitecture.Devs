using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.Auth;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands
{
    public class LoginCommand : IRequest<LoggedInDto>
    {
        public UserForLoginDto userForLoginDto { get; set; }
        public string IpAddress { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedInDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;

            public LoginCommandHandler(IUserRepository userRepository, IAuthService authService, AuthBusinessRules authBusinessRules)
            {
                _userRepository = userRepository;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<LoggedInDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User? getByEmailUser = await _userRepository.GetAsync(u => u.Email == request.userForLoginDto.Email);

                await _authBusinessRules.EmailMustBeValidWhenLoggedIn(request.userForLoginDto.Email);
                await _authBusinessRules.PasswordMustBeValidWhenLoggedIn(request.userForLoginDto.Password, getByEmailUser.PasswordHash, getByEmailUser.PasswordSalt);

                AccessToken createAccessToken = await _authService.CreateAccessToken(getByEmailUser);
                RefreshToken createRefreshToken = await _authService.CreateRefreshToken(getByEmailUser, request.IpAddress);
                RefreshToken addRefreshToken = await _authService.AddRefreshToken(createRefreshToken);
                LoggedInDto loggedInDto = new() { AccessToken = createAccessToken, RefreshToken = addRefreshToken };

                return loggedInDto;
            }
        }
    }
}
