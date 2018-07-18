using Microsoft.AspNetCore.Identity;
using System;

namespace LegoAbp.Zero.Authorization.Identity
{
    public class LegoAbpIdentityBuilder : IdentityBuilder
    {
        public Type TenantType { get; set; }

        public LegoAbpIdentityBuilder(IdentityBuilder identityBuilder, Type tenantType) : base(identityBuilder.UserType, identityBuilder.RoleType, identityBuilder.Services)
        {
            TenantType = tenantType;
        }
    }
}
