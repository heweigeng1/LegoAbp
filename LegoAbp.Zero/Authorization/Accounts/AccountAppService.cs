
using Abp.Application.Services;
using Abp.Domain.Repositories;
using LegoAbp.Zero.Authorization.Accounts.Dto;
using LegoAbp.Zero.Authorization.Users.Domain;
using System;
using System.Collections.Generic;
using System.Text;

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
        public void RegisterByPhone(PhoneNumberRegisterInput input)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = input.PhoneNumber,
                PhoneNumber = input.PhoneNumber,
            };
            _userManager.CreateAsync(user,input.Password);
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
