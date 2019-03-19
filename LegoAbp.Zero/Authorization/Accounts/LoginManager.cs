using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Runtime.Security;
using Abp.Zero.Configuration;
using LegoAbp.Zero.Authorization.Roles.Domain;
using LegoAbp.Zero.Authorization.Users.Domain;
using LegoAbp.Zero.Tenants.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LegoAbp.Zero.Authorization.Accounts
{
    public class LogInManager : AbpLogInManager<Tenant, Role, User>
    {
        private readonly LegoAbpUserManager _userManager;
        private readonly AbpUserClaimsPrincipalFactory<User, Role> _claimsPrincipalFactory;

        public LogInManager(LegoAbpUserManager userManager,
            IMultiTenancyConfig multiTenancyConfig,
            IRepository<Tenant> tenantRepository,
            IUnitOfWorkManager unitOfWorkManager,
            ISettingManager settingManager,
            IRepository<UserLoginAttempt, long> userLoginAttemptRepository,
            IUserManagementConfig userManagementConfig,
            IIocResolver iocResolver,
            IPasswordHasher<User> passwordHasher,
            AbpRoleManager<Role, User> roleManager,
            AbpUserClaimsPrincipalFactory<User, Role> claimsPrincipalFactory) : base(userManager, multiTenancyConfig, tenantRepository, unitOfWorkManager, settingManager, userLoginAttemptRepository, userManagementConfig, iocResolver, passwordHasher, roleManager, claimsPrincipalFactory)
        {

        }

        public override Task<AbpLoginResult<Tenant, User>> LoginAsync(string userNameOrEmailAddress, string plainPassword, string tenancyName = null, bool shouldLockout = true)
        {
            return base.LoginAsync(userNameOrEmailAddress, plainPassword, tenancyName, shouldLockout);
        }

        public Task<AbpLoginResult<Tenant, User>> CreateLoginResult(User user, Tenant tenant = null)
        {
            return CreateLoginResultAsync(user, tenant);
        }

        protected override async Task<AbpLoginResult<Tenant, User>> LoginAsyncInternal(string userNameOrEmailAddress, string plainPassword, string tenancyName, bool shouldLockout)
        {
            if (userNameOrEmailAddress.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(userNameOrEmailAddress));
            }

            if (plainPassword.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(plainPassword));
            }

            //Get and check tenant
            Tenant tenant = null;
            using (UnitOfWorkManager.Current.SetTenantId(null))
            {
                if (!MultiTenancyConfig.IsEnabled)
                {
                    tenant = await GetDefaultTenantAsync();
                }
                else if (!string.IsNullOrWhiteSpace(tenancyName))
                {
                    tenant = await TenantRepository.FirstOrDefaultAsync(t => t.TenancyName == tenancyName);
                    if (tenant == null)
                    {
                        return new AbpLoginResult<Tenant, User>(AbpLoginResultType.InvalidTenancyName);
                    }

                    if (!tenant.IsActive)
                    {
                        return new AbpLoginResult<Tenant, User>(AbpLoginResultType.TenantIsNotActive, tenant);
                    }
                }
            }

            var tenantId = tenant == null ? (int?)null : tenant.Id;
            using (UnitOfWorkManager.Current.SetTenantId(tenantId))
            {
                await UserManager.InitializeOptionsAsync(tenantId);

                //TryLoginFromExternalAuthenticationSources method may create the user, that's why we are calling it before AbpUserStore.FindByNameOrEmailAsync
                var loggedInFromExternalSource = await TryLoginFromExternalAuthenticationSources(userNameOrEmailAddress, plainPassword, tenant);

                var user = await UserManager.FindByNameOrEmailAsync(tenantId, userNameOrEmailAddress);
                if (user == null)
                {
                    return new AbpLoginResult<Tenant, User>(AbpLoginResultType.InvalidUserNameOrEmailAddress, tenant);
                }

                if (await UserManager.IsLockedOutAsync(user))
                {
                    return new AbpLoginResult<Tenant, User>(AbpLoginResultType.LockedOut, tenant, user);
                }

                if (!loggedInFromExternalSource)
                {
                    if (!await UserManager.CheckPasswordAsync(user, plainPassword))
                    {
                        if (shouldLockout)
                        {
                            if (await TryLockOutAsync(tenantId, user.Id))
                            {
                                return new AbpLoginResult<Tenant, User>(AbpLoginResultType.LockedOut, tenant, user);
                            }
                        }

                        return new AbpLoginResult<Tenant, User>(AbpLoginResultType.InvalidPassword, tenant, user);
                    }

                    await UserManager.ResetAccessFailedCountAsync(user);
                }

                return await CreateLoginResultAsync(user, tenant);
            }
        }

        [UnitOfWork(IsDisabled = true)]
        protected override async Task<AbpLoginResult<Tenant, User>> CreateLoginResultAsync(User user, Tenant tenant = null)
        {
            //user.LastLoginTime = Clock.Now;
            UnitOfWorkManager.Current.SetTenantId(null);

            //await UserManager.UpdateAsync(user);

            //await UnitOfWorkManager.Current.SaveChangesAsync();
            var principal = await _claimsPrincipalFactory.CreateAsync(user);
            if (tenant != null)
            {
                principal.Identities.First().AddClaim(new Claim(AbpClaimTypes.TenantId, tenant.Id.ToString()));
            }
            return new AbpLoginResult<Tenant, User>(
                tenant,
                user,
                principal.Identity as ClaimsIdentity
            );
        }
    }
}
