using Abp.Dependency;
using Abp.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace LegoAbp.Zero.Authorization.Roles.Domain
{
    public class LegoAbpRoleManager : RoleManager<Role>, IDomainService, ITransientDependency
    {
        public LegoAbpRoleManager(IRoleStore<Role> store, IEnumerable<IRoleValidator<Role>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<Role>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
