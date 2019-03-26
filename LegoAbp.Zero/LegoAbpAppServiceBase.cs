using Abp.Application.Services;
using LegoAbp.Zero.Authorization.Users.Domain;
using LegoAbp.Zero.Tenants.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Runtime.Session;
using Abp.IdentityFramework;

namespace LegoAbp.Zero
{
    public abstract class LegoAbpAppServiceBase : ApplicationService
    {
        public LegoAbpTenantManager TenantManager { get; set; }

        public LegoAbpUserManager UserManager { get; set; }

        protected LegoAbpAppServiceBase()
        {
            LocalizationSourceName = LegoAbpConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

    }
}
