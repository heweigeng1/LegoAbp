
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Localization;
using Abp.UI;
using LegoAbp.Zero.Authorization.Accounts.Dto;
using LegoAbp.Zero.Authorization.Users.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

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
        public async Task<IdentityResult> RegisterByPhone(PhoneNumberRegisterInput input)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = input.PhoneNumber,
                PhoneNumber = input.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user, input.Password);
            return result;
        }
        public async void Login()
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = "12345678901",
                PhoneNumber = "12345678901",
            };
            var result = await _userManager.CreateAsync(user, "123Aa_123");
            throw new UserFriendlyException("123");
        }

        public string Logout()
        {
            return LocalizationManager.GetSource(LegoAbpZeroConsts.LocalizationSourceName).GetString(PermissionNames.User_Create);
        }

        public void Register()
        {
            throw new NotImplementedException();
        }
    }
}
