using LegoAbp.Zero.Tenants;
using LegoAbp.Zero.Tenants.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Identity
{
    public static class IdentityTenantBuilderExtensions
    {
        public static LegoAbpIdentityBuilder AddAbpTenantManager<TTenantManager>(this LegoAbpIdentityBuilder builder)
            where TTenantManager : class
        {
            var type = typeof(TTenantManager);
            var abpManagerType = typeof(TenantManager).MakeGenericType(builder.TenantType, builder.UserType);
            builder.Services.AddScoped(type, provider => provider.GetRequiredService(abpManagerType));
            builder.Services.AddScoped(abpManagerType, type);
            return builder;
        }
    }
}
