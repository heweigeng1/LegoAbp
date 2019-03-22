using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Dependency;
using LegoAbp.Zero.Authorization.Roles.Domain;
using LegoAbp.Zero.Authorization.Users.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace LegoAbp.Zero.Authorization.Identity
{
    public class LegoAbpUserClaimsPrincipalFactory : AbpUserClaimsPrincipalFactory<User, Role>, ITransientDependency
    {
        public LegoAbpUserClaimsPrincipalFactory(LegoAbpUserManager userManager, LegoAbpRoleManager roleManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        {
        }
    }
}
