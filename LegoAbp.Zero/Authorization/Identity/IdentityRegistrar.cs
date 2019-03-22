using LegoAbp.Zero.Authorization.Roles.Domain;
using LegoAbp.Zero.Authorization.Users.Domain;
using LegoAbp.Zero.Editions.Domain;
using LegoAbp.Zero.Tenants.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Authorization.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {

            services.AddLogging();
            return services.AddAbpIdentity<Tenant, User, Role>()
                .AddAbpTenantManager<LegoAbpTenantManager>()
                .AddAbpUserManager<LegoAbpUserManager>()
                .AddAbpRoleManager<LegoAbpRoleManager>()
                .AddAbpEditionManager<LegoAbpEditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpUserClaimsPrincipalFactory<LegoAbpUserClaimsPrincipalFactory>()
                .AddDefaultTokenProviders();
        }
    }
}
