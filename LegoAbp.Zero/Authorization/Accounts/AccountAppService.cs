
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
        private readonly SignInManager<User> _signInManager;
        public AccountAppService(IRepository<User, Guid> userRepository, LegoAbpUserManager userManager, SignInManager<User> signInManager)
        {

            LocalizationSourceName = LegoAbpZeroConsts.LocalizationIdentitySourceName;
            LocalizationManager = NullLocalizationManager.Instance;
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
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
        //[AbpAuthorize(PermissionNames.User_Create)]
        public async void Login(PhoneNumberLoginInput input)
        {
            var user = _userRepository.FirstOrDefault(c => c.PhoneNumber == input.PhoneNumber);
            var result = await _signInManager.PasswordSignInAsync(user, input.Password, true, true);
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
