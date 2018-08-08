﻿
using Abp.Application.Services;
using Abp.Domain.Repositories;
using LegoAbp.Zero.Authorization.Accounts.Dto;
using LegoAbp.Zero.Authorization.Users.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LegoAbp.Zero.Authorization.Accounts
{
    public class AccountAppService : ApplicationService, IAccountAppService
    {
        protected IRepository<User, Guid> _userRepository;
        protected LegoAbpUserManager _userManager;
        public AccountAppService(IRepository<User, Guid> userRepository, LegoAbpUserManager userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }
        public async Task<IdentityResult> RegisterByPhone(PhoneNumberRegisterInput input)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = input.PhoneNumber,
                PhoneNumber = input.PhoneNumber,
            };
          return await  _userManager.CreateAsync(user,input.Password);
        }
        public void Login()
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public void Register()
        {
            throw new NotImplementedException();
        }
    }
}
