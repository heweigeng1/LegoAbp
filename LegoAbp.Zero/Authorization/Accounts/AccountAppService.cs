
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.UI;
using LegoAbp.Zero.Authorization.Accounts.Dto;
using LegoAbp.Zero.Authorization.Users.Domain;
using System;

namespace LegoAbp.Zero.Authorization.Accounts
{
    public class AccountAppService : ApplicationService, IAccountAppService
    {
        private readonly IRepository<User, Guid> _userRepository;
        private readonly LegoAbpUserManager _userManager;
        public AccountAppService(IRepository<User, Guid> userRepository, LegoAbpUserManager userManager)
        {

            LocalizationSourceName = LegoAbpZeroConsts.LocalizationIdentitySourceName;
            LocalizationManager = NullLocalizationManager.Instance;
            _userRepository = userRepository;
            _userManager = userManager;
        }
        public async void RegisterByPhone(PhoneNumberRegisterInput input)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = input.PhoneNumber,
                PhoneNumber = input.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user, input.Password);
            result.CheckErrors();
        }
        public void Login()
        {
            throw new UserFriendlyException("aaaaabbbbcccc");
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
