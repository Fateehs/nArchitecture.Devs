using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Mail already exists");

        }

        public async Task EmailMustBeValidWhenLoggedIn(string email)
        {
            User? getByEmailUser = await _userRepository.GetAsync(u => u.Email == email);
            if (getByEmailUser == null) throw new BusinessException("Email does not exists.");
        }

        public async Task PasswordMustBeValidWhenLoggedIn(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (!HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt))
                throw new BusinessException("The entered password is incorrect.");
        }
    }
}
