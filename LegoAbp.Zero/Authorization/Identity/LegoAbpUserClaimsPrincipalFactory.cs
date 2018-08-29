using Abp.Dependency;
using LegoAbp.Zero.Authorization.Roles.Domain;
using LegoAbp.Zero.Authorization.Users.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace LegoAbp.Zero.Authorization.Identity
{
    public class LegoAbpUserClaimsPrincipalFactory: UserClaimsPrincipalFactory<User,Role>, ITransientDependency
    {
        public LegoAbpUserClaimsPrincipalFactory(LegoAbpUserManager legoAbpUserManager,LegoAbpRoleManager legoAbpRoleManager, IOptions<IdentityOptions> optionsAccessor) : base(legoAbpUserManager, legoAbpRoleManager, optionsAccessor)
        {

        }
    }
}
