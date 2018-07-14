using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Identity
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
