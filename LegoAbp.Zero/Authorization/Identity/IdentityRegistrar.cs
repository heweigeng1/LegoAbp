using LegoAbp.Zero.Authorization.Roles.Domain;
using LegoAbp.Zero.Authorization.Users.Domain;
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

            return services.AddIdentity<User, Role>();
        }
    }
}
