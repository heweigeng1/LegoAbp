using Abp.Domain.Repositories;
using Abp.Localization;
using LegoAbp.Zero.Authorization.Accounts.Dto;
using LegoAbp.Zero.Authorization.Users.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace LegoAbp.Zero.Authorization.Accounts
{
    public class AccountAppService : LegoAbpAppServiceBase, IAccountAppService
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly LegoAbpUserManager _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountAppService(IRepository<User, long> userRepository, LegoAbpUserManager userManager, SignInManager<User> signInManager)
        {

            LocalizationSourceName = LegoAbpZeroConsts.LocalizationIdentitySourceName;
            LocalizationManager = NullLocalizationManager.Instance;
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// 手机号注册
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IdentityResult> RegisterByPhone(PhoneNumberRegisterInput input)
        {
            var user = new User
            {
                UserName = input.PhoneNumber,
                PhoneNumber = input.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user, input.Password);
            return result;
        }

        public async Task<SignInResult> Login(PhoneNumberLoginInput input)
        {
            var user = _userRepository.FirstOrDefault(c => c.PhoneNumber == input.PhoneNumber);
            return await _signInManager.PasswordSignInAsync(user, input.Password, true, true);
        }
        public async Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input)
        {
            var tenant = await TenantManager.FindByTenancyNameAsync(input.TenancyName);
            if (tenant == null)
            {
                return new IsTenantAvailableOutput(TenantAvailabilityState.NotFound);
            }

            if (!tenant.IsActive)
            {
                return new IsTenantAvailableOutput(TenantAvailabilityState.InActive);
            }

            return new IsTenantAvailableOutput(TenantAvailabilityState.Available, tenant.Id);
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
